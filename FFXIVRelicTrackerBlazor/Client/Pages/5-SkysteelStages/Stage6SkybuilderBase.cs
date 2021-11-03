using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._5_Skysteel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._5_SkysteelStages
{
    public class Stage6SkybuilderBase : AbstractSkysteelPage
    {
        public override AbstractExpansion TargetExpansion => character.SkysteelExpansion;

        public override StageInfo TargetStage => character.SkysteelExpansion.Stage6Skysteel;

        public override AbstractSkysteel SkysteelClass => character.SkysteelExpansion.Stage6Skysteel;
    }
}
