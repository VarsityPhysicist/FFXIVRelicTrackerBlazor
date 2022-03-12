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
    public class Stage3RecollectionBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ShBExpansion;

        public override StageInfo TargetStage => character.ShBExpansion.Stage3ShB;

        public Stage3ShB ThisStage => character.ShBExpansion.Stage3ShB;
        public int GetBitterMemory => ThisStage.BitterMemory;
        public async Task SetBitterMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.BitterMemory = value; await OnCharacterUpdate(); } }
        public int RemainingBitterMemory() => FilterLow(RemainingJobs * 6 - GetBitterMemory);
    }
}
