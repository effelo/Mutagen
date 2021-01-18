﻿using Mutagen.Bethesda.Binary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    namespace Internals
    {
        public partial class PackageAdapterBinaryCreateTranslation
        {
            static partial void FillBinaryScriptFragmentsCustom(MutagenFrame frame, IPackageAdapter item)
            {
                item.ScriptFragments = Mutagen.Bethesda.Fallout4.PackageScriptFragments.CreateFromBinary(frame: frame);
            }
        }

        public partial class PackageAdapterBinaryWriteTranslation
        {
            static partial void WriteBinaryScriptFragmentsCustom(MutagenWriter writer, IPackageAdapterGetter item)
            {
                if (!item.ScriptFragments.TryGet(out var frags)) return;
                frags.WriteToBinary(writer);
            }
        }

        public partial class PackageAdapterBinaryOverlay
        {
            IPackageScriptFragmentsGetter? GetScriptFragmentsCustom(int location)
            {
                if (this.ScriptsEndingPos == _data.Length) return null;
                return PackageScriptFragmentsBinaryOverlay.PackageScriptFragmentsFactory(
                    _data.Slice(this.ScriptsEndingPos),
                    _package);
            }
        }
    }
}
