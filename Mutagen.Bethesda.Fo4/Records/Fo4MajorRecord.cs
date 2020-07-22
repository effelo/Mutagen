using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fo4
{
    public partial class Fo4MajorRecord
    {
        protected override ushort? FormVersionAbstract => this.FormVersion;
    }

    namespace Internals
    {
        public partial class Fo4MajorRecordBinaryOverlay
        {
            protected override ushort? FormVersionAbstract => this.FormVersion;
        }
    }
}
