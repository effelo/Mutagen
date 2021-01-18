using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public interface IWeightValue : IWeightValueGetter
    {
        new uint Value { get; set; }
        new float Weight { get; set; }
    }

    public interface IWeightValueGetter
    {
        uint Value { get; }
        float Weight { get; }
    }
}
