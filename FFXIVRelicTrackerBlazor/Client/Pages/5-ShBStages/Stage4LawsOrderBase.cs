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
    public class Stage4LawsOrderBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ShBExpansion;

        public override StageInfo TargetStage => character.ShBExpansion.Stage4ShB;

        public Stage4ShB ThisStage => character.ShBExpansion.Stage4ShB;
        public int GetLoathsomeMemory => ThisStage.LoathsomeMemory;
        public async Task SetLoathsomeMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.LoathsomeMemory = value; await OnCharacterUpdate(); } }
        public int RemainingLoathsomeMemory() => FilterLow(RemainingJobs * 15 - GetLoathsomeMemory);
    }
}
