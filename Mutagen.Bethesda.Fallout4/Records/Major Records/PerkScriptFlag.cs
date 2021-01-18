﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class PerkScriptFlag
    {
        [Flags]
        public enum Flag
        {
            RunImmediately = 0x01,
            ReplaceDefault = 0x02,
        }
    }
}
