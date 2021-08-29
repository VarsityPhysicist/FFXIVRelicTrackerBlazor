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
    public class Stage5ReconditionedBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.HWJobs;

        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage5HW;
        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Stage5HW ThisStage => character.HWExpansion.Stage5HW;

        #region GetProperties
        public int Umbrite => ThisStage.Umbrite;
        public int Sand => ThisStage.CrystalSand;
        public int TreatedSand => ThisStage.TreatedSand;
        public double TreatedSandPercent => TreatedSand / 2.4;
        #endregion

        #region SetProperties
        public async Task SetUmbrite(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Umbrite = value; await OnCharacterUpdate(); } }
        public async Task SetSand(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.CrystalSand = value; await OnCharacterUpdate(); } }
        public async Task SetTreated(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.TreatedSand = value; await OnCharacterUpdate(); } }
        public async Task IncreasTreated(int value)
        {
            ThisStage.Umbrite -= value;
            ThisStage.CrystalSand -= value;
            ThisStage.TreatedSand += value;
            await OnCharacterUpdate();
        }
        #endregion
        #region Remaining
        public string RemainingUmbrite => FormatNumber(FilterLow(60 - Umbrite)) + "-" + FormatNumber(FilterLow(80 - Umbrite));
        public string RemainingSand => FormatNumber(FilterLow(60 - Sand)) + "-" + FormatNumber(FilterLow(80 - Sand));
        public int RemainingTreated => FilterLow(240 - TreatedSand);

        public string TotalUmbrite => FormatNumber(FilterLow(RemainingJobs * 60 - Umbrite)) + "-" + FormatNumber(FilterLow(RemainingJobs * 80 - Umbrite));
        public string TotalSand => FormatNumber(FilterLow(RemainingJobs * 60 - Sand)) + "-" + FormatNumber(FilterLow(RemainingJobs * 80 - Sand));
        public int TotalTreated => FilterLow(240 * RemainingJobs - TreatedSand);

        public string RemainingPoetics => FormatNumber(FilterLow(RemainingJobs * 60 * 75 - Umbrite)) + "-" + FormatNumber(FilterLow(RemainingJobs * 80 * 75 - Umbrite));
        #endregion
    }
}
