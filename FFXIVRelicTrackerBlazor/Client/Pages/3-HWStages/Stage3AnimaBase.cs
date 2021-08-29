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
    public class Stage3AnimaBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.HWJobs;

        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage3HW;
        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Stage3HW ThisStage => character.HWExpansion.Stage3HW;

        #region GetProperties
        public int Bone => ThisStage.Bone;
        public int Shell => ThisStage.Shell;
        public int Ore => ThisStage.Ore;
        public int Seeds => ThisStage.Seeds;
        public int Francesca => ThisStage.Francesca;
        public int Mirror => ThisStage.Mirror;
        public int Arrow => ThisStage.Arrow;
        public int Kingcake => ThisStage.Kingcake;
        #endregion

        #region SetProperties
        public async Task SetBone(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Bone = value; await OnCharacterUpdate(); } }
        public async Task SetShell(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Shell = value; await OnCharacterUpdate(); } }
        public async Task SetOre(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Ore = value; await OnCharacterUpdate(); } }
        public async Task SetSeeds(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Seeds = value; await OnCharacterUpdate(); } }
        public async Task SetFrancesca(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Francesca = value; await OnCharacterUpdate(); } }
        public async Task SetMirror(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Mirror = value; await OnCharacterUpdate(); } }
        public async Task SetArrow(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Arrow = value; await OnCharacterUpdate(); } }
        public async Task SetKingcake(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Kingcake = value; await OnCharacterUpdate(); } }
        #endregion

        #region Remaining
        public int RemainingBone => FilterLow(10 * RemainingJobs - Bone);
        public int RemainingShell => FilterLow(10 * RemainingJobs - Shell);
        public int RemainingOre => FilterLow(10 * RemainingJobs - Ore);
        public int RemainingSeeds => FilterLow(10 * RemainingJobs - Seeds);
        public int RemainingFrancesca => FilterLow(4 * RemainingJobs - Francesca);
        public int RemainingMirror => FilterLow(4 * RemainingJobs - Mirror);
        public int RemainingArrow => FilterLow(4 * RemainingJobs - Arrow);
        public int RemainingKingcake => FilterLow(4 * RemainingJobs - Kingcake);

        public string RemainingPoetics => FormatNumber(150 * (RemainingBone + RemainingShell + RemainingOre + RemainingSeeds));
        public string RemainingTokens => FormatNumber(6 * (RemainingBone + RemainingShell + RemainingOre + RemainingSeeds));
        public string RemainingSeals => FormatNumber(5000 * (RemainingFrancesca + RemainingMirror + RemainingArrow + RemainingKingcake));
        #endregion
    }
}
