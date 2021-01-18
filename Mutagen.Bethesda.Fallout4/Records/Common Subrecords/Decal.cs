using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Decal
    {
        [Flags]
        public enum Flag
        {
            Parallax = 0x01,
            AlphaBlending = 0x02,
            AlphaTesting = 0x04,
            NoSubtextures = 0x08
        }
    }
}
