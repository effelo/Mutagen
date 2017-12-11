﻿using Loqui.Generation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loqui;
using System.Xml.Linq;
using Mutagen.Bethesda.Generation;

namespace Mutagen.Bethesda
{
    public class DataType : SetMarkerType
    {
        public override async Task Load(XElement node, bool requireName = true)
        {
            var data = this.CustomData.TryCreateValue(Mutagen.Bethesda.Generation.Constants.DATA_KEY, () => new MutagenFieldData(this)) as MutagenFieldData;
            if (node.TryGetAttribute("recordType", out var recType))
            {
                data.RecordType = new RecordType(recType.Value);
            }
            else
            {
                data.RecordType = new RecordType("DATA");
            }
            await base.Load(node, requireName: false);
        }
    }
}