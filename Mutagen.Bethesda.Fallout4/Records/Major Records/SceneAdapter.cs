using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Fallout4.Internals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class SceneAdapterBinaryCreateTranslation
        {
            static partial void FillBinaryScriptFragmentsCustom(MutagenFrame frame, ISceneAdapter item)
            {
                item.ScriptFragments = Mutagen.Bethesda.Fallout4.SceneScriptFragments.CreateFromBinary(frame: frame);
            }
        }

        public partial class SceneAdapterBinaryWriteTranslation
        {
            static partial void WriteBinaryScriptFragmentsCustom(MutagenWriter writer, ISceneAdapterGetter item)
            {
                if (!item.ScriptFragments.TryGet(out var frags)) return;
                frags.WriteToBinary(writer);
            }
        }

        public partial class SceneAdapterBinaryOverlay
        {
            ISceneScriptFragmentsGetter? GetScriptFragmentsCustom(int location)
            {
                if (this.ScriptsEndingPos == _data.Length) return null;
                return SceneScriptFragmentsBinaryOverlay.SceneScriptFragmentsFactory(
                    _data.Slice(this.ScriptsEndingPos),
                    _package);
            }
        }
    }
}
