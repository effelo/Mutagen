using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Noggog;
using System.IO;
using System.Buffers.Binary;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Fallout4Mod : AMod
    {
        public const uint DefaultInitialNextFormID = 0x800;
        private uint GetDefaultInitialNextFormID() => DefaultInitialNextFormID;

        partial void CustomCtor()
        {
            this.ModHeader.FormVersion = this.Fallout4Release.ToGameRelease().GetDefaultFormVersion()!.Value;
        }
    }

    namespace Internals
    {
        public partial class Fallout4ModCommon
        {
            public static void WriteCellsParallel(
                IListGroupGetter<ICellBlockGetter> group,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                if (group.Records.Count == 0) return;
                Stream[] streams = new Stream[group.Records.Count + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                var groupByteStream = new MemoryStream(groupBytes);
                using (var stream = new MutagenWriter(groupByteStream, gameConstants, dispose: false))
                {
                    stream.Position += 8;
                    ListGroupBinaryWriteTranslation.WriteEmbedded<ICellBlockGetter>(group, stream);
                }
                streams[0] = groupByteStream;
                Parallel.ForEach(group.Records, (cellBlock, state, counter) =>
                {
                    WriteBlocksParallel(
                        cellBlock,
                        masters,
                        (int)counter + 1,
                        gameConstants,
                        streams);
                });
                UtilityTranslation.CompileSetGroupLength(streams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(streams, resetPositions: true);
            }

            public static void WriteBlocksParallel(
                ICellBlockGetter block,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                var subBlocks = block.SubBlocks;
                Stream[] streams = new Stream[(subBlocks?.Count ?? 0) + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                var groupByteStream = new MemoryStream(groupBytes);
                using (var stream = new MutagenWriter(groupByteStream, gameConstants, dispose: false))
                {
                    stream.Position += 8;
                    CellBlockBinaryWriteTranslation.WriteEmbedded(block, stream);
                }
                streams[0] = groupByteStream;
                if (subBlocks != null)
                {
                    Parallel.ForEach(subBlocks, (cellSubBlock, state, counter) =>
                    {
                        WriteSubBlocksParallel(
                            cellSubBlock,
                            masters,
                            (int)counter + 1,
                            gameConstants,
                            streams);
                    });
                }
                UtilityTranslation.CompileSetGroupLength(streams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(streams, resetPositions: true);
            }

            public static void WriteSubBlocksParallel(
                ICellSubBlockGetter subBlock,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                var cells = subBlock.Cells;
                Stream[] streams = new Stream[(cells?.Count ?? 0) + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                var groupByteStream = new MemoryStream(groupBytes);
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                using (var stream = new MutagenWriter(
                    groupByteStream,
                    meta: new WritingBundle(gameConstants)
                    {
                        MasterReferences = masters
                    }, 
                    dispose: false))
                {
                    stream.Position += 8;
                    CellSubBlockBinaryWriteTranslation.WriteEmbedded(subBlock, stream);
                }
                streams[0] = groupByteStream;
                if (cells != null)
                {
                    Parallel.ForEach(cells, (cell, state, counter) =>
                    {
                        MemoryTributary trib = new MemoryTributary();
                        cell.WriteToBinary(new MutagenWriter(
                            trib,
                            new WritingBundle(gameConstants)
                            {
                                MasterReferences = masters
                            },
                            dispose: false));
                        streams[(int)counter + 1] = trib;
                    });
                }
                UtilityTranslation.CompileSetGroupLength(streams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(streams, resetPositions: true);
            }

            public static void WriteWorldspacesParallel(
                IGroupGetter<IWorldspaceGetter> group,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                var cache = group.RecordCache;
                if (cache == null || cache.Count == 0) return;
                Stream[] streams = new Stream[cache.Count + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                var groupByteStream = new MemoryStream(groupBytes);
                using (var stream = new MutagenWriter(groupByteStream, gameConstants, dispose: false))
                {
                    stream.Position += 8;
                    GroupBinaryWriteTranslation.WriteEmbedded<IWorldspaceGetter>(group, stream);
                }
                streams[0] = groupByteStream;
                Parallel.ForEach(group, (worldspace, worldspaceState, worldspaceCounter) =>
                {
                    var worldTrib = new MemoryTributary();
                    var bundle = new WritingBundle(gameConstants)
                    {
                        MasterReferences = masters
                    };
                    using (var writer = new MutagenWriter(worldTrib, bundle, dispose: false))
                    {
                        using (HeaderExport.Header(
                            writer: writer,
                            record: RecordTypes.WRLD,
                            type: ObjectType.Record))
                        {
                            WorldspaceBinaryWriteTranslation.WriteEmbedded(
                                item: worldspace,
                                writer: writer);
                            WorldspaceBinaryWriteTranslation.WriteRecordTypes(
                                item: worldspace,
                                writer: writer,
                                recordTypeConverter: null);
                        }
                    }
                    var topCell = worldspace.TopCell;
                    var subCells = worldspace.SubCells;
                    if (subCells?.Count == 0
                        && topCell == null)
                    {
                        streams[worldspaceCounter + 1] = worldTrib;
                        return;
                    }

                    Stream[] subStreams = new Stream[(subCells?.Count ?? 0) + 1];

                    var worldGroupTrib = new MemoryTributary();
                    var worldGroupWriter = new MutagenWriter(worldGroupTrib, bundle, dispose: false);
                    worldGroupWriter.Write(RecordTypes.GRUP.TypeInt);
                    worldGroupWriter.Write(UtilityTranslation.Zeros.Slice(0, gameConstants.GroupConstants.LengthLength));
                    FormKeyBinaryTranslation.Instance.Write(
                        worldGroupWriter,
                        worldspace.FormKey);
                    worldGroupWriter.Write((int)GroupTypeEnum.WorldChildren);
                    worldGroupWriter.Write(worldspace.SubCellsTimestamp);
                    worldGroupWriter.Write(worldspace.SubCellsUnknown);
                    topCell?.WriteToBinary(worldGroupWriter);
                    subStreams[0] = worldGroupTrib;

                    if (subCells != null)
                    {
                        Parallel.ForEach(subCells, (block, blockState, blockCounter) =>
                        {
                            WriteBlocksParallel(
                                block,
                                masters,
                                (int)blockCounter + 1,
                                gameConstants,
                                subStreams);
                        });
                    }

                    worldGroupWriter.Position = 4;
                    worldGroupWriter.Write((uint)(subStreams.NotNull().Select(s => s.Length).Sum()));
                    streams[worldspaceCounter + 1] = new CompositeReadStream(worldTrib.AsEnumerable().And(subStreams), resetPositions: true);
                });
                UtilityTranslation.CompileSetGroupLength(streams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(streams, resetPositions: true);
            }

            public static void WriteBlocksParallel(
                IWorldspaceBlockGetter block,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                var items = block.Items;
                Stream[] streams = new Stream[(items?.Count ?? 0) + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                var groupByteStream = new MemoryStream(groupBytes);
                using (var stream = new MutagenWriter(groupByteStream, gameConstants, dispose: false))
                {
                    stream.Position += 8;
                    WorldspaceBlockBinaryWriteTranslation.WriteEmbedded(block, stream);
                }
                streams[0] = groupByteStream;
                if (items != null)
                {
                    Parallel.ForEach(items, (subBlock, state, counter) =>
                    {
                        WriteSubBlocksParallel(
                            subBlock,
                            masters,
                            (int)counter + 1,
                            gameConstants,
                            streams);
                    });
                }
                UtilityTranslation.CompileSetGroupLength(streams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(streams, resetPositions: true);
            }

            public static void WriteSubBlocksParallel(
                IWorldspaceSubBlockGetter subBlock,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                var items = subBlock.Items;
                Stream[] streams = new Stream[(items?.Count ?? 0) + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                var groupByteStream = new MemoryStream(groupBytes);
                using (var stream = new MutagenWriter(
                    groupByteStream,
                    new WritingBundle(gameConstants)
                    {
                        MasterReferences = masters
                    },
                    dispose: false))
                {
                    stream.Position += 8;
                    WorldspaceSubBlockBinaryWriteTranslation.WriteEmbedded(subBlock, stream);
                }
                streams[0] = groupByteStream;
                if (items != null)
                {
                    Parallel.ForEach(items, (cell, state, counter) =>
                    {
                        MemoryTributary trib = new MemoryTributary();
                        cell.WriteToBinary(new MutagenWriter(
                            trib,
                            new WritingBundle(gameConstants)
                            {
                                MasterReferences = masters
                            },
                            dispose: false));
                        streams[(int)counter + 1] = trib;
                    });
                }
                UtilityTranslation.CompileSetGroupLength(streams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(streams, resetPositions: true);
            }

            public static void WriteGroupParallel<T>(
                IGroupGetter<T> group,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
                where T : class, IFallout4MajorRecordGetter, IBinaryItem
            {
                if (group.RecordCache.Count == 0) return;
                var cuts = group.Cut(CutCount).ToArray();
                Stream[] subStreams = new Stream[cuts.Length + 1];
                byte[] groupBytes = new byte[gameConstants.GroupConstants.HeaderLength];
                BinaryPrimitives.WriteInt32LittleEndian(groupBytes.AsSpan(), RecordTypes.GRUP.TypeInt);
                var groupByteStream = new MemoryStream(groupBytes);
                using (var stream = new MutagenWriter(groupByteStream, gameConstants, dispose: false))
                {
                    stream.Position += 8;
                    GroupBinaryWriteTranslation.WriteEmbedded<T>(group, stream);
                }
                subStreams[0] = groupByteStream;
                Parallel.ForEach(cuts, (cutItems, state, counter) =>
                {
                    MemoryTributary trib = new MemoryTributary();
                    var bundle = new WritingBundle(gameConstants)
                    {
                        MasterReferences = masters
                    };
                    using (var stream = new MutagenWriter(trib, bundle, dispose: false))
                    {
                        foreach (var item in cutItems)
                        {
                            item.WriteToBinary(stream);
                        }
                    }
                    subStreams[(int)counter + 1] = trib;
                });
                UtilityTranslation.CompileSetGroupLength(subStreams, groupBytes);
                streamDepositArray[targetIndex] = new CompositeReadStream(subStreams, resetPositions: true);
            }

            public static void WriteDialogTopicsParallel(
                IGroupGetter<IDialogTopicGetter> group,
                MasterReferenceReader masters,
                int targetIndex,
                GameConstants gameConstants,
                Stream[] streamDepositArray)
            {
                WriteGroupParallel(group, masters, targetIndex, gameConstants, streamDepositArray);
            }
        }
    }
}
