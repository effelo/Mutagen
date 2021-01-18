using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class PackageRoot
    {
        [Flags]
        public enum Flag
        {
            RepeatWhenComplete = 0x01
        }
    }
}
