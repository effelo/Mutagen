using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectWerewolfArchetype
    {
        public FormLink<IRace> Association => new FormLink<IRace>(this.AssociationKey);

        public MagicEffectWerewolfArchetype()
            : base(TypeEnum.Werewolf)
        {
        }
    }
}
