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
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Skyrim.Internals;
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
namespace Mutagen.Bethesda.Skyrim
{
    #region Class
    public partial class BookSpell :
        BookTeachTarget,
        IBookSpell,
        IEquatable<IBookSpellGetter>,
        ILoquiObjectSetter<BookSpell>
    {
        #region Ctor
        public BookSpell()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Spell
        public IFormLink<ISpellGetter> Spell { get; init; } = new FormLink<ISpellGetter>();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        IFormLinkGetter<ISpellGetter> IBookSpellGetter.Spell => this.Spell;
        #endregion

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            BookSpellMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is IBookSpellGetter rhs)) return false;
            return ((BookSpellCommon)((IBookSpellGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(IBookSpellGetter? obj)
        {
            return ((BookSpellCommon)((IBookSpellGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((BookSpellCommon)((IBookSpellGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public new class Mask<TItem> :
            BookTeachTarget.Mask<TItem>,
            IEquatable<Mask<TItem>>,
            IMask<TItem>
        {
            #region Ctors
            public Mask(TItem Spell)
            : base()
            {
                this.Spell = Spell;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Spell;
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
                if (!object.Equals(this.Spell, rhs.Spell)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Spell);
                hash.Add(base.GetHashCode());
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public override bool All(Func<TItem, bool> eval)
            {
                if (!base.All(eval)) return false;
                if (!eval(this.Spell)) return false;
                return true;
            }
            #endregion

            #region Any
            public override bool Any(Func<TItem, bool> eval)
            {
                if (base.Any(eval)) return true;
                if (eval(this.Spell)) return true;
                return false;
            }
            #endregion

            #region Translate
            public new Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new BookSpell.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                base.Translate_InternalFill(obj, eval);
                obj.Spell = eval(this.Spell);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(BookSpell.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, BookSpell.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(BookSpell.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Spell ?? true)
                    {
                        fg.AppendItem(Spell, "Spell");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public new class ErrorMask :
            BookTeachTarget.ErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Spell;
            #endregion

            #region IErrorMask
            public override object? GetNthMask(int index)
            {
                BookSpell_FieldIndex enu = (BookSpell_FieldIndex)index;
                switch (enu)
                {
                    case BookSpell_FieldIndex.Spell:
                        return Spell;
                    default:
                        return base.GetNthMask(index);
                }
            }

            public override void SetNthException(int index, Exception ex)
            {
                BookSpell_FieldIndex enu = (BookSpell_FieldIndex)index;
                switch (enu)
                {
                    case BookSpell_FieldIndex.Spell:
                        this.Spell = ex;
                        break;
                    default:
                        base.SetNthException(index, ex);
                        break;
                }
            }

            public override void SetNthMask(int index, object obj)
            {
                BookSpell_FieldIndex enu = (BookSpell_FieldIndex)index;
                switch (enu)
                {
                    case BookSpell_FieldIndex.Spell:
                        this.Spell = (Exception?)obj;
                        break;
                    default:
                        base.SetNthMask(index, obj);
                        break;
                }
            }

            public override bool IsInError()
            {
                if (Overall != null) return true;
                if (Spell != null) return true;
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
                fg.AppendItem(Spell, "Spell");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Spell = this.Spell.Combine(rhs.Spell);
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
            BookTeachTarget.TranslationMask,
            ITranslationMask
        {
            #region Members
            public bool Spell;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
                : base(defaultOn, onOverall)
            {
                this.Spell = defaultOn;
            }

            #endregion

            protected override void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                base.GetCrystal(ret);
                ret.Add((Spell, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Mutagen
        public override IEnumerable<FormLinkInformation> ContainedFormLinks => BookSpellCommon.Instance.GetContainedFormLinks(this);
        public override void RemapLinks(IReadOnlyDictionary<FormKey, FormKey> mapping) => BookSpellSetterCommon.Instance.RemapLinks(this, mapping);
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => BookSpellBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((BookSpellBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public new static BookSpell CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new BookSpell();
            ((BookSpellSetterCommon)((IBookSpellGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out BookSpell item,
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
            ((BookSpellSetterCommon)((IBookSpellGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static new BookSpell GetNew()
        {
            return new BookSpell();
        }

    }
    #endregion

    #region Interface
    public partial interface IBookSpell :
        IBookSpellGetter,
        IBookTeachTarget,
        IFormLinkContainer,
        ILoquiObjectSetter<IBookSpell>
    {
        new IFormLink<ISpellGetter> Spell { get; }
    }

    public partial interface IBookSpellGetter :
        IBookTeachTargetGetter,
        IBinaryItem,
        IFormLinkContainerGetter,
        ILoquiObject<IBookSpellGetter>
    {
        static new ILoquiRegistration Registration => BookSpell_Registration.Instance;
        IFormLinkGetter<ISpellGetter> Spell { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class BookSpellMixIn
    {
        public static void Clear(this IBookSpell item)
        {
            ((BookSpellSetterCommon)((IBookSpellGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static BookSpell.Mask<bool> GetEqualsMask(
            this IBookSpellGetter item,
            IBookSpellGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this IBookSpellGetter item,
            string? name = null,
            BookSpell.Mask<bool>? printMask = null)
        {
            return ((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this IBookSpellGetter item,
            FileGeneration fg,
            string? name = null,
            BookSpell.Mask<bool>? printMask = null)
        {
            ((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this IBookSpellGetter item,
            IBookSpellGetter rhs)
        {
            return ((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs);
        }

        public static void DeepCopyIn(
            this IBookSpell lhs,
            IBookSpellGetter rhs,
            out BookSpell.ErrorMask errorMask,
            BookSpell.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((BookSpellSetterTranslationCommon)((IBookSpellGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = BookSpell.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this IBookSpell lhs,
            IBookSpellGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((BookSpellSetterTranslationCommon)((IBookSpellGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static BookSpell DeepCopy(
            this IBookSpellGetter item,
            BookSpell.TranslationMask? copyMask = null)
        {
            return ((BookSpellSetterTranslationCommon)((IBookSpellGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static BookSpell DeepCopy(
            this IBookSpellGetter item,
            out BookSpell.ErrorMask errorMask,
            BookSpell.TranslationMask? copyMask = null)
        {
            return ((BookSpellSetterTranslationCommon)((IBookSpellGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static BookSpell DeepCopy(
            this IBookSpellGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((BookSpellSetterTranslationCommon)((IBookSpellGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this IBookSpell item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((BookSpellSetterCommon)((IBookSpellGetter)item).CommonSetterInstance()!).CopyInFromBinary(
                item: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }

        #endregion

    }
    #endregion

}

namespace Mutagen.Bethesda.Skyrim.Internals
{
    #region Field Index
    public enum BookSpell_FieldIndex
    {
        Spell = 0,
    }
    #endregion

    #region Registration
    public partial class BookSpell_Registration : ILoquiRegistration
    {
        public static readonly BookSpell_Registration Instance = new BookSpell_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Skyrim.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Skyrim.ProtocolKey,
            msgID: 158,
            version: 0);

        public const string GUID = "fef00688-7772-4c2a-894c-7748d1688013";

        public const ushort AdditionalFieldCount = 1;

        public const ushort FieldCount = 1;

        public static readonly Type MaskType = typeof(BookSpell.Mask<>);

        public static readonly Type ErrorMaskType = typeof(BookSpell.ErrorMask);

        public static readonly Type ClassType = typeof(BookSpell);

        public static readonly Type GetterType = typeof(IBookSpellGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(IBookSpell);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Skyrim.BookSpell";

        public const string Name = "BookSpell";

        public const string Namespace = "Mutagen.Bethesda.Skyrim";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly Type BinaryWriteTranslation = typeof(BookSpellBinaryWriteTranslation);
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
    public partial class BookSpellSetterCommon : BookTeachTargetSetterCommon
    {
        public new static readonly BookSpellSetterCommon Instance = new BookSpellSetterCommon();

        partial void ClearPartial();
        
        public void Clear(IBookSpell item)
        {
            ClearPartial();
            item.Spell.Clear();
            base.Clear(item);
        }
        
        public override void Clear(IBookTeachTarget item)
        {
            Clear(item: (IBookSpell)item);
        }
        
        #region Mutagen
        public void RemapLinks(IBookSpell obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
            base.RemapLinks(obj, mapping);
            obj.Spell.Relink(mapping);
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            IBookSpell item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: BookSpellBinaryCreateTranslation.FillBinaryStructs);
        }
        
        public override void CopyInFromBinary(
            IBookTeachTarget item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            CopyInFromBinary(
                item: (BookSpell)item,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
        }
        
        #endregion
        
    }
    public partial class BookSpellCommon : BookTeachTargetCommon
    {
        public new static readonly BookSpellCommon Instance = new BookSpellCommon();

        public BookSpell.Mask<bool> GetEqualsMask(
            IBookSpellGetter item,
            IBookSpellGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new BookSpell.Mask<bool>(false);
            ((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            IBookSpellGetter item,
            IBookSpellGetter rhs,
            BookSpell.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Spell = item.Spell.Equals(rhs.Spell);
            base.FillEqualsMask(item, rhs, ret, include);
        }
        
        public string ToString(
            IBookSpellGetter item,
            string? name = null,
            BookSpell.Mask<bool>? printMask = null)
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
            IBookSpellGetter item,
            FileGeneration fg,
            string? name = null,
            BookSpell.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"BookSpell =>");
            }
            else
            {
                fg.AppendLine($"{name} (BookSpell) =>");
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
            IBookSpellGetter item,
            FileGeneration fg,
            BookSpell.Mask<bool>? printMask = null)
        {
            BookTeachTargetCommon.ToStringFields(
                item: item,
                fg: fg,
                printMask: printMask);
            if (printMask?.Spell ?? true)
            {
                fg.AppendItem(item.Spell.FormKey, "Spell");
            }
        }
        
        public static BookSpell_FieldIndex ConvertFieldIndex(BookTeachTarget_FieldIndex index)
        {
            switch (index)
            {
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            IBookSpellGetter? lhs,
            IBookSpellGetter? rhs)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!base.Equals((IBookTeachTargetGetter)lhs, (IBookTeachTargetGetter)rhs)) return false;
            if (!lhs.Spell.Equals(rhs.Spell)) return false;
            return true;
        }
        
        public override bool Equals(
            IBookTeachTargetGetter? lhs,
            IBookTeachTargetGetter? rhs)
        {
            return Equals(
                lhs: (IBookSpellGetter?)lhs,
                rhs: rhs as IBookSpellGetter);
        }
        
        public virtual int GetHashCode(IBookSpellGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Spell);
            hash.Add(base.GetHashCode());
            return hash.ToHashCode();
        }
        
        public override int GetHashCode(IBookTeachTargetGetter item)
        {
            return GetHashCode(item: (IBookSpellGetter)item);
        }
        
        #endregion
        
        
        public override object GetNew()
        {
            return BookSpell.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormLinkInformation> GetContainedFormLinks(IBookSpellGetter obj)
        {
            foreach (var item in base.GetContainedFormLinks(obj))
            {
                yield return item;
            }
            yield return FormLinkInformation.Factory(obj.Spell);
            yield break;
        }
        
        #endregion
        
    }
    public partial class BookSpellSetterTranslationCommon : BookTeachTargetSetterTranslationCommon
    {
        public new static readonly BookSpellSetterTranslationCommon Instance = new BookSpellSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            IBookSpell item,
            IBookSpellGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            base.DeepCopyIn(
                (IBookTeachTarget)item,
                (IBookTeachTargetGetter)rhs,
                errorMask,
                copyMask,
                deepCopy: deepCopy);
            if ((copyMask?.GetShouldTranslate((int)BookSpell_FieldIndex.Spell) ?? true))
            {
                item.Spell.SetTo(rhs.Spell);
            }
        }
        
        
        public override void DeepCopyIn(
            IBookTeachTarget item,
            IBookTeachTargetGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            this.DeepCopyIn(
                item: (IBookSpell)item,
                rhs: (IBookSpellGetter)rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: deepCopy);
        }
        
        #endregion
        
        public BookSpell DeepCopy(
            IBookSpellGetter item,
            BookSpell.TranslationMask? copyMask = null)
        {
            BookSpell ret = (BookSpell)((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).GetNew();
            ((BookSpellSetterTranslationCommon)((IBookSpellGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public BookSpell DeepCopy(
            IBookSpellGetter item,
            out BookSpell.ErrorMask errorMask,
            BookSpell.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            BookSpell ret = (BookSpell)((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).GetNew();
            ((BookSpellSetterTranslationCommon)((IBookSpellGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = BookSpell.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public BookSpell DeepCopy(
            IBookSpellGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            BookSpell ret = (BookSpell)((BookSpellCommon)((IBookSpellGetter)item).CommonInstance()!).GetNew();
            ((BookSpellSetterTranslationCommon)((IBookSpellGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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

namespace Mutagen.Bethesda.Skyrim
{
    public partial class BookSpell
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => BookSpell_Registration.Instance;
        public new static BookSpell_Registration Registration => BookSpell_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => BookSpellCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterInstance()
        {
            return BookSpellSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => BookSpellSetterTranslationCommon.Instance;

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class BookSpellBinaryWriteTranslation :
        BookTeachTargetBinaryWriteTranslation,
        IBinaryWriteTranslator
    {
        public new readonly static BookSpellBinaryWriteTranslation Instance = new BookSpellBinaryWriteTranslation();

        public static void WriteEmbedded(
            IBookSpellGetter item,
            MutagenWriter writer)
        {
            Mutagen.Bethesda.Binary.FormLinkBinaryTranslation.Instance.Write(
                writer: writer,
                item: item.Spell);
        }

        public void Write(
            MutagenWriter writer,
            IBookSpellGetter item,
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
                item: (IBookSpellGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public override void Write(
            MutagenWriter writer,
            IBookTeachTargetGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (IBookSpellGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class BookSpellBinaryCreateTranslation : BookTeachTargetBinaryCreateTranslation
    {
        public new readonly static BookSpellBinaryCreateTranslation Instance = new BookSpellBinaryCreateTranslation();

        public static void FillBinaryStructs(
            IBookSpell item,
            MutagenFrame frame)
        {
            item.Spell.SetTo(
                Mutagen.Bethesda.Binary.FormLinkBinaryTranslation.Instance.Parse(
                    frame: frame,
                    defaultVal: FormKey.Null));
        }

    }

}
namespace Mutagen.Bethesda.Skyrim
{
    #region Binary Write Mixins
    public static class BookSpellBinaryTranslationMixIn
    {
    }
    #endregion


}
namespace Mutagen.Bethesda.Skyrim.Internals
{
    public partial class BookSpellBinaryOverlay :
        BookTeachTargetBinaryOverlay,
        IBookSpellGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => BookSpell_Registration.Instance;
        public new static BookSpell_Registration Registration => BookSpell_Registration.Instance;
        [DebuggerStepThrough]
        protected override object CommonInstance() => BookSpellCommon.Instance;
        [DebuggerStepThrough]
        protected override object CommonSetterTranslationInstance() => BookSpellSetterTranslationCommon.Instance;

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        public override IEnumerable<FormLinkInformation> ContainedFormLinks => BookSpellCommon.Instance.GetContainedFormLinks(this);
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected override object BinaryWriteTranslator => BookSpellBinaryWriteTranslation.Instance;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((BookSpellBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public IFormLinkGetter<ISpellGetter> Spell => new FormLink<ISpellGetter>(FormKey.Factory(_package.MetaData.MasterReferences!, BinaryPrimitives.ReadUInt32LittleEndian(_data.Span.Slice(0x0, 0x4))));
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected BookSpellBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static BookSpellBinaryOverlay BookSpellFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new BookSpellBinaryOverlay(
                bytes: stream.RemainingMemory.Slice(0, 0x4),
                package: package);
            int offset = stream.Position;
            stream.Position += 0x4;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static BookSpellBinaryOverlay BookSpellFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return BookSpellFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public override void ToString(
            FileGeneration fg,
            string? name = null)
        {
            BookSpellMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is IBookSpellGetter rhs)) return false;
            return ((BookSpellCommon)((IBookSpellGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(IBookSpellGetter? obj)
        {
            return ((BookSpellCommon)((IBookSpellGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((BookSpellCommon)((IBookSpellGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

