using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class QuestStage
    {
        [Flags]
        public enum Flag
        {
            StartUpStage = 0x02,
            ShutDownStage = 0x04,
            KeepInstanceDataFromHereOn = 0x08,
        }
    }
}
