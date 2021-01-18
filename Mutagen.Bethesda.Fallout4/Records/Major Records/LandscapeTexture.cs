using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class LandscapeTexture
    {
        [Flags]
        public enum Flag
        {
            /// <summary>
            /// SSE Only
            /// </summary>
            IsSnow = 0x01,
        }
    }
}
