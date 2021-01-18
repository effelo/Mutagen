using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class PerkScriptFragmentsBinaryOverlay
        {
            public IReadOnlyList<IIndexedScriptFragmentGetter> Fragments { get; private set; } = null!;

            partial void CustomFactoryEnd(OverlayStream stream, int finalPos, int offset)
            {
                stream.Position = FileNameEndingPos;
                Fragments = BinaryOverlayList.FactoryByCount<IIndexedScriptFragmentGetter>(
                    stream,
                    _package,
                    stream.ReadUInt16(),
                    (s, p) => IndexedScriptFragmentBinaryOverlay.IndexedScriptFragmentFactory(s, p));
            }
        }
    }
}
