﻿using System;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class PlacedArrowBinaryOverlay
        {
            public FormLink<IProjectileGetter> Projectile { get; internal set; } = FormLink<IProjectileGetter>.Null;
        }
    }
}