using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._5_Skysteel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._5_SkysteelStages
{
    public class Stage3DragonsungBase : AbstractSkysteelPage
    {
        public override AbstractExpansion TargetExpansion => character.SkysteelExpansion;

        public override StageInfo TargetStage => character.SkysteelExpansion.Stage3Skysteel;

        public override AbstractSkysteel SkysteelClass => character.SkysteelExpansion.Stage3Skysteel;
    }
}
