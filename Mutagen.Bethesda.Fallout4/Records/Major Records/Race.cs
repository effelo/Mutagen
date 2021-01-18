using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Race
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string INamedRequiredGetter.Name => this.Name?.String ?? string.Empty;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string? INamedGetter.Name => this.Name?.String;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ITranslatedStringGetter ITranslatedNamedRequiredGetter.Name => this.Name ?? TranslatedString.Empty;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ITranslatedStringGetter? ITranslatedNamedGetter.Name => this.Name;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string INamedRequired.Name
        {
            get => this.Name?.String ?? string.Empty;
            set => this.Name = new TranslatedString(value);
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        TranslatedString ITranslatedNamedRequired.Name
        {
            get => this.Name ?? string.Empty;
            set => this.Name = value;
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string? INamed.Name
        {
            get => this.Name?.String;
            set => this.Name = value == null ? null : new TranslatedString(value);
        }

        internal static readonly RecordType NAM2 = new RecordType("NAM2");
        public bool ExportingExtraNam2 { get; set; }

        [Flags]
        public enum MajorFlag
        {
            Critter = 0x0008_0000
        }

        // ToDo
        // Remove HeadPartList enums from flags.  Only one can be active, so should set up a way to force that
        [Flags]
        public enum Flag : ulong
        {
            Playable = 0x0000_0001,
            FaceGenHead = 0x0000_0002,
            Child = 0x0000_0004,
            TiltFrontBack = 0x0000_0008,
            TiltLeftRight = 0x0000_0010,
            NoShadow = 0x0000_0020,
            Swims = 0x0000_0040,
            Flies = 0x0000_0080,
            Walks = 0x0000_0100,
            Immobile = 0x0000_0200,
            NotPunishable = 0x0000_0400,
            NoCombatInWater = 0x0000_0800,
            NoRotatingToHeadTrack = 0x0000_1000,
            DontShowBloodSpray = 0x0000_2000,
            DontShowBloodDecal = 0x0000_4000,
            UsesHeadTrackAnims = 0x0000_8000,
            SpellsAlignWithMagicNode = 0x0001_0000,
            UseWorldRaycastsForFootIK = 0x0002_0000,
            AllowRagdollCollision = 0x0004_0000,
            RegenHpInCombat = 0x0008_0000,
            CantOpenDoors = 0x0010_0000,
            AllowPcDialog = 0x0020_0000,
            NoKnockdowns = 0x0040_0000,
            AllowPickpocket = 0x0080_0000,
            AlwaysUseProxyController = 0x0100_0000,
            DontShowWeaponBlood = 0x0200_0000,
            OverlayHeadPartList = 0x0400_0000,
            OverrideHeadPartList = 0x0800_0000,
            CanPickupItems = 0x1000_0000,
            AllowMultipleMembraneShaders = 0x2000_0000,
            CanDualWield = 0x4000_0000,
            AvoidsRoads = 0x8000_0000,
            UseAdvancedAvoidance = 0x0001_0000_0000,
            NonHostile = 0x0002_0000_0000,
            AllowMountedCombat = 0x0010_0000_0000,
        }
    }

    public partial interface IRace
    {
        new bool ExportingExtraNam2 { get; set; }
    }

    public partial interface IRaceGetter
    {
        bool ExportingExtraNam2 { get; }
    }

    namespace Internals
    {
        public partial class RaceBinaryCreateTranslation
        {
            public const int NumBipedObjectNames = 32;

            static partial void FillBinaryExtraNAM2Custom(MutagenFrame frame, IRaceInternal item)
            {
                if (frame.Complete) return;
                if (frame.TryGetSubrecord(Race.NAM2, out var subHeader))
                {
                    item.ExportingExtraNam2 = true;
                    frame.Position += subHeader.TotalLength;
                }
            }

            static partial void FillBinaryBipedObjectNamesCustom(MutagenFrame frame, IRaceInternal item)
            {
                for (int i = 0; i < NumBipedObjectNames; i++)
                {
                    if (!frame.Reader.TryReadSubrecordFrame(RecordTypes.NAME, out var subHeader)) break;
                    BipedObject type = (BipedObject)i;
                    var val = BinaryStringUtility.ProcessWholeToZString(subHeader.Content);
                    if (!string.IsNullOrEmpty(val))
                    {
                        item.BipedObjectNames[type] = val;
                    }
                }
            }

            static partial void FillBinaryFaceFxPhonemesListingParsingCustom(MutagenFrame frame, IRaceInternal item) => FaceFxPhonemesBinaryCreateTranslation.ParseFaceFxPhonemes(frame, item.FaceFxPhonemes);

            static partial void FillBinaryFaceFxPhonemesRawParsingCustom(MutagenFrame frame, IRaceInternal item) => FaceFxPhonemesBinaryCreateTranslation.ParseFaceFxPhonemes(frame, item.FaceFxPhonemes);

            static partial void FillBinaryFlags2Custom(MutagenFrame frame, IRaceInternal item)
            {
                // Clear out upper flags
                item.Flags &= ((Race.Flag)0x00000000FFFFFFFF);

                // Set upper flags
                ulong flags2 = frame.ReadUInt32();
                flags2 <<= 32;
                item.Flags |= ((Race.Flag)flags2);
            }

            static partial void FillBinaryBodyTemplateCustom(MutagenFrame frame, IRaceInternal item)
            {
                item.BodyTemplate = BodyTemplateBinaryCreateTranslation.Parse(frame);
            }
        }

        public partial class RaceBinaryOverlay
        {
            #region Interfaces
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            string INamedRequiredGetter.Name => this.Name?.String ?? string.Empty;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            string? INamedGetter.Name => this.Name?.String;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            ITranslatedStringGetter ITranslatedNamedRequiredGetter.Name => this.Name ?? TranslatedString.Empty;
            #endregion

            public bool ExportingExtraNam2 { get; private set; }
            public bool ExportingExtraNam3 => throw new NotImplementedException();

            private int? _faceFxPhonemesLoc;
            public IFaceFxPhonemesGetter FaceFxPhonemes => GetFaceFx();

            partial void ExtraNAM2CustomParse(OverlayStream stream, int offset)
            {
            }

            private int? _bipedObjectNamesLoc;
            public IReadOnlyDictionary<BipedObject, string> BipedObjectNames
            {
                get
                {
                    if (_bipedObjectNamesLoc == null) return DictionaryExt.Empty<BipedObject, string>();
                    var ret = new Dictionary<BipedObject, string>();
                    var loc = _bipedObjectNamesLoc.Value;
                    for (int i = 0; i < RaceBinaryCreateTranslation.NumBipedObjectNames; i++)
                    {
                        if (!_package.MetaData.Constants.TrySubrecordFrame(_data.Slice(loc), RecordTypes.NAME, out var subHeader)) break;
                        BipedObject type = (BipedObject)i;
                        var val = BinaryStringUtility.ProcessWholeToZString(subHeader.Content);
                        if (!string.IsNullOrEmpty(val))
                        {
                            ret[type] = val;
                        }
                        loc += subHeader.HeaderAndContentData.Length;
                    }
                    return ret;
                }
            }

            void BipedObjectNamesCustomParse(OverlayStream stream, int finalPos, int offset)
            {
                _bipedObjectNamesLoc = (ushort)(stream.Position - offset);
                UtilityTranslation.SkipPastAll(stream, _package.MetaData.Constants, RecordTypes.NAME);
            }

            partial void FaceFxPhonemesListingParsingCustomParse(OverlayStream stream, int offset)
            {
                FaceFxPhonemesRawParsingCustomParse(stream, offset);
            }

            partial void FaceFxPhonemesRawParsingCustomParse(OverlayStream stream, int offset)
            {
                if (_faceFxPhonemesLoc == null)
                {
                    _faceFxPhonemesLoc = (ushort)(stream.Position - offset);
                }
                UtilityTranslation.SkipPastAll(stream, _package.MetaData.Constants, RecordTypes.PHTN);
                UtilityTranslation.SkipPastAll(stream, _package.MetaData.Constants, RecordTypes.PHWT);
            }

            private FaceFxPhonemes GetFaceFx()
            {
                var ret = new FaceFxPhonemes();
                if (_faceFxPhonemesLoc == null) return ret;
                var frame = new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(_faceFxPhonemesLoc.Value), _package.MetaData));
                FaceFxPhonemesBinaryCreateTranslation.ParseFaceFxPhonemes(frame, ret);
                return ret;
            }

            public Race.Flag GetFlagsCustom()
            {
                if (!_DATALocation.HasValue) return default;
                var flag = (Race.Flag)BinaryPrimitives.ReadInt32LittleEndian(_data.Span.Slice(_FlagsLocation, 4));

                // Clear out upper flags
                flag &= ((Race.Flag)0x00000000FFFFFFFF);

                // Set upper flags
                ulong flags2 = BinaryPrimitives.ReadUInt32LittleEndian(_data.Span.Slice(_DATALocation!.Value + 124, 4));
                flags2 <<= 32;
                flag |= ((Race.Flag)flags2);
                return flag;
            }

            private int? _BodyTemplateLocation;
            public IBodyTemplateGetter? GetBodyTemplateCustom() => _BodyTemplateLocation.HasValue ? BodyTemplateBinaryOverlay.CustomFactory(new OverlayStream(_data.Slice(_BodyTemplateLocation!.Value), _package), _package) : default;
            public bool BodyTemplate_IsSet => _BodyTemplateLocation.HasValue;

            partial void BodyTemplateCustomParse(OverlayStream stream, long finalPos, int offset)
            {
                _BodyTemplateLocation = (stream.Position - offset);
            }
        }

        public partial class RaceBinaryWriteTranslation
        {
            static partial void WriteBinaryExtraNAM2Custom(MutagenWriter writer, IRaceGetter item)
            {
                if (item.ExportingExtraNam2)
                {
                    using var header = HeaderExport.Subrecord(writer, Race.NAM2);
                }
            }

            static partial void WriteBinaryBipedObjectNamesCustom(MutagenWriter writer, IRaceGetter item)
            {
                var bipedObjs = item.BipedObjectNames;
                for (int i = 0; i < RaceBinaryCreateTranslation.NumBipedObjectNames; i++)
                {
                    var bipedObj = (BipedObject)i;
                    using (HeaderExport.Subrecord(writer, RecordTypes.NAME))
                    {
                        if (bipedObjs.TryGetValue(bipedObj, out var val))
                        {
                            writer.Write(val, StringBinaryType.NullTerminate);
                        }
                        else
                        {
                            writer.Write(string.Empty, StringBinaryType.NullTerminate);
                        }
                    }
                }
            }

            static partial void WriteBinaryFaceFxPhonemesListingParsingCustom(MutagenWriter writer, IRaceGetter item) => FaceFxPhonemesBinaryWriteTranslation.WriteFaceFxPhonemes(writer, item.FaceFxPhonemes);

            static partial void WriteBinaryFaceFxPhonemesRawParsingCustom(MutagenWriter writer, IRaceGetter item)
            {
                // Handled by Listing section
            }

            static partial void WriteBinaryFlags2Custom(MutagenWriter writer, IRaceGetter item)
            {
                ulong flags = (ulong)item.Flags;
                flags >>= 32;
                writer.Write((uint)flags);
            }

            static partial void WriteBinaryBodyTemplateCustom(MutagenWriter writer, IRaceGetter item)
            {
                if (item.BodyTemplate.TryGet(out var templ))
                {
                    BodyTemplateBinaryWriteTranslation.Write(writer, templ);
                }
            }
        }
    }
}
