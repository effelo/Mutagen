using Mutagen.Bethesda.Binary;
using Mutagen.Bethesda.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Mutagen.Bethesda.UnitTests
{
    public class HeaderExport_Tests
    {
        [Fact]
        public void Overflow()
        {
            Assert.Throws<OverflowException>(() =>
            {
                byte[] b = new byte[ushort.MaxValue + 100];
                byte[] b2 = new byte[ushort.MaxValue + 1];
                using var writer = new MutagenWriter(new MemoryStream(b), GameConstants.Oblivion);
                using var header = HeaderExport.Header(writer, RecordTypes.EDID, ObjectType.Subrecord);
                writer.Write(b2);
            });
        }
    }
}
