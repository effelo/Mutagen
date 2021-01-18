using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectVampireArchetype
    {
        public FormLink<IRace> Association => new FormLink<IRace>(this.AssociationKey);

        public MagicEffectVampireArchetype()
            : base(TypeEnum.VampireLord)
        {
        }
    }
}
