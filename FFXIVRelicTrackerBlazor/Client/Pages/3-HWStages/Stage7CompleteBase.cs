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
    public class Stage7CompleteBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.HWJobs;

        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage7HW;

        public override string WeaponName => WeaponNames.GetWeaponName(GetActiveJob, StageIndex, TargetExpansion.Expansion);

        public override string PreviousWeaponName => WeaponNames.GetWeaponName(GetActiveJob, StageIndex - 1, TargetExpansion.Expansion);

        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Stage7HW ThisStage => character.HWExpansion.Stage7HW;

        public int GetPneumite => ThisStage.Pneumite;
        public async Task SetPneumite(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Pneumite = value; await OnCharacterUpdate(); } }
        public int RemainingPneumite => FilterLow(15 - GetPneumite);
        public int TotalPneumite => FilterLow(RemainingJobs * 15 - GetPneumite);
        public string RemainingPoetics => FormatNumber(TotalPneumite * 100);
        public string RemainingSeals => FormatNumber(TotalPneumite * 4000);

        public int GetDensity => ThisStage.Density;
        public async Task SetDensity(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Density = value; await OnCharacterUpdate(); } }
        public async Task SetDensity(int value) { ThisStage.Density += value; await OnCharacterUpdate(); }

        public bool GetDungeon1 => ThisStage.Dungeons[0];
        public bool GetDungeon2 => ThisStage.Dungeons[1];
        public bool GetDungeon3 => ThisStage.Dungeons[2];

        public async Task SetDungeon1(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { ThisStage.Dungeons[0] = value; await OnCharacterUpdate(); } }
        public async Task SetDungeon2(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { ThisStage.Dungeons[1] = value; await OnCharacterUpdate(); } }
        public async Task SetDungeon3(ChangeEventArgs e) { if (bool.TryParse(e.Value.ToString(), out bool value)) { ThisStage.Dungeons[2] = value; await OnCharacterUpdate(); } }
    }
}
