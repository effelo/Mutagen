using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class ScriptProperty
    {
        public enum Flag
        {
            Edited = 0x01,
            Removed = 0x03
        }

        public enum Type
        {
            None = 0,
            Object = 1,
            String = 2,
            Int = 3,
            Float = 4,
            Bool = 5,
            ArrayOfObject = 11,
            ArrayOfString = 12,
            ArrayOfInt = 13,
            ArrayOfFloat = 14,
            ArrayOfBool = 15,
        }
    }

    namespace Internals
    {
        public partial class ScriptPropertyBinaryOverlay
        {
            public string Name => throw new NotImplementedException();

            public ScriptProperty.Flag Flags => throw new NotImplementedException();
        }
    }
}
