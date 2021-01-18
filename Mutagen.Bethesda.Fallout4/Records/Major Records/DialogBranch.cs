﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class DialogBranch
    {
        [Flags]
        public enum Flag
        {
            TopLevel = 0x01,
            Blocking = 0x02,
            Exclusive = 0x04,
        }
    }
}
