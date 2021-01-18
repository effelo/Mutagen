﻿using System;
using System.Collections.Generic;
using System.Text;
using Mutagen.Bethesda.Binary;
using Noggog;

namespace Mutagen.Bethesda.Fallout4
{
    public partial class DialogResponses
    {
        [Flags]
        public enum MajorFlag
        {
            ActorChanged = 0x0000_2000
        }

        [Flags]
        public enum Flag
        {
            Goodbye = 0x0001,
            Random = 0x0002,
            SayOnce = 0x0004,
            RandomEnd = 0x0020,
            InvisibleContinue = 0x0040,
            WalkAway = 0x0080,
            WalkAwayInvisibleInMenu = 0x0100,
            ForceSubtitle = 0x0200,
            CanMoveWhileGreeting = 0x0400,
            NoLipFile = 0x0800,
            RequiresPostProcessing = 0x1000,
            AudioOutputOverride = 0x2000,
            SpendsFavorPoints = 0x4000,
        }
    }

    namespace Internals
    {
        public partial class DialogResponsesBinaryCreateTranslation
        {
            static partial void FillBinaryConditionsCustom(MutagenFrame frame, IDialogResponsesInternal item)
            {
                ConditionBinaryCreateTranslation.FillConditionsList(item.Conditions, frame);
            }
        }

        public partial class DialogResponsesBinaryWriteTranslation
        {
            static partial void WriteBinaryConditionsCustom(MutagenWriter writer, IDialogResponsesGetter item)
            {
                ConditionBinaryWriteTranslation.WriteConditionsList(item.Conditions, writer);
            }
        }

        public partial class DialogResponsesBinaryOverlay
        {
            public IReadOnlyList<IConditionGetter> Conditions { get; private set; } = ListExt.Empty<IConditionGetter>();

            partial void ConditionsCustomParse(OverlayStream stream, long finalPos, int offset, RecordType type, int? lastParsed)
            {
                Conditions = ConditionBinaryOverlay.ConstructBinayOverlayList(stream, _package);
            }
        }
    }
}
