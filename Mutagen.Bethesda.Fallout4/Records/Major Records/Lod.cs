using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4.Internals
{
    public partial class LodBinaryCreateTranslation
    {
        public const int TotalLen = 260;

        static partial void FillBinaryLevel0Custom(MutagenFrame frame, ILod item)
        {
            item.Level0 = ReadString(frame, out var bytes);
            item.Level0Extra = bytes;
            item.Level1 = ReadString(frame, out bytes);
            item.Level1Extra = bytes;
            item.Level2 = ReadString(frame, out bytes);
            item.Level2Extra = bytes;
            item.Level3 = ReadString(frame, out bytes);
            item.Level3Extra = bytes;
        }

        public static string ReadString(MutagenFrame frame, out byte[] extraBytes)
        {
            var str = StringBinaryTranslation.Instance.Parse(frame, parseWhole: false, stringBinaryType: StringBinaryType.NullTerminate);
            extraBytes = frame.ReadBytes(TotalLen - str.Length - 1);
            return str;
        }
    }

    public partial class LodBinaryWriteTranslation
    {
        static partial void WriteBinaryLevel0Custom(MutagenWriter writer, ILodGetter item)
        {
            WriteString(writer, item.Level0, item.Level0Extra);
            WriteString(writer, item.Level1, item.Level1Extra);
            WriteString(writer, item.Level2, item.Level2Extra);
            WriteString(writer, item.Level3, item.Level3Extra);
        }

        public static void WriteString(MutagenWriter writer, string str, ReadOnlyMemorySlice<byte>? bytes)
        {
            if (str.Length >= LodBinaryCreateTranslation.TotalLen)
            {
                throw new ArgumentException($"String was too long to fit. {str.Length} > {LodBinaryCreateTranslation.TotalLen - 1}");
            }
            writer.Write(str, StringBinaryType.NullTerminate);
            if (bytes == null)
            {
                writer.WriteZeros((uint)(LodBinaryCreateTranslation.TotalLen - str.Length - 1));
            }
            else
            {
                writer.Write(bytes.Value);
            }
        }
    }

    public partial class LodBinaryOverlay
    {
        public string Level0 => LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data, _package.MetaData)), out var _);
        public ReadOnlyMemorySlice<byte>? Level0Extra
        {
            get
            {
                LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data, _package.MetaData)), out var bytes);
                return bytes;
            }
        }
        public string Level1 => LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(LodBinaryCreateTranslation.TotalLen), _package.MetaData)), out var _);
        public ReadOnlyMemorySlice<byte>? Level1Extra
        {
            get
            {
                LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(LodBinaryCreateTranslation.TotalLen), _package.MetaData)), out var bytes);
                return bytes;
            }
        }
        public string Level2 => LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(LodBinaryCreateTranslation.TotalLen * 2), _package.MetaData)), out var _);
        public ReadOnlyMemorySlice<byte>? Level2Extra
        {
            get
            {
                LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(LodBinaryCreateTranslation.TotalLen * 2), _package.MetaData)), out var bytes);
                return bytes;
            }
        }
        public string Level3 => LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(LodBinaryCreateTranslation.TotalLen * 3), _package.MetaData)), out var _);
        public ReadOnlyMemorySlice<byte>? Level3Extra
        {
            get
            {
                LodBinaryCreateTranslation.ReadString(new MutagenFrame(new MutagenMemoryReadStream(_data.Slice(LodBinaryCreateTranslation.TotalLen * 3), _package.MetaData)), out var bytes);
                return bytes;
            }
        }
    }
}
