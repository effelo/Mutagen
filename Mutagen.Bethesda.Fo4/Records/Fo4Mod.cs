using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using Noggog;
using System.IO;
using System.Buffers.Binary;
using Loqui.Xml;

namespace Mutagen.Bethesda.Fo4
{
    public partial class Fo4Mod : AMod
    {
        public const uint DefaultInitialNextObjectID = 0x800;
        private uint GetDefaultInitialNextObjectID() => throw new NotImplementedException();
    }

    namespace Internals
    {
        public partial class Fo4ModBinaryWriteTranslation
        {
            public static void WriteModHeader(
                IFo4ModGetter mod,
                MutagenWriter writer,
                ModKey modKey)
            {
                var modHeader = mod.ModHeader.DeepCopy() as ModHeader;
                modHeader.Flags = modHeader.Flags.SetFlag(ModHeader.HeaderFlag.Master, modKey.Master);
                modHeader.MasterReferences.SetTo(writer.MetaData.MasterReferences!.Masters.Select(m => m.DeepCopy()));
                modHeader.WriteToBinary(writer);
            }
        }
     }
 }
