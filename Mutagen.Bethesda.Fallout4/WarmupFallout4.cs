﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Fallout4
{
    public static partial class WarmupFallout4
    {
        static partial void InitCustom()
        {
            lock (OverrideMixIns.AddAsOverrideMasks)
            {
                OverrideMixIns.AddAsOverrideMasks[typeof(ICell)] = ModContextExt.CellCopyMask;
                OverrideMixIns.AddAsOverrideMasks[typeof(ICellGetter)] = ModContextExt.CellCopyMask;
                OverrideMixIns.AddAsOverrideMasks[typeof(Cell)] = ModContextExt.CellCopyMask;
                OverrideMixIns.AddAsOverrideMasks[typeof(IWorldspace)] = ModContextExt.WorldspaceCopyMask;
                OverrideMixIns.AddAsOverrideMasks[typeof(IWorldspaceGetter)] = ModContextExt.WorldspaceCopyMask;
                OverrideMixIns.AddAsOverrideMasks[typeof(Worldspace)] = ModContextExt.WorldspaceCopyMask;
            }
        }
    }
}
