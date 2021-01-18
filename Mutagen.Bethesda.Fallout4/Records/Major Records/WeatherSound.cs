using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class WeatherSound
    {
        [Flags]
        public enum TypeEnum
        {
            Default = 1,
            Precipitation = 2,
            Wind = 4,
            Thunder = 8
        }
    }
}
