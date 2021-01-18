using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectNpcArchetype
    {
        public FormLink<INpc> Association => new FormLink<INpc>(this.AssociationKey);

        public MagicEffectNpcArchetype()
            : base(TypeEnum.SummonCreature)
        {
        }
    }
}
