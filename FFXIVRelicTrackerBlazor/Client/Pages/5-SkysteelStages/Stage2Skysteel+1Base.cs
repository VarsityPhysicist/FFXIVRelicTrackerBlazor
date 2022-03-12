using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._5_Skysteel;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._5_SkysteelStages
{
    public class Stage2Skysteel_1Base : AbstractSkysteelPage
    {
        public override AbstractExpansion TargetExpansion => character.SkysteelExpansion;

        public override StageInfo TargetStage => character.SkysteelExpansion.Stage2Skysteel;

        public override AbstractSkysteel SkysteelClass => character.SkysteelExpansion.Stage2Skysteel;
    }
}
