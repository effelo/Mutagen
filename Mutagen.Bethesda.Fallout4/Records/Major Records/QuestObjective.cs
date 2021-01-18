using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class QuestObjective
    {
        [Flags]
        public enum Flag
        {
            OrWithPrevious = 0x1,
        }
    }
}
