using Loqui;
using Mutagen.Bethesda.Core;
using Noggog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda
{
    /// <summary>
    /// A Link Cache using a LoadOrder as its link target. <br/>
    /// Will resolve links to the highest overriding mod containing the record being sought. <br/>
    /// <br/>
    /// Internal caching will only occur as deep into the load order as necessary, for only the types required
    /// to serve the requested link.
    /// <br/>
    /// All functionality is multithread safe. <br/>
    /// <br/>
    /// Modification of the target LoadOrder, or Mods on the LoadOrder is not safe.  Internal caches can become
    /// incorrect if modifications occur on content already cached.
    /// </summary>
    /// <typeparam name="TMod">Mod setter type</typeparam>
    /// <typeparam name="TModGetter">Mod getter type</typeparam>
    public class ImmutableLoadOrderLinkCache<TMod, TModGetter> : ILinkCache<TMod, TModGetter>
        where TMod : class, IContextMod<TMod>, TModGetter
        where TModGetter : class, IContextGetterMod<TMod>
    {
        private readonly bool _hasAny;
        private readonly GameCategory _gameCategory;

        private readonly IReadOnlyList<TModGetter> _listedOrder;
        private readonly IReadOnlyList<TModGetter> _priorityOrder;
        private readonly DepthCache<IMajorRecordCommonGetter> _loadOrderUntypedMajorRecords;
        private readonly DepthCache<IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter>> _loadOrderUntypedContexts;
        private readonly Dictionary<Type, DepthCache<IMajorRecordCommonGetter>> _loadOrderMajorRecords;
        private readonly Dictionary<Type, DepthCache<IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter>>> _loadOrderContexts;

        /// <inheritdoc />
        public IReadOnlyList<IModGetter> ListedOrder => _listedOrder;

        /// <inheritdoc />
        public IReadOnlyList<IModGetter> PriorityOrder => _priorityOrder;

        /// <summary>
        /// Constructs a LoadOrderLinkCache around a target load order
        /// </summary>
        /// <param name="loadOrder">LoadOrder to resolve against when linking</param>
        public ImmutableLoadOrderLinkCache(IEnumerable<TModGetter> loadOrder)
        {
            this._listedOrder = loadOrder.ToList();
            this._priorityOrder = _listedOrder.Reverse().ToList();
            this._loadOrderUntypedMajorRecords = new DepthCache<IMajorRecordCommonGetter>();
            this._loadOrderUntypedContexts = new DepthCache<IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter>>();
            this._loadOrderMajorRecords = new Dictionary<Type, DepthCache<IMajorRecordCommonGetter>>();
            this._loadOrderContexts = new Dictionary<Type, DepthCache<IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter>>>();
            var firstMod = _listedOrder.FirstOrDefault();
            this._hasAny = firstMod != null;
            // ToDo
            // Upgrade to bounce off ModInstantiator systems
            this._gameCategory = firstMod?.GameRelease.ToCategory() ?? GameCategory.Oblivion;
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolve(FormKey formKey, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            if (!_hasAny || formKey.IsNull)
            {
                majorRec = default;
                return false;
            }

            lock (this._loadOrderUntypedMajorRecords)
            {
                if (this._loadOrderUntypedMajorRecords.TryGetValue(formKey, out majorRec)) return true;
                if (this._loadOrderUntypedMajorRecords.Depth >= this._listedOrder.Count) return false;
                while (this._loadOrderUntypedMajorRecords.Depth < this._listedOrder.Count)
                {
                    // Get next unprocessed mod
                    var targetIndex = this._listedOrder.Count - _loadOrderUntypedMajorRecords.Depth - 1;
                    var targetMod = this._listedOrder[targetIndex];
                    this._loadOrderUntypedMajorRecords.Depth++;
                    // Add records from that mod that aren't already cached
                    foreach (var record in targetMod.EnumerateMajorRecords())
                    {
                        _loadOrderUntypedMajorRecords.AddIfMissing(record.FormKey, record);
                    }
                    // Check again
                    if (this._loadOrderUntypedMajorRecords.TryGetValue(formKey, out majorRec)) return true;
                }
                // Record doesn't exist
                return false;
            }
        }

        /// <inheritdoc />
        public bool TryResolve<TMajor>(FormKey formKey, [MaybeNullWhen(false)] out TMajor majorRec)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (!TryResolve(formKey, typeof(TMajor), out var commonRec))
            {
                majorRec = default;
                return false;
            }

            majorRec = commonRec as TMajor;
            return majorRec != null;
        }

        /// <inheritdoc />
        public bool TryResolve(FormKey formKey, Type type, [MaybeNullWhen(false)] out IMajorRecordCommonGetter majorRec)
        {
            if (!_hasAny || formKey.IsNull)
            {
                majorRec = default;
                return false;
            }

            lock (this._loadOrderMajorRecords)
            {
                // Get cache object by type
                if (!this._loadOrderMajorRecords.TryGetValue(type, out var cache))
                {
                    cache = new DepthCache<IMajorRecordCommonGetter>();
                    if (type.Equals(typeof(IMajorRecordCommon))
                        || type.Equals(typeof(IMajorRecordCommonGetter)))
                    {
                        this._loadOrderMajorRecords[typeof(IMajorRecordCommon)] = cache;
                        this._loadOrderMajorRecords[typeof(IMajorRecordCommonGetter)] = cache;
                    }
                    else if (LoquiRegistration.TryGetRegister(type, out var registration))
                    {
                        this._loadOrderMajorRecords[registration.ClassType] = cache;
                        this._loadOrderMajorRecords[registration.GetterType] = cache;
                        this._loadOrderMajorRecords[registration.SetterType] = cache;
                        if (registration.InternalGetterType != null)
                        {
                            this._loadOrderMajorRecords[registration.InternalGetterType] = cache;
                        }
                        if (registration.InternalSetterType != null)
                        {
                            this._loadOrderMajorRecords[registration.InternalSetterType] = cache;
                        }
                    }
                    else
                    {
                        var interfaceMappings = LinkInterfaceMapping.InterfaceToObjectTypes(_gameCategory);
                        if (!interfaceMappings.TryGetValue(type, out var objs))
                        {
                            throw new ArgumentException($"A lookup was queried for an unregistered type: {type.Name}");
                        }
                        this._loadOrderMajorRecords[type] = cache;
                    }
                }

                // Check for record
                if (cache.TryGetValue(formKey, out majorRec))
                {
                    return true;
                }
                if (cache.Depth >= this._listedOrder.Count)
                {
                    majorRec = default!;
                    return false;
                }

                while (cache.Depth < this._listedOrder.Count)
                {
                    // Get next unprocessed mod
                    var targetIndex = this._listedOrder.Count - cache.Depth - 1;
                    var targetMod = this._listedOrder[targetIndex];
                    cache.Depth++;

                    void AddRecords(TModGetter mod, Type type)
                    {
                        foreach (var record in mod.EnumerateMajorRecords(type))
                        {
                            cache.AddIfMissing(record.FormKey, record);
                        }
                    }

                    // Add records from that mod that aren't already cached
                    if (LinkInterfaceMapping.InterfaceToObjectTypes(_gameCategory).TryGetValue(type, out var objs))
                    {
                        foreach (var objType in objs)
                        {
                            AddRecords(targetMod, LoquiRegistration.GetRegister(objType).GetterType);
                        }
                    }
                    else
                    {
                        AddRecords(targetMod, type);
                    }
                    // Check again
                    if (cache.TryGetValue(formKey, out majorRec))
                    {
                        return true;
                    }
                }
                // Record doesn't exist
                majorRec = default;
                return false;
            }
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public IMajorRecordCommonGetter Resolve(FormKey formKey)
        {
            if (TryResolve<IMajorRecordCommonGetter>(formKey, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        public IMajorRecordCommonGetter Resolve(FormKey formKey, Type type)
        {
            if (TryResolve(formKey, type, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        public TMajor Resolve<TMajor>(FormKey formKey)
            where TMajor : class, IMajorRecordCommonGetter
        {
            if (TryResolve<TMajor>(formKey, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        [Obsolete("This call is not as optimized as its generic typed counterpart.  Use as a last resort.")]
        public bool TryResolveContext(FormKey formKey, [MaybeNullWhen(false)] out IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            if (!_hasAny || formKey.IsNull)
            {
                majorRec = default;
                return false;
            }

            lock (this._loadOrderUntypedContexts)
            {
                if (this._loadOrderUntypedContexts.TryGetValue(formKey, out majorRec)) return true;
                if (this._loadOrderUntypedContexts.Depth >= this._listedOrder.Count) return false;
                while (this._loadOrderUntypedContexts.Depth < this._listedOrder.Count)
                {
                    // Get next unprocessed mod
                    var targetIndex = this._listedOrder.Count - _loadOrderUntypedContexts.Depth - 1;
                    var targetMod = this._listedOrder[targetIndex];
                    this._loadOrderUntypedContexts.Depth++;
                    // Add records from that mod that aren't already cached
                    foreach (var record in targetMod.EnumerateMajorRecordContexts<IMajorRecordCommon, IMajorRecordCommonGetter>(this))
                    {
                        _loadOrderUntypedContexts.AddIfMissing(record.Record.FormKey, record);
                    }
                    // Check again
                    if (this._loadOrderUntypedContexts.TryGetValue(formKey, out majorRec)) return true;
                }
                // Record doesn't exist
                return false;
            }
        }

        /// <inheritdoc />
        public bool TryResolveContext<TMajorSetter, TMajorGetter>(FormKey formKey, [MaybeNullWhen(false)] out IModContext<TMod, TMajorSetter, TMajorGetter> majorRec)
            where TMajorSetter : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (!TryResolveContext(formKey, typeof(TMajorGetter), out var commonRec)
                || !(commonRec.Record is TMajorGetter))
            {
                majorRec = default;
                return false;
            }

            majorRec = commonRec.AsType<TMod, IMajorRecordCommon, IMajorRecordCommonGetter, TMajorSetter, TMajorGetter>();
            return majorRec != null;
        }

        /// <inheritdoc />
        public bool TryResolveContext(FormKey formKey, Type type, [MaybeNullWhen(false)] out IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter> majorRec)
        {
            if (!_hasAny || formKey.IsNull)
            {
                majorRec = default;
                return false;
            }

            lock (this._loadOrderContexts)
            {
                // Get cache object by type
                if (!this._loadOrderContexts.TryGetValue(type, out var cache))
                {
                    cache = new DepthCache<IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter>>();
                    if (type.Equals(typeof(IMajorRecordCommon))
                        || type.Equals(typeof(IMajorRecordCommonGetter)))
                    {
                        this._loadOrderContexts[typeof(IMajorRecordCommon)] = cache;
                        this._loadOrderContexts[typeof(IMajorRecordCommonGetter)] = cache;
                    }
                    else if (LoquiRegistration.TryGetRegister(type, out var registration))
                    {
                        this._loadOrderContexts[registration.ClassType] = cache;
                        this._loadOrderContexts[registration.GetterType] = cache;
                        this._loadOrderContexts[registration.SetterType] = cache;
                        if (registration.InternalGetterType != null)
                        {
                            this._loadOrderContexts[registration.InternalGetterType] = cache;
                        }
                        if (registration.InternalSetterType != null)
                        {
                            this._loadOrderContexts[registration.InternalSetterType] = cache;
                        }
                    }
                    else
                    {
                        var interfaceMappings = LinkInterfaceMapping.InterfaceToObjectTypes(_gameCategory);
                        if (!interfaceMappings.TryGetValue(type, out var objs))
                        {
                            throw new ArgumentException($"A lookup was queried for an unregistered type: {type.Name}");
                        }
                        this._loadOrderContexts[type] = cache;
                    }
                }

                // Check for record
                if (cache.TryGetValue(formKey, out majorRec))
                {
                    return true;
                }
                if (cache.Depth >= this._listedOrder.Count)
                {
                    majorRec = default!;
                    return false;
                }

                while (cache.Depth < this._listedOrder.Count)
                {
                    // Get next unprocessed mod
                    var targetIndex = this._listedOrder.Count - cache.Depth - 1;
                    var targetMod = this._listedOrder[targetIndex];
                    cache.Depth++;

                    void AddRecords(TModGetter mod, Type type)
                    {
                        foreach (var record in mod.EnumerateMajorRecordContexts(this, type))
                        {
                            cache.AddIfMissing(record.Record.FormKey, record);
                        }
                    }

                    // Add records from that mod that aren't already cached
                    if (LinkInterfaceMapping.InterfaceToObjectTypes(_gameCategory).TryGetValue(type, out var objs))
                    {
                        foreach (var objType in objs)
                        {
                            AddRecords(targetMod, LoquiRegistration.GetRegister(objType).GetterType);
                        }
                    }
                    else
                    {
                        AddRecords(targetMod, type);
                    }
                    // Check again
                    if (cache.TryGetValue(formKey, out majorRec))
                    {
                        return true;
                    }
                }
                // Record doesn't exist
                majorRec = default;
                return false;
            }
        }

        /// <inheritdoc />
        public IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter> ResolveContext(FormKey formKey)
        {
            if (TryResolveContext<IMajorRecordCommon, IMajorRecordCommonGetter>(formKey, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        public IModContext<TMod, IMajorRecordCommon, IMajorRecordCommonGetter> ResolveContext(FormKey formKey, Type type)
        {
            if (TryResolveContext(formKey, type, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }

        /// <inheritdoc />
        public IModContext<TMod, TMajorSetter, TMajorGetter> ResolveContext<TMajorSetter, TMajorGetter>(FormKey formKey)
            where TMajorSetter : class, IMajorRecordCommon, TMajorGetter
            where TMajorGetter : class, IMajorRecordCommonGetter
        {
            if (TryResolveContext<TMajorSetter, TMajorGetter>(formKey, out var commonRec)) return commonRec;
            throw new KeyNotFoundException($"Form ID {formKey.ID} could not be found.");
        }
    }

    internal class DepthCache<T>
    {
        private readonly Dictionary<FormKey, T> _dictionary = new Dictionary<FormKey, T>();
        public int Depth;

        public bool TryGetValue(FormKey key, [MaybeNullWhen(false)] out T value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        public void AddIfMissing(FormKey key, T item)
        {
            if (!_dictionary.ContainsKey(key))
            {
                _dictionary[key] = item;
            }
        }
    }
}
