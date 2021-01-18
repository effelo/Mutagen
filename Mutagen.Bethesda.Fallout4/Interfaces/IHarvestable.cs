using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    /// <summary>
    /// Common interface for records that can be harvested
    /// </summary>
    public interface IHarvestable : IFallout4MajorRecordInternal, IHarvestableGetter
    {
        new FormLinkNullable<IHarvestTargetGetter> Ingredient { get; set; }
        new FormLinkNullable<ISoundDescriptorGetter> HarvestSound { get; set; }
    }

    /// <summary>
    /// Common interface for records that can be harvested
    /// </summary>
    public interface IHarvestableGetter : IFallout4MajorRecordGetter
    {
        FormLinkNullable<IHarvestTargetGetter> Ingredient { get; }
        FormLinkNullable<ISoundDescriptorGetter> HarvestSound { get; }
    }
}
