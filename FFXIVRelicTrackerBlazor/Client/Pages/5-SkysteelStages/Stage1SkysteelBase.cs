using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._5_SkysteelStages
{
    public class Stage1SkysteelBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.SkysteelExpansion;

        public override StageInfo TargetStage => character.SkysteelExpansion.Stage1Skysteel;
    }
}
