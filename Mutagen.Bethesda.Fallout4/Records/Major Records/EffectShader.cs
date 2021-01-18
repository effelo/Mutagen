﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class EffectShader
    {
        public enum BlendMode
        {
            Zero = 1,
            One = 2,
            SourceColor = 3,
            SourceInverseColor = 4,
            SourceAlpha = 5,
            SourceInvertedAlpha = 6,
            DestAlpha = 7,
            DestInvertedAlpha = 8,
            DestColor = 9,
            DestInverseColor = 10,
            SourceAlphaSat = 11,
        }
        
        public enum BlendOperation
        {
            Add = 1,
            Subtract = 2,
            ReverseSubtract = 3,
            Minimum = 4,
            Maximum = 5,
        }

        public enum ZTest
        {
            EqualTo = 3,
            Normal = 4,
            GreaterThan = 5,
            GreaterThanOrEqualTo = 7,
            AlwaysShow = 8,
        }

        [Flags]
        public enum Flag
        {
            NoMembraneShader = 0x0000_0001,
            MembraneGrayscaleColor = 0x0000_0002,
            MembraneGrayscaleAlpha = 0x0000_0004,
            NoParticleShader = 0x0000_0008,
            EdgeEffectInverse = 0x0000_0010,
            AffectSkinOnly = 0x0000_0020,
            IgnoreAlpha = 0x0000_0040,
            ProjectUVs = 0x0000_0080,
            IgnoreBaseGeometryAlpha = 0x0000_0100,
            Lighting = 0x0000_0200,
            NoWeapons = 0x0000_0400,
            ParticleAnimated = 0x0000_8000,
            ParticleGrayscaleColor = 0x0001_0000,
            ParticleGrayscaleAlpha = 0x0002_0000,
            UseBloodGeometry = 0x0100_0000
        }
    }
}
