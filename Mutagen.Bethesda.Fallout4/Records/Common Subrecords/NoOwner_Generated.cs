/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
#region Usings
using Loqui;
using Loqui.Internal;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda.Fallout4.Internals;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
#endregion

#nullable enable
namespace Mutagen.Bethesda.Fallout4
{
    #region Class
    public partial class NoOwner :
        OwnerTarget,
        INoOwner,
        ILoquiObjectSetter<NoOwner>,
        IEquatable<INoOwnerGetter>
    {
        #region Ctor
        public NoOwner()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region RawOwnerData
        public UInt32 RawOwnerData { get; set; } = default;
        #endregion
        #region RawVariableData
        public UInt32 RawVariableData { get; set; } = default;
        #endregion

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            NoOwnerMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is INoOwnerGetter rhs)) return false;
            return ((NoOwnerCommon)((INoOwnerGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(INoOwnerGetter? obj)
        {
            return ((NoOwnerCommon)((INoOwnerGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((NoOwnerCommon)((INoOwnerGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            OwnerTarget.Mask<TItem>,
            IMask<TItem>,
            IEquatable<Mask<TItem>>
        {
            #region Ctors
            public Mask(TItem initialValue)
            : base(initialValue)
            {
                this.RawOwnerData = initialValue;
                this.RawVariableData = initialValue;
            }

            public Mask(
                TItem RawOwnerData,
                TItem RawVariableData)
            : base()
            {
                this.RawOwnerData = RawOwnerData;
                this.RawVariableData = RawVariableData;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem RawOwnerData;
            public TItem RawVariableData;
            #endregion

            #region Equals
            public override bool Equals(object? obj)
            {
                if (!(obj is Mask<TItem> rhs)) return false;
                return Equals(rhs);
            }

            public bool Equals(Mask<TItem>? rhs)
            {
                if (rhs == null) return false;
                if (!base.Equals(rhs)) return false;
                if (!object.Equals(this.RawOwnerData, rhs.RawOwnerData)) return false;
                if (!object.Equals(this.RawVariableData, rhs.RawVariableData)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.RawOwnerData);
                hash.Add(this.RawVariableData);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.RawOwnerData)) return false;
                if (!eval(this.RawVariableData)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.RawOwnerData)) return true;
                if (eval(this.RawVariableData)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new NoOwner.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.RawOwnerData = eval(this.RawOwnerData);
                obj.RawVariableData = eval(this.RawVariableData);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(NoOwner.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, NoOwner.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(NoOwner.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.RawOwnerData ?? true)
                    {
                        fg.AppendItem(RawOwnerData, "RawOwnerData");
                    }
                    if (printMask?.RawVariableData ?? true)
                    {
                        fg.AppendItem(RawVariableData, "RawVariableData");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            OwnerTarget.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? RawOwnerData;
            public Exception? RawVariableData;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                NoOwner_FieldIndex enu = (NoOwner_FieldIndex)index;
                switch (enu)
                {
                    case NoOwner_FieldIndex.RawOwnerData:
                        return RawOwnerData;
                    case NoOwner_FieldIndex.RawVariableData:
                        return RawVariableData;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                NoOwner_FieldIndex enu = (NoOwner_FieldIndex)index;
                switch (enu)
                {
                    case NoOwner_FieldIndex.RawOwnerData:
                        this.RawOwnerData = ex;
                        break;
                    case NoOwner_FieldIndex.RawVariableData:
                        this.RawVariableData = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                NoOwner_FieldIndex enu = (NoOwner_FieldIndex)index;
                switch (enu)
                {
                    case NoOwner_FieldIndex.RawOwnerData:
                        this.RawOwnerData = (Exception?)obj;
                        break;
                    case NoOwner_FieldIndex.RawVariableData:
                        this.RawVariableData = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (RawOwnerData != null) return true;
                if (RawVariableData != null) return true;
                return false;
            }
            #endregion

            #region To String
            public override string ToString()
            {
                var fg = new FileGeneration();
                ToString(fg, null);
                return fg.ToString();
            }

            public override void ToString(FileGeneration fg, string? name = null)
            {
                fg.AppendLine($"{(name ?? "ErrorMask")} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (this.Overall != null)
                    {
                        fg.AppendLine("Overall =>");
                        fg.AppendLine("[");
                        using (new DepthWrapper(fg))
                        {
                            fg.AppendLine($"{this.Overall}");
                        }
                        fg.AppendLine("]");
                    }
                    ToString_FillInternal(fg);
                }
                fg.AppendLine("]");
            }
            protected override void ToString_FillInternal(FileGeneration fg)
            {
                base.ToString_FillInternal(fg);
                fg.AppendItem(RawOwnerData, "RawOwnerData");
                fg.AppendItem(RawVariableData, "RawVariableData");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.RawOwnerData = this.RawOwnerData.Combine(rhs.RawOwnerData);
                ret.RawVariableData = this.RawVariableData.Combine(rhs.RawVariableData);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static new ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public new class TranslationMask :
            OwnerTarget.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool RawOwnerData;
            public bool RawVariableData;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.RawOwnerData = defaultOn;
                this.RawVariableData = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((RawOwnerData, null));
                ret.Add((RawVariableData, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => NoOwnerBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((NoOwnerBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public new static NoOwner CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new NoOwner();
            ((NoOwnerSetterCommon)((INoOwnerGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out NoOwner item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var startPos = frame.Position;
            item = CreateFromBinary(frame, recordTypeConverter);
            return startPos != frame.Position;
        }
        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        void IClearable.Clear()
        {
            ((NoOwnerSetterCommon)((INoOwnerGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new NoOwner GetNew()
        {
            return new NoOwner();
        }

    }
    #endregion

    #region Interface
    public partial interface INoOwner :
        INoOwnerGetter,
        IOwnerTarget,
        ILoquiObjectSetter<INoOwner>
    {
        new UInt32 RawOwnerData { get; set; }
        new UInt32 RawVariableData { get; set; }
    }

    public partial interface INoOwnerGetter :
        IOwnerTargetGetter,
        ILoquiObject<INoOwnerGetter>,
        IBinaryItem
    {
        static new ILoquiRegistration Registration => NoOwner_Registration.Instance;
        UInt32 RawOwnerData { get; }
        UInt32 RawVariableData { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class NoOwnerMixIn
    {
        public static void Clear(this INoOwner item)
        {
            ((NoOwnerSetterCommon)((INoOwnerGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static NoOwner.Mask<bool> GetEqualsMask(
            this INoOwnerGetter item,
            INoOwnerGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this INoOwnerGetter item,
            string? name = null,
            NoOwner.Mask<bool>? printMask = null)
        {
            return ((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this INoOwnerGetter item,
            FileGeneration fg,
            string? name = null,
            NoOwner.Mask<bool>? printMask = null)
        {
            ((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this INoOwnerGetter item,
            INoOwnerGetter rhs)
        {
            return ((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs);
        }

        public static void DeepCopyIn(
            this INoOwner lhs,
            INoOwnerGetter rhs,
            out NoOwner.ErrorMask errorMask,
            NoOwner.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = NoOwner.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this INoOwner lhs,
            INoOwnerGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static NoOwner DeepCopy(
            this INoOwnerGetter item,
            NoOwner.TranslationMask? copyMask = null)
        {
            return ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static NoOwner DeepCopy(
            this INoOwnerGetter item,
            out NoOwner.ErrorMask errorMask,
            NoOwner.TranslationMask? copyMask = null)
        {
            return ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static NoOwner DeepCopy(
            this INoOwnerGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this INoOwner item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((NoOwnerSetterCommon)((INoOwnerGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Fallout4.Internals
{
    #region Field Index
    public enum NoOwner_FieldIndex
    {
        RawOwnerData = 0,
        RawVariableData = 1,
    }
    #endregion

    #region Registration
    public partial class NoOwner_Registration : ILoquiRegistration
    {
        public static readonly NoOwner_Registration Instance = new NoOwner_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 177,
            version: 0);

        public const string GUID = "84fd4617-ba7a-42a8-8e61-2e86f7f8af94";

        public const ushort AdditionalFieldCount = 2;

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(NoOwner.Mask<>);

        public static readonly Type ErrorMaskType = typeof(NoOwner.ErrorMask);

        public static readonly Type ClassType = typeof(NoOwner);

        public static readonly Type GetterType = typeof(INoOwnerGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(INoOwner);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.NoOwner";

        public const string Name = "NoOwner";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(NoOwnerBinaryWriteTranslation);
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        ushort ILoquiRegistration.FieldCount => FieldCount;
        ushort ILoquiRegistration.AdditionalFieldCount => AdditionalFieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type? ILoquiRegistration.InternalSetterType => InternalSetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type? ILoquiRegistration.InternalGetterType => InternalGetterType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type? ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => throw new NotImplementedException();
        string ILoquiRegistration.GetNthName(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsNthDerivative(ushort index) => throw new NotImplementedException();
        bool ILoquiRegistration.IsProtected(ushort index) => throw new NotImplementedException();
        Type ILoquiRegistration.GetNthType(ushort index) => throw new NotImplementedException();
        #endregion

    }
    #endregion

    #region Common
    public partial class NoOwnerSetterCommon : OwnerTargetSetterCommon
    {
        public new static readonly NoOwnerSetterCommon Instance = new NoOwnerSetterCommon();

        partial void ClearPartial();
        
        public void Clear(INoOwner item)
        {
            ClearPartial();
            item.RawOwnerData = default;
            item.RawVariableData = default;
            base.Clear(item);
        }
        
        public override void Clear(IOwnerTarget item)
        {
            Clear(item: (INoOwner)item);
        }
        
        #region Mutagen
        public void RemapLinks(INoOwner obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            INoOwner item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: NoOwnerBinaryCreateTranslation.FillBinaryStructs);
        }
        
        public override void CopyInFromBinary(
            IOwnerTarget item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (NoOwner)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class NoOwnerCommon : OwnerTargetCommon
    {
        public new static readonly NoOwnerCommon Instance = new NoOwnerCommon();

        public NoOwner.Mask<bool> GetEqualsMask(
            INoOwnerGetter item,
            INoOwnerGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new NoOwner.Mask<bool>(false);
            ((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            INoOwnerGetter item,
            INoOwnerGetter rhs,
            NoOwner.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.RawOwnerData = item.RawOwnerData == rhs.RawOwnerData;
            ret.RawVariableData = item.RawVariableData == rhs.RawVariableData;
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            INoOwnerGetter item,
            string? name = null,
            NoOwner.Mask<bool>? printMask = null)
        {
            var fg = new FileGeneration();
            ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
            return fg.ToString();
        }
        
        public void ToString(
            INoOwnerGetter item,
            FileGeneration fg,
            string? name = null,
            NoOwner.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"NoOwner =>");
            }
            else
            {
                fg.AppendLine($"{name} (NoOwner) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                ToStringFields(
                    item: item,
                    fg: fg,
                    printMask: printMask);
            }
            fg.AppendLine("]");
        }
        
        protected static void ToStringFields(
            INoOwnerGetter item,
            FileGeneration fg,
            NoOwner.Mask<bool>? printMask = null)
        {
            OwnerTargetCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
            if (printMask?.RawOwnerData ?? true)
            {
                fg.AppendItem(item.RawOwnerData, "RawOwnerData");
            }
            if (printMask?.RawVariableData ?? true)
            {
                fg.AppendItem(item.RawVariableData, "RawVariableData");
            }
        }
        
        public static NoOwner_FieldIndex ConvertFieldIndex(OwnerTarget_FieldIndex index)
        {
            switch (index)
            {
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            INoOwnerGetter? lhs,
            INoOwnerGetter? rhs)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!base.Equals((IOwnerTargetGetter)lhs, (IOwnerTargetGetter)rhs)) return false;
            if (lhs.RawOwnerData != rhs.RawOwnerData) return false;
            if (lhs.RawVariableData != rhs.RawVariableData) return false;
            return true;
        }
        
        public override bool Equals(
            IOwnerTargetGetter? lhs,
            IOwnerTargetGetter? rhs)
        {
            return Equals(
                lhs: (INoOwnerGetter?)lhs,
                rhs: rhs as INoOwnerGetter);
        }
        
        public virtual int GetHashCode(INoOwnerGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.RawOwnerData);
            hash.Add(item.RawVariableData);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IOwnerTargetGetter item)
        {
            return GetHashCode(item: (INoOwnerGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return NoOwner.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormLinkInformation> GetContainedFormLinks(INoOwnerGetter obj)
        {
            foreach (var item in base.GetContainedFormLinks(obj))
            {
                yield return item;
            }
            yield break;
        }
        
        #endregion
        
    }
    public partial class NoOwnerSetterTranslationCommon : OwnerTargetSetterTranslationCommon
    {
        public new static readonly NoOwnerSetterTranslationCommon Instance = new NoOwnerSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            INoOwner item,
            INoOwnerGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IOwnerTarget)item,
                (IOwnerTargetGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)NoOwner_FieldIndex.RawOwnerData) ?? true))
            {
                item.RawOwnerData = rhs.RawOwnerData;
            }
            if ((copyMask?.GetShouldTranslate((int)NoOwner_FieldIndex.RawVariableData) ?? true))
            {
                item.RawVariableData = rhs.RawVariableData;
            }
        }
        
        
        public override void DeepCopyIn(
            IOwnerTarget item,
            IOwnerTargetGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (INoOwner)item,
                rhs: (INoOwnerGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public NoOwner DeepCopy(
            INoOwnerGetter item,
            NoOwner.TranslationMask? copyMask = null)
        {
            NoOwner ret = (NoOwner)((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).GetNew();
            ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public NoOwner DeepCopy(
            INoOwnerGetter item,
            out NoOwner.ErrorMask errorMask,
            NoOwner.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            NoOwner ret = (NoOwner)((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).GetNew();
            ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = NoOwner.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public NoOwner DeepCopy(
            INoOwnerGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            NoOwner ret = (NoOwner)((NoOwnerCommon)((INoOwnerGetter)item).CommonInstance()!).GetNew();
            ((NoOwnerSetterTranslationCommon)((INoOwnerGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: true);
            return ret;
        }
        
    }
    #endregion

}

namespace Mutagen.Bethesda.Fallout4
{
    public partial class NoOwner
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => NoOwner_Registration.Instance;
        public new static NoOwner_Registration Registration => NoOwner_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => NoOwnerCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return NoOwnerSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => NoOwnerSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class NoOwnerBinaryWriteTranslation :
        OwnerTargetBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static NoOwnerBinaryWriteTranslation Instance = new NoOwnerBinaryWriteTranslation();

        public static void WriteEmbedded(
            INoOwnerGetter item,
            MutagenWriter writer)
        {
            writer.Write(item.RawOwnerData);
            writer.Write(item.RawVariableData);
        }

        public void Write(
            MutagenWriter writer,
            INoOwnerGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            WriteEmbedded(
                item: item,
                writer: writer);
        }

        public override void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (INoOwnerGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IOwnerTargetGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (INoOwnerGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class NoOwnerBinaryCreateTranslation : OwnerTargetBinaryCreateTranslation
    {
        public new readonly static NoOwnerBinaryCreateTranslation Instance = new NoOwnerBinaryCreateTranslation();

        public static void FillBinaryStructs(
            INoOwner item,
            MutagenFrame frame)
        {
            item.RawOwnerData = frame.ReadUInt32();
            item.RawVariableData = frame.ReadUInt32();
        }

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class NoOwnerBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class NoOwnerBinaryOverlay :
        OwnerTargetBinaryOverlay,
        INoOwnerGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => NoOwner_Registration.Instance;
        public new static NoOwner_Registration Registration => NoOwner_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => NoOwnerCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => NoOwnerSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => NoOwnerBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((NoOwnerBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public UInt32 RawOwnerData => BinaryPrimitives.ReadUInt32LittleEndian(_data.Slice(0x0, 0x4));
        public UInt32 RawVariableData => BinaryPrimitives.ReadUInt32LittleEndian(_data.Slice(0x4, 0x4));
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected NoOwnerBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static NoOwnerBinaryOverlay NoOwnerFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new NoOwnerBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x8),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x8;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static NoOwnerBinaryOverlay NoOwnerFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return NoOwnerFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            NoOwnerMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is INoOwnerGetter rhs)) return false;
            return ((NoOwnerCommon)((INoOwnerGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(INoOwnerGetter? obj)
        {
            return ((NoOwnerCommon)((INoOwnerGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((NoOwnerCommon)((INoOwnerGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

