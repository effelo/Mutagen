using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class VisualEffect
    {
        [Flags]
        public enum Flag
        {
            RotateToFaceTarget = 0x0001,
            AttachToCamera = 0x0002,
            InheritRotation = 0x0004,
        }
    }
}
