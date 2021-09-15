using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._5_ShB;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._5_ShBStages
{
    public class Stage1ResistanceBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ShBJobs;

        public override AbstractExpansion TargetExpansion => character.ShBExpansion;

        public override StageInfo TargetStage => character.ShBExpansion.Stage1ShB;

        public Stage1ShB ThisStage => character.ShBExpansion.Stage1ShB;

        public int GetScalePowder => ThisStage.ScalePowder;
        public string RemainingScalepowder() => FormatNumber((RemainingJobs-1) * 4 - GetScalePowder);
        public string RemainingPoetics() => FormatNumber(((RemainingJobs-1) * 4 - GetScalePowder) * 250);
        public async Task SetScalePowder(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.ScalePowder = value; await OnCharacterUpdate(); } }
    }
}
