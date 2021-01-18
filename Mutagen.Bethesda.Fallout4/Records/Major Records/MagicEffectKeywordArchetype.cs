using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class MagicEffectKeywordArchetype
    {
        public FormLink<IKeyword> Association => new FormLink<IKeyword>(this.AssociationKey);

        public MagicEffectKeywordArchetype()
            : base(TypeEnum.PeakValueModifier)
        {
        }
    }
}
