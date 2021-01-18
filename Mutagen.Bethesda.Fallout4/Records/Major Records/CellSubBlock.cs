using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        partial class CellSubBlockBinaryOverlay
        {
            public IReadOnlyList<ICellGetter> Cells { get; private set; } = ListExt.Empty<ICellGetter>();

            partial void CellsCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, int? lastParsed)
            {
                this.Cells = BinaryOverlayList.FactoryByArray<CellBinaryOverlay>(
                    mem: stream.RemainingMemory,
                    package: _package,
                    recordTypeConverter: null,
                    getter: (s, p, recConv) => CellBinaryOverlay.CellFactory(new OverlayStream(s, p), p, recConv),
                    locs: CellBinaryOverlay.ParseRecordLocations(
                        stream: stream,
                        package: _package));
            }
        }
    }
}
