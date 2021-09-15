using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._3_HW;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._3_HWStages
{
    public class Stage6SharpenedBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.HWJobs;

        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage6HW;

        public Stage6HW ThisStage => character.HWExpansion.Stage6HW;

        public int GetCluster => ThisStage.SingingCluster;
        public int GetRemainingCluster => FilterLow(50 - GetCluster);
        public int GetTotalCluster => FilterLow(RemainingJobs * 50 - GetCluster);
        public string GetRemainingPoetics => FormatNumber(GetTotalCluster * 40);
        public async Task SetCluster(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.SingingCluster = value; await OnCharacterUpdate(); } }
        public async Task SetCluster(int value) { ThisStage.SingingCluster += value; await OnCharacterUpdate(); }
    }
}
