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
    public class Stage2AwokenBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage2HW;

        public Stage2HW ThisStage => character.HWExpansion.Stage2HW;

        private AwokenStep AwokenStep => ThisStage.AwokenStep;
        private async Task SetAwokenStep(AwokenStep awokenStep)
        {
            if (AwokenStep >= awokenStep) ThisStage.AwokenStep = (awokenStep - 1);
            else ThisStage.AwokenStep = awokenStep;
            await OnCharacterUpdate();
        }

        #region GetSteps
        public bool Step1 => AwokenStep >= AwokenStep.Step1;
        public bool Step2 => AwokenStep >= AwokenStep.Step2;
        public bool Step3 => AwokenStep >= AwokenStep.Step3;
        public bool Step4 => AwokenStep >= AwokenStep.Step4;
        public bool Step5 => AwokenStep >= AwokenStep.Step5;
        public bool Step6 => AwokenStep >= AwokenStep.Step6;
        public bool Step7 => AwokenStep >= AwokenStep.Step7;
        public bool Step8 => AwokenStep >= AwokenStep.Step8;
        public bool Step9 => AwokenStep >= AwokenStep.Step9;
        public bool Step10 => AwokenStep >= AwokenStep.Step10;
        #endregion

        #region SetSteps
        public async Task SetStep1(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step1); await OnCharacterUpdate(); } }
        public async Task SetStep2(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step2); await OnCharacterUpdate(); } }
        public async Task SetStep3(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step3); await OnCharacterUpdate(); } }
        public async Task SetStep4(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step4); await OnCharacterUpdate(); } }
        public async Task SetStep5(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step5); await OnCharacterUpdate(); } }
        public async Task SetStep6(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step6); await OnCharacterUpdate(); } }
        public async Task SetStep7(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step7); await OnCharacterUpdate(); } }
        public async Task SetStep8(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step8); await OnCharacterUpdate(); } }
        public async Task SetStep9(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step9); await OnCharacterUpdate(); } }
        public async Task SetStep10(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { await SetAwokenStep(AwokenStep.Step10); await OnCharacterUpdate(); } }
        #endregion

    }
}
