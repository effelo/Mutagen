using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class AttackData
    {
        [Flags]
        public enum Flag : uint
        {
            IgnoreWeapon = 0x0001,
            BashAttack = 0x0002,
            PowerAttack = 0x0004,
            LeftAttack = 0x0008,
            RotatingAttack = 0x0010,
            OverrideData = 0x80000000,
        }
    }
}
