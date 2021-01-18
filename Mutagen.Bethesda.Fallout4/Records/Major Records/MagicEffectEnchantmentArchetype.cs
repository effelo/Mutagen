using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectEnchantmentArchetype
    {
        public FormLink<IObjectEffect> Association => new FormLink<IObjectEffect>(this.AssociationKey);

        public MagicEffectEnchantmentArchetype()
            : base(TypeEnum.EnhanceWeapon)
        {
        }
    }
}
