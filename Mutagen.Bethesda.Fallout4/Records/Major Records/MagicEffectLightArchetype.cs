using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectLightArchetype
    {
        public FormLink<ILight> Association => new FormLink<ILight>(this.AssociationKey);

        public MagicEffectLightArchetype()
            : base(TypeEnum.Light)
        {
        }
    }
}
