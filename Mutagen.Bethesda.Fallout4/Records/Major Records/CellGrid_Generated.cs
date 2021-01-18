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
    public partial class CellGrid :
        ICellGrid,
        ILoquiObjectSetter<CellGrid>,
        IEquatable<ICellGridGetter>
    {
        #region Ctor
        public CellGrid()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion

        #region Point
        public P2Int Point { get; set; } = default;
        #endregion
        #region Flags
        public CellGrid.Flag Flags { get; set; } = default;
        #endregion

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            CellGridMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is ICellGridGetter rhs)) return false;
            return ((CellGridCommon)((ICellGridGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(ICellGridGetter? obj)
        {
            return ((CellGridCommon)((ICellGridGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((CellGridCommon)((ICellGridGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

        #region Mask
        public class Mask<TItem> :
            IMask<TItem>,
            IEquatable<Mask<TItem>>
        {
            #region Ctors
            public Mask(TItem initialValue)
            {
                this.Point = initialValue;
                this.Flags = initialValue;
            }

            public Mask(
                TItem Point,
                TItem Flags)
            {
                this.Point = Point;
                this.Flags = Flags;
            }

            #pragma warning disable CS8618
            protected Mask()
            {
            }
            #pragma warning restore CS8618

            #endregion

            #region Members
            public TItem Point;
            public TItem Flags;
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
                if (!object.Equals(this.Point, rhs.Point)) return false;
                if (!object.Equals(this.Flags, rhs.Flags)) return false;
                return true;
            }
            public override int GetHashCode()
            {
                var hash = new HashCode();
                hash.Add(this.Point);
                hash.Add(this.Flags);
                return hash.ToHashCode();
            }

            #endregion

            #region All
            public bool All(Func<TItem, bool> eval)
            {
                if (!eval(this.Point)) return false;
                if (!eval(this.Flags)) return false;
                return true;
            }
            #endregion

            #region Any
            public bool Any(Func<TItem, bool> eval)
            {
                if (eval(this.Point)) return true;
                if (eval(this.Flags)) return true;
                return false;
            }
            #endregion

            #region Translate
            public Mask<R> Translate<R>(Func<TItem, R> eval)
            {
                var ret = new CellGrid.Mask<R>();
                this.Translate_InternalFill(ret, eval);
                return ret;
            }

            protected void Translate_InternalFill<R>(Mask<R> obj, Func<TItem, R> eval)
            {
                obj.Point = eval(this.Point);
                obj.Flags = eval(this.Flags);
            }
            #endregion

            #region To String
            public override string ToString()
            {
                return ToString(printMask: null);
            }

            public string ToString(CellGrid.Mask<bool>? printMask = null)
            {
                var fg = new FileGeneration();
                ToString(fg, printMask);
                return fg.ToString();
            }

            public void ToString(FileGeneration fg, CellGrid.Mask<bool>? printMask = null)
            {
                fg.AppendLine($"{nameof(CellGrid.Mask<TItem>)} =>");
                fg.AppendLine("[");
                using (new DepthWrapper(fg))
                {
                    if (printMask?.Point ?? true)
                    {
                        fg.AppendItem(Point, "Point");
                    }
                    if (printMask?.Flags ?? true)
                    {
                        fg.AppendItem(Flags, "Flags");
                    }
                }
                fg.AppendLine("]");
            }
            #endregion

        }

        public class ErrorMask :
            IErrorMask,
            IErrorMask<ErrorMask>
        {
            #region Members
            public Exception? Overall { get; set; }
            private List<string>? _warnings;
            public List<string> Warnings
            {
                get
                {
                    if (_warnings == null)
                    {
                        _warnings = new List<string>();
                    }
                    return _warnings;
                }
            }
            public Exception? Point;
            public Exception? Flags;
            #endregion

            #region IErrorMask
            public object? GetNthMask(int index)
            {
                CellGrid_FieldIndex enu = (CellGrid_FieldIndex)index;
                switch (enu)
                {
                    case CellGrid_FieldIndex.Point:
                        return Point;
                    case CellGrid_FieldIndex.Flags:
                        return Flags;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthException(int index, Exception ex)
            {
                CellGrid_FieldIndex enu = (CellGrid_FieldIndex)index;
                switch (enu)
                {
                    case CellGrid_FieldIndex.Point:
                        this.Point = ex;
                        break;
                    case CellGrid_FieldIndex.Flags:
                        this.Flags = ex;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public void SetNthMask(int index, object obj)
            {
                CellGrid_FieldIndex enu = (CellGrid_FieldIndex)index;
                switch (enu)
                {
                    case CellGrid_FieldIndex.Point:
                        this.Point = (Exception?)obj;
                        break;
                    case CellGrid_FieldIndex.Flags:
                        this.Flags = (Exception?)obj;
                        break;
                    default:
                        throw new ArgumentException($"Index is out of range: {index}");
                }
            }

            public bool IsInError()
            {
                if (Overall != null) return true;
                if (Point != null) return true;
                if (Flags != null) return true;
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

            public void ToString(FileGeneration fg, string? name = null)
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
            protected void ToString_FillInternal(FileGeneration fg)
            {
                fg.AppendItem(Point, "Point");
                fg.AppendItem(Flags, "Flags");
            }
            #endregion

            #region Combine
            public ErrorMask Combine(ErrorMask? rhs)
            {
                if (rhs == null) return this;
                var ret = new ErrorMask();
                ret.Point = this.Point.Combine(rhs.Point);
                ret.Flags = this.Flags.Combine(rhs.Flags);
                return ret;
            }
            public static ErrorMask? Combine(ErrorMask? lhs, ErrorMask? rhs)
            {
                if (lhs != null && rhs != null) return lhs.Combine(rhs);
                return lhs ?? rhs;
            }
            #endregion

            #region Factory
            public static ErrorMask Factory(ErrorMaskBuilder errorMask)
            {
                return new ErrorMask();
            }
            #endregion

        }
        public class TranslationMask : ITranslationMask
        {
            #region Members
            private TranslationCrystal? _crystal;
            public readonly bool DefaultOn;
            public bool OnOverall;
            public bool Point;
            public bool Flags;
            #endregion

            #region Ctors
            public TranslationMask(
                bool defaultOn,
                bool onOverall = true)
            {
                this.DefaultOn = defaultOn;
                this.OnOverall = onOverall;
                this.Point = defaultOn;
                this.Flags = defaultOn;
            }

            #endregion

            public TranslationCrystal GetCrystal()
            {
                if (_crystal != null) return _crystal;
                var ret = new List<(bool On, TranslationCrystal? SubCrystal)>();
                GetCrystal(ret);
                _crystal = new TranslationCrystal(ret.ToArray());
                return _crystal;
            }

            protected void GetCrystal(List<(bool On, TranslationCrystal? SubCrystal)> ret)
            {
                ret.Add((Point, null));
                ret.Add((Flags, null));
            }

            public static implicit operator TranslationMask(bool defaultOn)
            {
                return new TranslationMask(defaultOn: defaultOn, onOverall: defaultOn);
            }

        }
        #endregion

        #region Mutagen
        public static readonly RecordType GrupRecordType = CellGrid_Registration.TriggeringRecordType;
        #endregion

        #region Binary Translation
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => CellGridBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((CellGridBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }
        #region Binary Create
        public static CellGrid CreateFromBinary(
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new CellGrid();
            ((CellGridSetterCommon)((ICellGridGetter)ret).CommonSetterInstance()!).CopyInFromBinary(
                item: ret,
                frame: frame,
                recordTypeConverter: recordTypeConverter);
            return ret;
        }

        #endregion

        public static bool TryCreateFromBinary(
            MutagenFrame frame,
            out CellGrid item,
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
            ((CellGridSetterCommon)((ICellGridGetter)this).CommonSetterInstance()!).Clear(this);
        }

        internal static CellGrid GetNew()
        {
            return new CellGrid();
        }

    }
    #endregion

    #region Interface
    public partial interface ICellGrid :
        ICellGridGetter,
        ILoquiObjectSetter<ICellGrid>
    {
        new P2Int Point { get; set; }
        new CellGrid.Flag Flags { get; set; }
    }

    public partial interface ICellGridGetter :
        ILoquiObject,
        ILoquiObject<ICellGridGetter>,
        IBinaryItem
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object? CommonSetterInstance();
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        object CommonSetterTranslationInstance();
        static ILoquiRegistration Registration => CellGrid_Registration.Instance;
        P2Int Point { get; }
        CellGrid.Flag Flags { get; }

    }

    #endregion

    #region Common MixIn
    public static partial class CellGridMixIn
    {
        public static void Clear(this ICellGrid item)
        {
            ((CellGridSetterCommon)((ICellGridGetter)item).CommonSetterInstance()!).Clear(item: item);
        }

        public static CellGrid.Mask<bool> GetEqualsMask(
            this ICellGridGetter item,
            ICellGridGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            return ((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).GetEqualsMask(
                item: item,
                rhs: rhs,
                include: include);
        }

        public static string ToString(
            this ICellGridGetter item,
            string? name = null,
            CellGrid.Mask<bool>? printMask = null)
        {
            return ((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).ToString(
                item: item,
                name: name,
                printMask: printMask);
        }

        public static void ToString(
            this ICellGridGetter item,
            FileGeneration fg,
            string? name = null,
            CellGrid.Mask<bool>? printMask = null)
        {
            ((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).ToString(
                item: item,
                fg: fg,
                name: name,
                printMask: printMask);
        }

        public static bool Equals(
            this ICellGridGetter item,
            ICellGridGetter rhs)
        {
            return ((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).Equals(
                lhs: item,
                rhs: rhs);
        }

        public static void DeepCopyIn(
            this ICellGrid lhs,
            ICellGridGetter rhs)
        {
            ((CellGridSetterTranslationCommon)((ICellGridGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: default,
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this ICellGrid lhs,
            ICellGridGetter rhs,
            CellGrid.TranslationMask? copyMask = null)
        {
            ((CellGridSetterTranslationCommon)((ICellGridGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: default,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
        }

        public static void DeepCopyIn(
            this ICellGrid lhs,
            ICellGridGetter rhs,
            out CellGrid.ErrorMask errorMask,
            CellGrid.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            ((CellGridSetterTranslationCommon)((ICellGridGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: false);
            errorMask = CellGrid.ErrorMask.Factory(errorMaskBuilder);
        }

        public static void DeepCopyIn(
            this ICellGrid lhs,
            ICellGridGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask)
        {
            ((CellGridSetterTranslationCommon)((ICellGridGetter)lhs).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: lhs,
                rhs: rhs,
                errorMask: errorMask,
                copyMask: copyMask,
                deepCopy: false);
        }

        public static CellGrid DeepCopy(
            this ICellGridGetter item,
            CellGrid.TranslationMask? copyMask = null)
        {
            return ((CellGridSetterTranslationCommon)((ICellGridGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask);
        }

        public static CellGrid DeepCopy(
            this ICellGridGetter item,
            out CellGrid.ErrorMask errorMask,
            CellGrid.TranslationMask? copyMask = null)
        {
            return ((CellGridSetterTranslationCommon)((ICellGridGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: out errorMask);
        }

        public static CellGrid DeepCopy(
            this ICellGridGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            return ((CellGridSetterTranslationCommon)((ICellGridGetter)item).CommonSetterTranslationInstance()!).DeepCopy(
                item: item,
                copyMask: copyMask,
                errorMask: errorMask);
        }

        #region Binary Translation
        public static void CopyInFromBinary(
            this ICellGrid item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((CellGridSetterCommon)((ICellGridGetter)item).CommonSetterInstance()!).CopyInFromBinary(
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
    public enum CellGrid_FieldIndex
    {
        Point = 0,
        Flags = 1,
    }
    #endregion

    #region Registration
    public partial class CellGrid_Registration : ILoquiRegistration
    {
        public static readonly CellGrid_Registration Instance = new CellGrid_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Fallout4.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Fallout4.ProtocolKey,
            msgID: 283,
            version: 0);

        public const string GUID = "c2bbbc23-29b3-49d3-8ed4-623753703bae";

        public const ushort AdditionalFieldCount = 2;

        public const ushort FieldCount = 2;

        public static readonly Type MaskType = typeof(CellGrid.Mask<>);

        public static readonly Type ErrorMaskType = typeof(CellGrid.ErrorMask);

        public static readonly Type ClassType = typeof(CellGrid);

        public static readonly Type GetterType = typeof(ICellGridGetter);

        public static readonly Type? InternalGetterType = null;

        public static readonly Type SetterType = typeof(ICellGrid);

        public static readonly Type? InternalSetterType = null;

        public const string FullName = "Mutagen.Bethesda.Fallout4.CellGrid";

        public const string Name = "CellGrid";

        public const string Namespace = "Mutagen.Bethesda.Fallout4";

        public const byte GenericCount = 0;

        public static readonly Type? GenericRegistrationType = null;

        public static readonly RecordType TriggeringRecordType = RecordTypes.XCLC;
        public static readonly Type BinaryWriteTranslation = typeof(CellGridBinaryWriteTranslation);
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
    public partial class CellGridSetterCommon
    {
        public static readonly CellGridSetterCommon Instance = new CellGridSetterCommon();

        partial void ClearPartial();
        
        public void Clear(ICellGrid item)
        {
            ClearPartial();
            item.Point = default;
            item.Flags = default;
        }
        
        #region Mutagen
        public void RemapLinks(ICellGrid obj, IReadOnlyDictionary<FormKey, FormKey> mapping)
        {
        }
        
        #endregion
        
        #region Binary Translation
        public virtual void CopyInFromBinary(
            ICellGrid item,
            MutagenFrame frame,
            RecordTypeConverter? recordTypeConverter = null)
        {
            frame = frame.SpawnWithFinalPosition(HeaderTranslation.ParseSubrecord(
                frame.Reader,
                recordTypeConverter.ConvertToCustom(RecordTypes.XCLC)));
            UtilityTranslation.SubrecordParse(
                record: item,
                frame: frame,
                recordTypeConverter: recordTypeConverter,
                fillStructs: CellGridBinaryCreateTranslation.FillBinaryStructs);
        }
        
        #endregion
        
    }
    public partial class CellGridCommon
    {
        public static readonly CellGridCommon Instance = new CellGridCommon();

        public CellGrid.Mask<bool> GetEqualsMask(
            ICellGridGetter item,
            ICellGridGetter rhs,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            var ret = new CellGrid.Mask<bool>(false);
            ((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).FillEqualsMask(
                item: item,
                rhs: rhs,
                ret: ret,
                include: include);
            return ret;
        }
        
        public void FillEqualsMask(
            ICellGridGetter item,
            ICellGridGetter rhs,
            CellGrid.Mask<bool> ret,
            EqualsMaskHelper.Include include = EqualsMaskHelper.Include.All)
        {
            if (rhs == null) return;
            ret.Point = item.Point.Equals(rhs.Point);
            ret.Flags = item.Flags == rhs.Flags;
        }
        
        public string ToString(
            ICellGridGetter item,
            string? name = null,
            CellGrid.Mask<bool>? printMask = null)
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
            ICellGridGetter item,
            FileGeneration fg,
            string? name = null,
            CellGrid.Mask<bool>? printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"CellGrid =>");
            }
            else
            {
                fg.AppendLine($"{name} (CellGrid) =>");
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
            ICellGridGetter item,
            FileGeneration fg,
            CellGrid.Mask<bool>? printMask = null)
        {
            if (printMask?.Point ?? true)
            {
                fg.AppendItem(item.Point, "Point");
            }
            if (printMask?.Flags ?? true)
            {
                fg.AppendItem(item.Flags, "Flags");
            }
        }
        
        #region Equals and Hash
        public virtual bool Equals(
            ICellGridGetter? lhs,
            ICellGridGetter? rhs)
        {
            if (lhs == null && rhs == null) return false;
            if (lhs == null || rhs == null) return false;
            if (!lhs.Point.Equals(rhs.Point)) return false;
            if (lhs.Flags != rhs.Flags) return false;
            return true;
        }
        
        public virtual int GetHashCode(ICellGridGetter item)
        {
            var hash = new HashCode();
            hash.Add(item.Point);
            hash.Add(item.Flags);
            return hash.ToHashCode();
        }
        
        #endregion
        
        
        public object GetNew()
        {
            return CellGrid.GetNew();
        }
        
        #region Mutagen
        public IEnumerable<FormLinkInformation> GetContainedFormLinks(ICellGridGetter obj)
        {
            yield break;
        }
        
        #endregion
        
    }
    public partial class CellGridSetterTranslationCommon
    {
        public static readonly CellGridSetterTranslationCommon Instance = new CellGridSetterTranslationCommon();

        #region DeepCopyIn
        public void DeepCopyIn(
            ICellGrid item,
            ICellGridGetter rhs,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask,
            bool deepCopy)
        {
            if ((copyMask?.GetShouldTranslate((int)CellGrid_FieldIndex.Point) ?? true))
            {
                item.Point = rhs.Point;
            }
            if ((copyMask?.GetShouldTranslate((int)CellGrid_FieldIndex.Flags) ?? true))
            {
                item.Flags = rhs.Flags;
            }
        }
        
        #endregion
        
        public CellGrid DeepCopy(
            ICellGridGetter item,
            CellGrid.TranslationMask? copyMask = null)
        {
            CellGrid ret = (CellGrid)((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).GetNew();
            ((CellGridSetterTranslationCommon)((ICellGridGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                item: ret,
                rhs: item,
                errorMask: null,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            return ret;
        }
        
        public CellGrid DeepCopy(
            ICellGridGetter item,
            out CellGrid.ErrorMask errorMask,
            CellGrid.TranslationMask? copyMask = null)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            CellGrid ret = (CellGrid)((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).GetNew();
            ((CellGridSetterTranslationCommon)((ICellGridGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
                ret,
                item,
                errorMask: errorMaskBuilder,
                copyMask: copyMask?.GetCrystal(),
                deepCopy: true);
            errorMask = CellGrid.ErrorMask.Factory(errorMaskBuilder);
            return ret;
        }
        
        public CellGrid DeepCopy(
            ICellGridGetter item,
            ErrorMaskBuilder? errorMask,
            TranslationCrystal? copyMask = null)
        {
            CellGrid ret = (CellGrid)((CellGridCommon)((ICellGridGetter)item).CommonInstance()!).GetNew();
            ((CellGridSetterTranslationCommon)((ICellGridGetter)ret).CommonSetterTranslationInstance()!).DeepCopyIn(
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
    public partial class CellGrid
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => CellGrid_Registration.Instance;
        public static CellGrid_Registration Registration => CellGrid_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => CellGridCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterInstance()
        {
            return CellGridSetterCommon.Instance;
        }
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => CellGridSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object ICellGridGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object ICellGridGetter.CommonSetterInstance() => this.CommonSetterInstance();
        [DebuggerStepThrough]
        object ICellGridGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

    }
}

#region Modules
#region Binary Translation
namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class CellGridBinaryWriteTranslation : IBinaryWriteTranslator
    {
        public readonly static CellGridBinaryWriteTranslation Instance = new CellGridBinaryWriteTranslation();

        public static void WriteEmbedded(
            ICellGridGetter item,
            MutagenWriter writer)
        {
            Mutagen.Bethesda.Binary.P2IntBinaryTranslation.Instance.Write(
                writer: writer,
                item: item.Point);
            Mutagen.Bethesda.Binary.EnumBinaryTranslation<CellGrid.Flag>.Instance.Write(
                writer,
                item.Flags,
                length: 4);
        }

        public void Write(
            MutagenWriter writer,
            ICellGridGetter item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            using (HeaderExport.Header(
                writer: writer,
                record: recordTypeConverter.ConvertToCustom(RecordTypes.XCLC),
                type: Mutagen.Bethesda.Binary.ObjectType.Subrecord))
            {
                WriteEmbedded(
                    item: item,
                    writer: writer);
            }
        }

        public void Write(
            MutagenWriter writer,
            object item,
            RecordTypeConverter? recordTypeConverter = null)
        {
            Write(
                item: (ICellGridGetter)item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }

    public partial class CellGridBinaryCreateTranslation
    {
        public readonly static CellGridBinaryCreateTranslation Instance = new CellGridBinaryCreateTranslation();

        public static void FillBinaryStructs(
            ICellGrid item,
            MutagenFrame frame)
        {
            item.Point = Mutagen.Bethesda.Binary.P2IntBinaryTranslation.Instance.Parse(frame: frame);
            item.Flags = EnumBinaryTranslation<CellGrid.Flag>.Instance.Parse(frame: frame.SpawnWithLength(4));
        }

    }

}
namespace Mutagen.Bethesda.Fallout4
{
    #region Binary Write Mixins
    public static class CellGridBinaryTranslationMixIn
    {
        public static void WriteToBinary(
            this ICellGridGetter item,
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((CellGridBinaryWriteTranslation)item.BinaryWriteTranslator).Write(
                item: item,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

    }
    #endregion


}
namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class CellGridBinaryOverlay :
        BinaryOverlay,
        ICellGridGetter
    {
        #region Common Routing
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => CellGrid_Registration.Instance;
        public static CellGrid_Registration Registration => CellGrid_Registration.Instance;
        [DebuggerStepThrough]
        protected object CommonInstance() => CellGridCommon.Instance;
        [DebuggerStepThrough]
        protected object CommonSetterTranslationInstance() => CellGridSetterTranslationCommon.Instance;
        [DebuggerStepThrough]
        object ICellGridGetter.CommonInstance() => this.CommonInstance();
        [DebuggerStepThrough]
        object? ICellGridGetter.CommonSetterInstance() => null;
        [DebuggerStepThrough]
        object ICellGridGetter.CommonSetterTranslationInstance() => this.CommonSetterTranslationInstance();

        #endregion

        void IPrintable.ToString(FileGeneration fg, string? name) => this.ToString(fg, name);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        protected object BinaryWriteTranslator => CellGridBinaryWriteTranslation.Instance;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        object IBinaryItem.BinaryWriteTranslator => this.BinaryWriteTranslator;
        void IBinaryItem.WriteToBinary(
            MutagenWriter writer,
            RecordTypeConverter? recordTypeConverter = null)
        {
            ((CellGridBinaryWriteTranslation)this.BinaryWriteTranslator).Write(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter);
        }

        public P2Int Point => P2IntBinaryTranslation.Read(_data.Slice(0x0, 0x8));
        public CellGrid.Flag Flags => (CellGrid.Flag)BinaryPrimitives.ReadInt32LittleEndian(_data.Span.Slice(0x8, 0x4));
        partial void CustomFactoryEnd(
            OverlayStream stream,
            int finalPos,
            int offset);

        partial void CustomCtor();
        protected CellGridBinaryOverlay(
            ReadOnlyMemorySlice<byte> bytes,
            BinaryOverlayFactoryPackage package)
            : base(
                bytes: bytes,
                package: package)
        {
            this.CustomCtor();
        }

        public static CellGridBinaryOverlay CellGridFactory(
            OverlayStream stream,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            var ret = new CellGridBinaryOverlay(
                bytes: HeaderTranslation.ExtractSubrecordMemory(stream.RemainingMemory, package.MetaData.Constants),
                package: package);
            var finalPos = checked((int)(stream.Position + stream.GetSubrecord().TotalLength));
            int offset = stream.Position + package.MetaData.Constants.SubConstants.TypeAndLengthLength;
            stream.Position += 0xC + package.MetaData.Constants.SubConstants.HeaderLength;
            ret.CustomFactoryEnd(
                stream: stream,
                finalPos: stream.Length,
                offset: offset);
            return ret;
        }

        public static CellGridBinaryOverlay CellGridFactory(
            ReadOnlyMemorySlice<byte> slice,
            BinaryOverlayFactoryPackage package,
            RecordTypeConverter? recordTypeConverter = null)
        {
            return CellGridFactory(
                stream: new OverlayStream(slice, package),
                package: package,
                recordTypeConverter: recordTypeConverter);
        }

        #region To String

        public void ToString(
            FileGeneration fg,
            string? name = null)
        {
            CellGridMixIn.ToString(
                item: this,
                name: name);
        }

        #endregion

        #region Equals and Hash
        public override bool Equals(object? obj)
        {
            if (!(obj is ICellGridGetter rhs)) return false;
            return ((CellGridCommon)((ICellGridGetter)this).CommonInstance()!).Equals(this, rhs);
        }

        public bool Equals(ICellGridGetter? obj)
        {
            return ((CellGridCommon)((ICellGridGetter)this).CommonInstance()!).Equals(this, obj);
        }

        public override int GetHashCode() => ((CellGridCommon)((ICellGridGetter)this).CommonInstance()!).GetHashCode(this);

        #endregion

    }

}
#endregion

#endregion

