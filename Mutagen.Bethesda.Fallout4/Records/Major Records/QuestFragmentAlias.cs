﻿using Mutagen.Bethesda.Binary;
using Noggog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class QuestFragmentAliasBinaryCreateTranslation
        {
            static partial void FillBinaryPropertyCustom(MutagenFrame frame, IQuestFragmentAlias item)
            {
                // Preparse object format
                var pos = frame.Position;
                frame.Position += 10;
                var format = frame.ReadUInt16();
                frame.Position = pos;

                var obj = new ScriptObjectProperty();
                AVirtualMachineAdapterBinaryCreateTranslation.FillObject(frame, obj, format);
                item.Property = obj;
            }

            static partial void FillBinaryScriptsCustom(MutagenFrame frame, IQuestFragmentAlias item)
            {
                item.Scripts.AddRange(AVirtualMachineAdapterBinaryCreateTranslation.ReadEntries(frame, item.ObjectFormat));
            }
        }

        public partial class QuestFragmentAliasBinaryWriteTranslation
        {
            static partial void WriteBinaryScriptsCustom(MutagenWriter writer, IQuestFragmentAliasGetter item)
            {
                AVirtualMachineAdapterBinaryWriteTranslation.WriteScripts(writer, item.ObjectFormat, item.Scripts);
            }

            static partial void WriteBinaryPropertyCustom(MutagenWriter writer, IQuestFragmentAliasGetter item)
            {
                AVirtualMachineAdapterBinaryWriteTranslation.WriteObject(writer, item.Property, item.ObjectFormat);
            }
        }

        public partial class QuestFragmentAliasBinaryOverlay
        {
            public IReadOnlyList<IScriptEntryGetter> Scripts { get; private set; } = null!;

            public IScriptObjectPropertyGetter GetPropertyCustom(int location) => throw new NotImplementedException();

            partial void CustomCtor()
            {
                var frame = new MutagenFrame(new MutagenMemoryReadStream(_data, _package.MetaData))
                {
                    Position = PropertyEndingPos + 0x4
                };
                var ret = new ExtendedList<IScriptEntryGetter>();
                ret.AddRange(VirtualMachineAdapterBinaryCreateTranslation.ReadEntries(frame, this.ObjectFormat));
                this.Scripts = ret;
                this.ScriptsEndingPos = checked((int)frame.Position);
            }
        }
    }
}
