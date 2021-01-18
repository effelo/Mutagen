using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class Eyes
    {
        #region Interfaces
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string INamedRequiredGetter.Name => this.Name?.String ?? string.Empty;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        string INamedRequired.Name
        {
            get => this.Name?.String ?? string.Empty;
            set => this.Name = new TranslatedString(value);
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        ITranslatedStringGetter ITranslatedNamedRequiredGetter.Name => this.Name ?? TranslatedString.Empty;
        #endregion

        [Flags]
        public enum MajorFlag
        {
            NonPlayable = 0x0000_0004,
        }

        [Flags]
        public enum Flag
        {
            Playable = 0x01,
            NotMale = 0x02,
            NotFemale = 0x04,
        }
    }

    namespace Internals
    {
        public partial class EyesBinaryOverlay
        {
            #region Interfaces
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            string INamedRequiredGetter.Name => this.Name?.String ?? string.Empty;
            #endregion
        }
    }
}
