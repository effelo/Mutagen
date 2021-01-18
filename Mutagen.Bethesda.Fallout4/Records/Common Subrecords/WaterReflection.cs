using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class WaterReflection
    {
        [Flags]
        public enum Flag
        {
            Reflection = 0x1,
            Refraction = 0x2,
        }
    }
}
