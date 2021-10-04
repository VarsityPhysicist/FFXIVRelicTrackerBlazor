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
    public class Stage5AugmentedLawsOrderBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ShBExpansion;

        public override StageInfo TargetStage => character.ShBExpansion.Stage5ShB;
        public Stage5ShB ThisStage => character.ShBExpansion.Stage5ShB;

        public int GetHauntingMemory => ThisStage.HauntingMemory;
        public async Task SetHauntingMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.HauntingMemory = value; await OnCharacterUpdate(); } }
        public int GetVexatiousMemory => ThisStage.VexatiousMemory;
        public async Task SetVexatiousMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.VexatiousMemory = value; await OnCharacterUpdate(); } }
        public int GetTimewornArtifact => ThisStage.TimewornArtifact;
        public async Task SetTimewornArtifact(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.TimewornArtifact = value; await OnCharacterUpdate(); } }

        public int RemainingHauntingMemory() => FilterLow(18 - GetHauntingMemory);
        public int RemainingVexatiousMemory() => FilterLow(18 - GetVexatiousMemory);
        public int RemainingTimewornArtifact() => FilterLow(RemainingJobs*15 - GetTimewornArtifact);
        public bool DisplayRequirements() => RemainingHauntingMemory() + RemainingVexatiousMemory() != 0;

        public async Task ResetRequirements()
        {
            ThisStage.HauntingMemory = 0;
            ThisStage.VexatiousMemory = 0;

            await OnCharacterUpdate();
        }
    }
}
