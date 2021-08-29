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
    public class Stage8LuxBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.HWJobs;

        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage8HW;

        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
        public Stage8HW ThisStage => character.HWExpansion.Stage8HW;

        private async Task SetBools(int stepIndex)
        {
            switch (stepIndex)
            {
                case 1:
                    ThisStage.Step2 = new List<bool>() { false, false, false, false };
                    ThisStage.Step3 = new List<bool>() { false, false };
                    ThisStage.Step4 = new List<bool>() { false, false, false };
                    break;
                case 2:
                    ThisStage.Step1 = new List<bool>() { true, true, true, true };
                    ThisStage.Step3 = new List<bool>() { false, false };
                    ThisStage.Step4 = new List<bool>() { false, false, false };
                    break;
                case 3:
                    ThisStage.Step1 = new List<bool>() { true, true, true, true };
                    ThisStage.Step2 = new List<bool>() { true, true , true , true };
                    ThisStage.Step4 = new List<bool>() { false, false, false };
                    break;
                case 4:
                    ThisStage.Step1 = new List<bool>() { true, true, true, true };
                    ThisStage.Step2 = new List<bool>() { true, true, true, true };
                    ThisStage.Step3 = new List<bool>() { true, true };
                    break;
                default:
                    break;
            }

            await OnCharacterUpdate();
        }

        public bool GetTrial1 => ThisStage.Step1[0];
        public bool GetTrial2 => ThisStage.Step1[1];
        public bool GetTrial3 => ThisStage.Step1[2];
        public bool GetTrial4 => ThisStage.Step2[0];
        public bool GetTrial5 => ThisStage.Step2[1];
        public bool GetTrial6 => ThisStage.Step2[2];
        public bool GetTrial7 => ThisStage.Step2[3];
        public bool GetTrial8 => ThisStage.Step3[0];
        public bool GetTrial9 => ThisStage.Step3[1];
        public bool GetTrial10 => ThisStage.Step4[0];
        public bool GetTrial11 => ThisStage.Step4[1];
        public bool GetTrial12 => ThisStage.Step4[2];

        public async Task SetTrial1(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step1[0] = value; await SetBools(1); } }
        public async Task SetTrial2(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step1[1] = value; await SetBools(1); } }
        public async Task SetTrial3(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step1[2] = value; await SetBools(1); } }
        public async Task SetTrial4(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step2[0] = value; await SetBools(2); } }
        public async Task SetTrial5(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step2[1] = value; await SetBools(2); } }
        public async Task SetTrial6(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step2[2] = value; await SetBools(2); } }
        public async Task SetTrial7(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step2[3] = value; await SetBools(2); } }
        public async Task SetTrial8(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step3[0] = value; await SetBools(3); } }
        public async Task SetTrial9(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step3[1] = value; await SetBools(3); } }
        public async Task SetTrial10(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step4[0] = value; await SetBools(4); } }
        public async Task SetTrial11(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step4[1] = value; await SetBools(4); } }
        public async Task SetTrial12(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step4[2] = value; await SetBools(4); } }
        public async Task SetTrial13(ChangeEventArgs e) { if(bool.TryParse(e.Value.ToString(),out bool value)) { ThisStage.Step4[3] = value; await SetBools(4); } }

        public int GetInk => ThisStage.InkCount;
        public int RemainingInk => FilterLow(RemainingJobs - GetInk);
        public string RemainingPoetics => FormatNumber(RemainingInk * 500);
        public async Task SetInk(ChangeEventArgs e) { if(int.TryParse(e.Value.ToString(),out int value)) { ThisStage.InkCount = value; await OnCharacterUpdate(); } }
    }
}
