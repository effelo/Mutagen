using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Noggog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Bethesda.Preprocessing
{
    /// <summary>
    /// A static class with logic on how to decompress mod bytes without leveraging autogenerated records
    /// </summary>
    public static class ModDecompressor
    {
        /// <summary>
        /// Decompresses mod stream into an output.
        /// Will open up two input streams, so a Func factory is given as input.
        /// </summary>
        /// <param name="streamCreator">A func to create an input stream</param>
        /// <param name="outputStream">Stream to write output to</param>
        /// <param name="gameMode">Type of game the mod stream is reading</param>
        /// <param name="interest">Optional specification of which record types to process</param>
        public static void Decompress(
            Func<Stream> streamCreator,
            Stream outputStream,
            GameRelease release,
            RecordInterest? interest = null)
        {
            var meta = new ParsingBundle(GameConstants.Get(release));
            using var inputStream = new MutagenBinaryReadStream(streamCreator(), meta);
            using var inputStreamJumpback = new MutagenBinaryReadStream(streamCreator(), meta);
            using var writer = new System.IO.BinaryWriter(outputStream, Encoding.Default, leaveOpen: true);

            long runningDiff = 0;
            var fileLocs = RecordLocator.GetFileLocations(
                inputStream,
                interest: interest,
                additionalCriteria: (stream, recType, len) =>
                {
                    return stream.GetMajorRecord().IsCompressed;
                });

            // Construct group length container for later use
            Dictionary<long, (uint Length, long Offset)> grupMeta = new Dictionary<long, (uint Length, long Offset)>();
            inputStream.Position = 0;
            while (!inputStream.Complete)
            {
                // Import until next listed major record
                long noRecordLength;
                if (fileLocs.ListedRecords.TryGetInDirection(
                    inputStream.Position,
                    higher: true,
                    result: out var nextRec))
                {
                    var recordLocation = fileLocs.ListedRecords.Keys[nextRec.Key];
                    noRecordLength = recordLocation - inputStream.Position;
                }
                else
                {
                    noRecordLength = inputStream.Length - inputStream.Position;
                }
                inputStream.WriteTo(outputStream, (int)noRecordLength);

                // If complete overall, return
                if (inputStream.Complete) break;
                var majorMeta = inputStream.ReadMajorRecord();
                var len = majorMeta.ContentLength;
                using (var frame = MutagenFrame.ByLength(
                    reader: inputStream,
                    length: len))
                {
                    // Decompress
                    var decompressed = frame.Decompress();
                    var decompressedLen = decompressed.TotalLength;
                    var lengthDiff = decompressedLen - len;
                    var majorMetaSpan = majorMeta.Span.ToArray();

                    // Write major Meta
                    var writableMajorMeta = meta.Constants.MajorRecordWritable(majorMetaSpan.AsSpan());
                    writableMajorMeta.IsCompressed = false;
                    writableMajorMeta.RecordLength = (uint)(len + lengthDiff);
                    writer.Write(majorMetaSpan);
                    writer.Write(decompressed.ReadRemainingSpan(readSafe: false));

                    // If no difference in lengths, move on
                    if (lengthDiff == 0) continue;

                    // Modify parent group lengths
                    foreach (var grupLoc in fileLocs.GetContainingGroupLocations(nextRec.Value.FormID))
                    {
                        if (!grupMeta.TryGetValue(grupLoc, out var loc))
                        {
                            loc.Offset = runningDiff;
                            inputStreamJumpback.Position = grupLoc + 4;
                            loc.Length = inputStreamJumpback.ReadUInt32();
                        }
                        grupMeta[grupLoc] = ((uint)(loc.Length + lengthDiff), loc.Offset);
                    }
                    runningDiff += lengthDiff;
                }
            }

            foreach (var item in grupMeta)
            {
                var grupLoc = item.Key;
                outputStream.Position = grupLoc + 4 + item.Value.Offset;
                writer.Write(item.Value.Length);
            }
        }
    }
}
