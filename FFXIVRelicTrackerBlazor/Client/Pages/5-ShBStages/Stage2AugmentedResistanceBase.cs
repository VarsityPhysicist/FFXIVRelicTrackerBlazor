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
    public class Stage2AugmentedResistanceBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ShBExpansion;

        public override StageInfo TargetStage => character.ShBExpansion.Stage2ShB;

        public Stage2ShB ThisStage => character.ShBExpansion.Stage2ShB;

        public int GetHarrowingMemory => ThisStage.HarrowingMemory;
        public async Task SetHarrowingMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.HarrowingMemory = value; await OnCharacterUpdate(); } }
        public int GetSorrowfulMemory => ThisStage.SorrowfulMemory;
        public async Task SetSorrowfulMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.SorrowfulMemory = value; await OnCharacterUpdate(); } }
        public int GetTorturedMemory => ThisStage.TorturedMemory;
        public async Task SetTorturedMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.TorturedMemory = value; await OnCharacterUpdate(); } }

        public int RemainingHarrowingMemory() => FilterLow(RemainingJobs * 20 - GetHarrowingMemory);
        public int RemainingSorrowfulMemory() => FilterLow(RemainingJobs * 20 - GetSorrowfulMemory);
        public int RemainingTorturedMemory() => FilterLow(RemainingJobs * 20 - GetTorturedMemory);
    }
}
