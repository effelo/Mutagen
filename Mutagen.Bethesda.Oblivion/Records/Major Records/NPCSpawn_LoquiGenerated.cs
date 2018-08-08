/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loqui;
using Noggog;
using Noggog.Notifying;
using Mutagen.Bethesda.Oblivion.Internals;
using ReactiveUI;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Internals;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Loqui.Xml;
using Loqui.Internal;
using System.Diagnostics;
using System.Collections.Specialized;
using Mutagen.Bethesda.Binary;

namespace Mutagen.Bethesda.Oblivion
{
    #region Class
    public abstract partial class NPCSpawn : 
        MajorRecord,
        INPCSpawn,
        ILoquiObject<NPCSpawn>,
        ILoquiObjectSetter,
        IEquatable<NPCSpawn>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ILoquiRegistration ILoquiObject.Registration => NPCSpawn_Registration.Instance;
        public new static NPCSpawn_Registration Registration => NPCSpawn_Registration.Instance;

        #region Ctor
        public NPCSpawn()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region Loqui Getter Interface

        protected override object GetNthObject(ushort index) => NPCSpawnCommon.GetNthObject(index, this);

        protected override bool GetNthObjectHasBeenSet(ushort index) => NPCSpawnCommon.GetNthObjectHasBeenSet(index, this);

        protected override void UnsetNthObject(ushort index, NotifyingUnsetParameters cmds) => NPCSpawnCommon.UnsetNthObject(index, this, cmds);

        #endregion

        #region Loqui Interface
        protected override void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            NPCSpawnCommon.SetNthObjectHasBeenSet(index, on, this);
        }

        #endregion

        IMask<bool> IEqualsMask<NPCSpawn>.GetEqualsMask(NPCSpawn rhs) => NPCSpawnCommon.GetEqualsMask(this, rhs);
        IMask<bool> IEqualsMask<INPCSpawnGetter>.GetEqualsMask(INPCSpawnGetter rhs) => NPCSpawnCommon.GetEqualsMask(this, rhs);
        #region To String
        public override string ToString()
        {
            return NPCSpawnCommon.ToString(this, printMask: null);
        }

        public string ToString(
            string name = null,
            NPCSpawn_Mask<bool> printMask = null)
        {
            return NPCSpawnCommon.ToString(this, name: name, printMask: printMask);
        }

        public override void ToString(
            FileGeneration fg,
            string name = null)
        {
            NPCSpawnCommon.ToString(this, fg, name: name, printMask: null);
        }

        #endregion

        IMask<bool> ILoquiObjectGetter.GetHasBeenSetMask() => this.GetHasBeenSetMask();
        public new NPCSpawn_Mask<bool> GetHasBeenSetMask()
        {
            return NPCSpawnCommon.GetHasBeenSetMask(this);
        }
        #region Equals and Hash
        public override bool Equals(object obj)
        {
            if (!(obj is NPCSpawn rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(NPCSpawn rhs)
        {
            if (rhs == null) return false;
            if (!base.Equals(rhs)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            ret = ret.CombineHashCode(base.GetHashCode());
            return ret;
        }

        #endregion


        #region Xml Translation
        #region Xml Copy In
        public override void CopyIn_Xml(
            XElement root,
            NotifyingFireParameters cmds = null)
        {
            CopyIn_Xml_Internal(
                root: root,
                errorMask: null,
                translationMask: null,
                cmds: cmds);
        }

        public virtual void CopyIn_Xml(
            XElement root,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_TranslationMask translationMask = null,
            bool doMasks = true,
            NotifyingFireParameters cmds = null)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            CopyIn_Xml_Internal(
                root: root,
                errorMask: errorMaskBuilder,
                translationMask: translationMask?.GetCrystal(),
                cmds: cmds);
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        protected override void CopyIn_Xml_Internal(
            XElement root,
            ErrorMaskBuilder errorMask,
            TranslationCrystal translationMask,
            NotifyingFireParameters cmds = null)
        {
            LoquiXmlTranslation<NPCSpawn>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                errorMask: errorMask,
                translationMask: translationMask,
                cmds: cmds);
        }

        public void CopyIn_Xml(
            string path,
            NotifyingFireParameters cmds = null)
        {
            var root = XDocument.Load(path).Root;
            this.CopyIn_Xml(
                root: root,
                cmds: cmds);
        }

        public void CopyIn_Xml(
            string path,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_TranslationMask translationMask,
            NotifyingFireParameters cmds = null,
            bool doMasks = true)
        {
            var root = XDocument.Load(path).Root;
            this.CopyIn_Xml(
                root: root,
                errorMask: out errorMask,
                translationMask: translationMask,
                cmds: cmds,
                doMasks: doMasks);
        }

        public void CopyIn_Xml(
            Stream stream,
            NotifyingFireParameters cmds = null)
        {
            var root = XDocument.Load(stream).Root;
            this.CopyIn_Xml(
                root: root,
                cmds: cmds);
        }

        public void CopyIn_Xml(
            Stream stream,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_TranslationMask translationMask,
            NotifyingFireParameters cmds = null,
            bool doMasks = true)
        {
            var root = XDocument.Load(stream).Root;
            this.CopyIn_Xml(
                root: root,
                errorMask: out errorMask,
                translationMask: translationMask,
                cmds: cmds,
                doMasks: doMasks);
        }

        public override void CopyIn_Xml(
            XElement root,
            out MajorRecord_ErrorMask errorMask,
            MajorRecord_TranslationMask translationMask = null,
            bool doMasks = true,
            NotifyingFireParameters cmds = null)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            CopyIn_Xml_Internal(
                root: root,
                errorMask: errorMaskBuilder,
                translationMask: translationMask?.GetCrystal(),
                cmds: cmds);
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        #endregion

        #region Xml Write
        public virtual void Write_Xml(
            XElement node,
            out NPCSpawn_ErrorMask errorMask,
            bool doMasks = true,
            NPCSpawn_TranslationMask translationMask = null,
            string name = null)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            this.Write_Xml_Internal(
                node: node,
                name: name,
                errorMask: errorMaskBuilder,
                translationMask: translationMask?.GetCrystal());
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        public virtual void Write_Xml(
            string path,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_TranslationMask translationMask = null,
            bool doMasks = true,
            string name = null)
        {
            XElement topNode = new XElement("topnode");
            Write_Xml(
                node: topNode,
                name: name,
                errorMask: out errorMask,
                doMasks: doMasks,
                translationMask: translationMask);
            topNode.Elements().First().Save(path);
        }

        public virtual void Write_Xml(
            Stream stream,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_TranslationMask translationMask = null,
            bool doMasks = true,
            string name = null)
        {
            XElement topNode = new XElement("topnode");
            Write_Xml(
                node: topNode,
                name: name,
                errorMask: out errorMask,
                doMasks: doMasks,
                translationMask: translationMask);
            topNode.Elements().First().Save(stream);
        }

        #region Base Class Trickdown Overrides
        public override void Write_Xml(
            XElement node,
            out MajorRecord_ErrorMask errorMask,
            bool doMasks = true,
            MajorRecord_TranslationMask translationMask = null,
            string name = null)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            this.Write_Xml_Internal(
                node: node,
                name: name,
                errorMask: errorMaskBuilder,
                translationMask: translationMask?.GetCrystal());
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        #endregion

        protected override void Write_Xml_Internal(
            XElement node,
            ErrorMaskBuilder errorMask,
            TranslationCrystal translationMask,
            string name = null)
        {
            NPCSpawnCommon.Write_Xml(
                item: this,
                node: node,
                name: name,
                errorMask: errorMask,
                translationMask: translationMask);
        }
        #endregion

        protected static void Fill_Xml_Internal(
            NPCSpawn item,
            XElement root,
            string name,
            ErrorMaskBuilder errorMask,
            TranslationCrystal translationMask)
        {
            switch (name)
            {
                default:
                    MajorRecord.Fill_Xml_Internal(
                        item: item,
                        root: root,
                        name: name,
                        errorMask: errorMask,
                        translationMask: translationMask);
                    break;
            }
        }

        #endregion

        #region Mutagen
        public new static readonly RecordType GRUP_RECORD_TYPE = NPCSpawn_Registration.TRIGGERING_RECORD_TYPE;
        #endregion

        #region Binary Translation
        #region Binary Write
        public virtual void Write_Binary(
            MutagenWriter writer,
            out NPCSpawn_ErrorMask errorMask,
            bool doMasks = true)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            this.Write_Binary_Internal(
                writer: writer,
                recordTypeConverter: null,
                errorMask: errorMaskBuilder);
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        public virtual void Write_Binary(
            string path,
            out NPCSpawn_ErrorMask errorMask,
            bool doMasks = true)
        {
            using (var memStream = new MemoryTributary())
            {
                using (var writer = new MutagenWriter(memStream, dispose: false))
                {
                    Write_Binary(
                        writer: writer,
                        errorMask: out errorMask,
                        doMasks: doMasks);
                }
                using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memStream.Position = 0;
                    memStream.CopyTo(fs);
                }
            }
        }

        public virtual void Write_Binary(
            Stream stream,
            out NPCSpawn_ErrorMask errorMask,
            bool doMasks = true)
        {
            using (var writer = new MutagenWriter(stream))
            {
                Write_Binary(
                    writer: writer,
                    errorMask: out errorMask,
                    doMasks: doMasks);
            }
        }

        #region Base Class Trickdown Overrides
        public override void Write_Binary(
            MutagenWriter writer,
            out MajorRecord_ErrorMask errorMask,
            bool doMasks = true)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            this.Write_Binary_Internal(
                writer: writer,
                errorMask: errorMaskBuilder,
                recordTypeConverter: null);
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        #endregion

        protected override void Write_Binary_Internal(
            MutagenWriter writer,
            RecordTypeConverter recordTypeConverter,
            ErrorMaskBuilder errorMask)
        {
            NPCSpawnCommon.Write_Binary(
                item: this,
                writer: writer,
                recordTypeConverter: recordTypeConverter,
                errorMask: errorMask);
        }
        #endregion

        #endregion

        public NPCSpawn Copy(
            NPCSpawn_CopyMask copyMask = null,
            INPCSpawnGetter def = null)
        {
            return NPCSpawn.Copy(
                this,
                copyMask: copyMask,
                def: def);
        }

        public static NPCSpawn Copy(
            INPCSpawn item,
            NPCSpawn_CopyMask copyMask = null,
            INPCSpawnGetter def = null)
        {
            NPCSpawn ret = (NPCSpawn)System.Activator.CreateInstance(item.GetType());
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        public static NPCSpawn Copy_ToLoqui(
            INPCSpawnGetter item,
            NPCSpawn_CopyMask copyMask = null,
            INPCSpawnGetter def = null)
        {
            NPCSpawn ret = (NPCSpawn)System.Activator.CreateInstance(item.GetType());
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        public void CopyFieldsFrom(
            INPCSpawnGetter rhs,
            NPCSpawn_CopyMask copyMask,
            INPCSpawnGetter def = null,
            NotifyingFireParameters cmds = null)
        {
            this.CopyFieldsFrom(
                rhs: rhs,
                def: def,
                doMasks: false,
                errorMask: out var errMask,
                copyMask: copyMask,
                cmds: cmds);
        }

        public void CopyFieldsFrom(
            INPCSpawnGetter rhs,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_CopyMask copyMask = null,
            INPCSpawnGetter def = null,
            NotifyingFireParameters cmds = null,
            bool doMasks = true)
        {
            var errorMaskBuilder = new ErrorMaskBuilder();
            NPCSpawnCommon.CopyFieldsFrom(
                item: this,
                rhs: rhs,
                def: def,
                errorMask: errorMaskBuilder,
                copyMask: copyMask,
                cmds: cmds);
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        public void CopyFieldsFrom(
            INPCSpawnGetter rhs,
            ErrorMaskBuilder errorMask,
            NPCSpawn_CopyMask copyMask = null,
            INPCSpawnGetter def = null,
            NotifyingFireParameters cmds = null,
            bool doMasks = true)
        {
            NPCSpawnCommon.CopyFieldsFrom(
                item: this,
                rhs: rhs,
                def: def,
                errorMask: errorMask,
                copyMask: copyMask,
                cmds: cmds);
        }

        protected override void SetNthObject(ushort index, object obj, NotifyingFireParameters cmds = null)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    base.SetNthObject(index, obj, cmds);
                    break;
            }
        }

        public override void Clear(NotifyingUnsetParameters cmds = null)
        {
            CallClearPartial_Internal(cmds);
            NPCSpawnCommon.Clear(this, cmds);
        }


        protected new static void CopyInInternal_NPCSpawn(NPCSpawn obj, KeyValuePair<ushort, object> pair)
        {
            if (!EnumExt.TryParse(pair.Key, out NPCSpawn_FieldIndex enu))
            {
                CopyInInternal_MajorRecord(obj, pair);
            }
            switch (enu)
            {
                default:
                    throw new ArgumentException($"Unknown enum type: {enu}");
            }
        }
        public static void CopyIn(IEnumerable<KeyValuePair<ushort, object>> fields, NPCSpawn obj)
        {
            ILoquiObjectExt.CopyFieldsIn(obj, fields, def: null, skipProtected: false, cmds: null);
        }

    }
    #endregion

    #region Interface
    public partial interface INPCSpawn : INPCSpawnGetter, IMajorRecord, ILoquiClass<INPCSpawn, INPCSpawnGetter>, ILoquiClass<NPCSpawn, INPCSpawnGetter>
    {
    }

    public partial interface INPCSpawnGetter : IMajorRecordGetter
    {

    }

    #endregion

}

namespace Mutagen.Bethesda.Oblivion.Internals
{
    #region Field Index
    public enum NPCSpawn_FieldIndex
    {
        MajorRecordFlags = 0,
        FormID = 1,
        Version = 2,
        EditorID = 3,
        RecordType = 4,
    }
    #endregion

    #region Registration
    public class NPCSpawn_Registration : ILoquiRegistration
    {
        public static readonly NPCSpawn_Registration Instance = new NPCSpawn_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Oblivion.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Oblivion.ProtocolKey,
            msgID: 95,
            version: 0);

        public const string GUID = "85b66f0a-7526-41d9-b6a5-292dafc16405";

        public const ushort AdditionalFieldCount = 0;

        public const ushort FieldCount = 5;

        public static readonly Type MaskType = typeof(NPCSpawn_Mask<>);

        public static readonly Type ErrorMaskType = typeof(NPCSpawn_ErrorMask);

        public static readonly Type ClassType = typeof(NPCSpawn);

        public static readonly Type GetterType = typeof(INPCSpawnGetter);

        public static readonly Type SetterType = typeof(INPCSpawn);

        public static readonly Type CommonType = typeof(NPCSpawnCommon);

        public const string FullName = "Mutagen.Bethesda.Oblivion.NPCSpawn";

        public const string Name = "NPCSpawn";

        public const string Namespace = "Mutagen.Bethesda.Oblivion";

        public const byte GenericCount = 0;

        public static readonly Type GenericRegistrationType = null;

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                default:
                    return null;
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthIsEnumerable(index);
            }
        }

        public static bool GetNthIsLoqui(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthIsLoqui(index);
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthIsSingleton(index);
            }
        }

        public static string GetNthName(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthName(index);
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.IsNthDerivative(index);
            }
        }

        public static bool IsProtected(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.IsProtected(index);
            }
        }

        public static Type GetNthType(ushort index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthType(index);
            }
        }

        public static readonly RecordType LVLC_HEADER = new RecordType("LVLC");
        public static readonly RecordType TRIGGERING_RECORD_TYPE = LVLC_HEADER;
        public const int NumStructFields = 0;
        public const int NumTypedFields = 0;
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
        Type ILoquiRegistration.GetterType => GetterType;
        Type ILoquiRegistration.CommonType => CommonType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => GetNameIndex(name);
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => GetNthIsEnumerable(index);
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => GetNthIsLoqui(index);
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => GetNthIsSingleton(index);
        string ILoquiRegistration.GetNthName(ushort index) => GetNthName(index);
        bool ILoquiRegistration.IsNthDerivative(ushort index) => IsNthDerivative(index);
        bool ILoquiRegistration.IsProtected(ushort index) => IsProtected(index);
        Type ILoquiRegistration.GetNthType(ushort index) => GetNthType(index);
        #endregion

    }
    #endregion

    #region Extensions
    public static partial class NPCSpawnCommon
    {
        #region Copy Fields From
        public static void CopyFieldsFrom(
            INPCSpawn item,
            INPCSpawnGetter rhs,
            INPCSpawnGetter def,
            ErrorMaskBuilder errorMask,
            NPCSpawn_CopyMask copyMask,
            NotifyingFireParameters cmds = null)
        {
            MajorRecordCommon.CopyFieldsFrom(
                item,
                rhs,
                def,
                errorMask,
                copyMask,
                cmds);
        }

        #endregion

        public static void SetNthObjectHasBeenSet(
            ushort index,
            bool on,
            INPCSpawn obj,
            NotifyingFireParameters cmds = null)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    MajorRecordCommon.SetNthObjectHasBeenSet(index, on, obj);
                    break;
            }
        }

        public static void UnsetNthObject(
            ushort index,
            INPCSpawn obj,
            NotifyingUnsetParameters cmds = null)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    MajorRecordCommon.UnsetNthObject(index, obj);
                    break;
            }
        }

        public static bool GetNthObjectHasBeenSet(
            ushort index,
            INPCSpawn obj)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecordCommon.GetNthObjectHasBeenSet(index, obj);
            }
        }

        public static object GetNthObject(
            ushort index,
            INPCSpawnGetter obj)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecordCommon.GetNthObject(index, obj);
            }
        }

        public static void Clear(
            INPCSpawn item,
            NotifyingUnsetParameters cmds = null)
        {
        }

        public static NPCSpawn_Mask<bool> GetEqualsMask(
            this INPCSpawnGetter item,
            INPCSpawnGetter rhs)
        {
            var ret = new NPCSpawn_Mask<bool>();
            FillEqualsMask(item, rhs, ret);
            return ret;
        }

        public static void FillEqualsMask(
            INPCSpawnGetter item,
            INPCSpawnGetter rhs,
            NPCSpawn_Mask<bool> ret)
        {
            if (rhs == null) return;
            MajorRecordCommon.FillEqualsMask(item, rhs, ret);
        }

        public static string ToString(
            this INPCSpawnGetter item,
            string name = null,
            NPCSpawn_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            item.ToString(fg, name, printMask);
            return fg.ToString();
        }

        public static void ToString(
            this INPCSpawnGetter item,
            FileGeneration fg,
            string name = null,
            NPCSpawn_Mask<bool> printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"{nameof(NPCSpawn)} =>");
            }
            else
            {
                fg.AppendLine($"{name} ({nameof(NPCSpawn)}) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
            }
            fg.AppendLine("]");
        }

        public static bool HasBeenSet(
            this INPCSpawnGetter item,
            NPCSpawn_Mask<bool?> checkMask)
        {
            return true;
        }

        public static NPCSpawn_Mask<bool> GetHasBeenSetMask(INPCSpawnGetter item)
        {
            var ret = new NPCSpawn_Mask<bool>();
            return ret;
        }

        public static NPCSpawn_FieldIndex? ConvertFieldIndex(MajorRecord_FieldIndex? index)
        {
            if (!index.HasValue) return null;
            return ConvertFieldIndex(index: index.Value);
        }

        public static NPCSpawn_FieldIndex ConvertFieldIndex(MajorRecord_FieldIndex index)
        {
            switch (index)
            {
                case MajorRecord_FieldIndex.MajorRecordFlags:
                    return (NPCSpawn_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.FormID:
                    return (NPCSpawn_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.Version:
                    return (NPCSpawn_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.EditorID:
                    return (NPCSpawn_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.RecordType:
                    return (NPCSpawn_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }

        #region Xml Translation
        #region Xml Write
        public static void Write_Xml(
            XElement node,
            NPCSpawn item,
            bool doMasks,
            out NPCSpawn_ErrorMask errorMask,
            NPCSpawn_TranslationMask translationMask,
            string name = null)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            Write_Xml(
                node: node,
                name: name,
                item: item,
                errorMask: errorMaskBuilder,
                translationMask: translationMask?.GetCrystal());
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        public static void Write_Xml(
            XElement node,
            NPCSpawn item,
            ErrorMaskBuilder errorMask,
            TranslationCrystal translationMask,
            string name = null)
        {
            var elem = new XElement(name ?? "Mutagen.Bethesda.Oblivion.NPCSpawn");
            node.Add(elem);
            if (name != null)
            {
                elem.SetAttributeValue("type", "Mutagen.Bethesda.Oblivion.NPCSpawn");
            }
        }
        #endregion

        #endregion

        #region Binary Translation
        #region Binary Write
        public static void Write_Binary(
            MutagenWriter writer,
            NPCSpawn item,
            RecordTypeConverter recordTypeConverter,
            bool doMasks,
            out NPCSpawn_ErrorMask errorMask)
        {
            ErrorMaskBuilder errorMaskBuilder = doMasks ? new ErrorMaskBuilder() : null;
            Write_Binary(
                writer: writer,
                item: item,
                recordTypeConverter: recordTypeConverter,
                errorMask: errorMaskBuilder);
            errorMask = NPCSpawn_ErrorMask.Factory(errorMaskBuilder);
        }

        public static void Write_Binary(
            MutagenWriter writer,
            NPCSpawn item,
            RecordTypeConverter recordTypeConverter,
            ErrorMaskBuilder errorMask)
        {
            MajorRecordCommon.Write_Binary_Embedded(
                item: item,
                writer: writer,
                errorMask: errorMask);
            MajorRecordCommon.Write_Binary_RecordTypes(
                item: item,
                writer: writer,
                recordTypeConverter: recordTypeConverter,
                errorMask: errorMask);
        }
        #endregion

        #endregion

    }
    #endregion

    #region Modules
    #region Mask
    public class NPCSpawn_Mask<T> : MajorRecord_Mask<T>, IMask<T>, IEquatable<NPCSpawn_Mask<T>>
    {
        #region Ctors
        public NPCSpawn_Mask()
        {
        }

        public NPCSpawn_Mask(T initialValue)
        {
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (!(obj is NPCSpawn_Mask<T> rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(NPCSpawn_Mask<T> rhs)
        {
            if (rhs == null) return false;
            if (!base.Equals(rhs)) return false;
            return true;
        }
        public override int GetHashCode()
        {
            int ret = 0;
            ret = ret.CombineHashCode(base.GetHashCode());
            return ret;
        }

        #endregion

        #region All Equal
        public override bool AllEqual(Func<T, bool> eval)
        {
            if (!base.AllEqual(eval)) return false;
            return true;
        }
        #endregion

        #region Translate
        public new NPCSpawn_Mask<R> Translate<R>(Func<T, R> eval)
        {
            var ret = new NPCSpawn_Mask<R>();
            this.Translate_InternalFill(ret, eval);
            return ret;
        }

        protected void Translate_InternalFill<R>(NPCSpawn_Mask<R> obj, Func<T, R> eval)
        {
            base.Translate_InternalFill(obj, eval);
        }
        #endregion

        #region Clear Enumerables
        public override void ClearEnumerables()
        {
            base.ClearEnumerables();
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return ToString(printMask: null);
        }

        public string ToString(NPCSpawn_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            ToString(fg, printMask);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg, NPCSpawn_Mask<bool> printMask = null)
        {
            fg.AppendLine($"{nameof(NPCSpawn_Mask<T>)} =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
            }
            fg.AppendLine("]");
        }
        #endregion

    }

    public class NPCSpawn_ErrorMask : MajorRecord_ErrorMask, IErrorMask<NPCSpawn_ErrorMask>
    {
        #region IErrorMask
        public override object GetNthMask(int index)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    return base.GetNthMask(index);
            }
        }

        public override void SetNthException(int index, Exception ex)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    base.SetNthException(index, ex);
                    break;
            }
        }

        public override void SetNthMask(int index, object obj)
        {
            NPCSpawn_FieldIndex enu = (NPCSpawn_FieldIndex)index;
            switch (enu)
            {
                default:
                    base.SetNthMask(index, obj);
                    break;
            }
        }

        public override bool IsInError()
        {
            if (Overall != null) return true;
            return false;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            var fg = new FileGeneration();
            ToString(fg);
            return fg.ToString();
        }

        public override void ToString(FileGeneration fg)
        {
            fg.AppendLine("NPCSpawn_ErrorMask =>");
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
        }
        #endregion

        #region Combine
        public NPCSpawn_ErrorMask Combine(NPCSpawn_ErrorMask rhs)
        {
            var ret = new NPCSpawn_ErrorMask();
            return ret;
        }
        public static NPCSpawn_ErrorMask Combine(NPCSpawn_ErrorMask lhs, NPCSpawn_ErrorMask rhs)
        {
            if (lhs != null && rhs != null) return lhs.Combine(rhs);
            return lhs ?? rhs;
        }
        #endregion

        #region Factory
        public static NPCSpawn_ErrorMask Factory(ErrorMaskBuilder errorMask)
        {
            if (errorMask?.Empty ?? true) return null;
            return new NPCSpawn_ErrorMask();
        }
        #endregion

    }
    public class NPCSpawn_CopyMask : MajorRecord_CopyMask
    {
    }
    public class NPCSpawn_TranslationMask : MajorRecord_TranslationMask
    {
        #region Members
        private TranslationCrystal _crystal;
        #endregion

        protected override void GetCrystal(List<(bool On, TranslationCrystal SubCrystal)> ret)
        {
            base.GetCrystal(ret);
        }
    }
    #endregion

    #endregion

}
