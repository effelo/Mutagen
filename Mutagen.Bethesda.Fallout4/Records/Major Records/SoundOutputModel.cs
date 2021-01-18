using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class SoundOutputModel
    {
        [Flags]
        public enum Flag
        {
            AttenuatesWithDistance = 0x01,
            AllowsRumble = 0x02,
        }

        public enum TypeEnum
        {
            UsesHrtf,
            DefinedSpeakerOutput,
        }
    }
}
