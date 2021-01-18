﻿using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;
using static Mutagen.Bethesda.Fallout4.Internals.ScriptFragmentsBinaryCreateTranslation;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class ScriptFragmentsBinaryCreateTranslation
        {
            [Flags]
            public enum Flag
            {
                OnBegin = 0x01,
                OnEnd = 0x02,
            }

            static partial void FillBinaryFlagsCustom(MutagenFrame frame, IScriptFragments item)
            {
                var flag = (Flag)frame.ReadUInt8();
                item.FileName = Mutagen.Bethesda.Binary.StringBinaryTranslation.Instance.Parse(
                     frame: frame,
                     stringBinaryType: StringBinaryType.PrependLengthUShort);
                if (flag.HasFlag(Flag.OnBegin))
                {
                    item.OnBegin = ScriptFragment.CreateFromBinary(frame);
                }
                if (flag.HasFlag(Flag.OnEnd))
                {
                    item.OnEnd = ScriptFragment.CreateFromBinary(frame);
                }
            }
        }

        public partial class ScriptFragmentsBinaryWriteTranslation
        {
            static partial void WriteBinaryFlagsCustom(MutagenWriter writer, IScriptFragmentsGetter item)
            {
                var begin = item.OnBegin;
                var end = item.OnEnd;
                Flag flag = default;
                if (begin != null)
                {
                    flag |= Flag.OnBegin;
                }
                if (end != null)
                {
                    flag |= Flag.OnEnd;
                }
                writer.Write((byte)flag);
                Mutagen.Bethesda.Binary.StringBinaryTranslation.Instance.Write(
                    writer: writer,
                    item: item.FileName,
                    binaryType: StringBinaryType.PrependLengthUShort);
                begin?.WriteToBinary(writer);
                end?.WriteToBinary(writer);
            }
        }

        public partial class ScriptFragmentsBinaryOverlay
        {
            Flag Flags => (Flag)_data.Span.Slice(0x1, 0x1)[0];

            public string FileName => BinaryStringUtility.ParsePrependedString(_data.Slice(0x2), lengthLength: 2);

            public IScriptFragmentGetter? OnBegin { get; private set; }

            public IScriptFragmentGetter? OnEnd { get; private set; }

            partial void CustomFactoryEnd(OverlayStream stream, int finalPos, int offset)
            {
                Initialize(stream);
            }

            protected void Initialize(OverlayStream stream)
            {
                var fileNameEnd = 0x2 + BinaryPrimitives.ReadUInt16LittleEndian(_data.Slice(0x2)) + 2;
                stream.Position = fileNameEnd;
                int onBeginEnd;
                if (Flags.HasFlag(Flag.OnBegin))
                {
                    stream.Position = fileNameEnd;
                    OnBegin = ScriptFragmentBinaryOverlay.ScriptFragmentFactory(stream, _package);
                    onBeginEnd = stream.Position;
                }
                else
                {
                    onBeginEnd = fileNameEnd;
                }
                if (Flags.HasFlag(Flag.OnEnd))
                {
                    stream.Position = onBeginEnd;
                    OnEnd = ScriptFragmentBinaryOverlay.ScriptFragmentFactory(stream, _package);
                    FlagsEndingPos = stream.Position;
                }
                else
                {
                    FlagsEndingPos = onBeginEnd;
                }
            }
        }
    }
}
