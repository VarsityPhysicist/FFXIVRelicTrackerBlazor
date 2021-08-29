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
    public class Stage4HyperconductiveBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.HWJobs;

        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage4HW;

        public override string WeaponName => WeaponNames.GetWeaponName(GetActiveJob, StageIndex, ExpansionName.HW);

        public override string PreviousWeaponName => WeaponNames.GetWeaponName(GetActiveJob, StageIndex-1, ExpansionName.HW);

        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Stage4HW ThisStage => character.HWExpansion.Stage4HW;

        public int OilCount => ThisStage.OilCount;
        public async Task SetOilCount(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.OilCount = value; await OnCharacterUpdate(); } }
        public int RemainingOil => FilterLow(RemainingJobs * 5 - OilCount);
        public string RemainingPoetics => FormatNumber(RemainingOil * 350);
    }
}
