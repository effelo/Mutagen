using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ActivateParents
    {
        [Flags]
        public enum Flag
        {
            ParentActivateOnly = 0x01
        }
    }
}
