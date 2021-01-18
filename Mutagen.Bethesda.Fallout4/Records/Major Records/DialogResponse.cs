using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class DialogResponse
    {
        [Flags]
        public enum Flag
        {
            UseEmotionAnimation = 0x01
        }
    }
}
