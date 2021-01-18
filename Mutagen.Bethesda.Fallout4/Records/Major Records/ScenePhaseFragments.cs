using Mutagen.Bethesda.Binary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class SceneScriptFragmentsBinaryOverlay
        {
            partial void CustomFactoryEnd(OverlayStream stream, int finalPos, int offset)
            {
                Initialize(stream);
            }
        }
    }
}
