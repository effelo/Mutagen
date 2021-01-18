﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class RegionObject
    {
        [Flags]
        public enum Flag
        {
            ConformToSlope = 0x001,
            PaintVertices = 0x002,
            SizeVariancePlusMinus = 0x004,
            XPlusMinus = 0x008,
            YPlusMinus = 0x010,
            ZPlusMinus = 0x020,
            Tree = 0x040,
            HugeRock = 0x080,
        }
    }
}
