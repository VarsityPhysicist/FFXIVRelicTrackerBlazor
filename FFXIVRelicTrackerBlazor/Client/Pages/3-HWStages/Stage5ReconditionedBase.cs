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
        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage5HW;
        public Stage5HW ThisStage => character.HWExpansion.Stage5HW;

        #region GetProperties
        public int Umbrite => ThisStage.Umbrite;
        public int Sand => ThisStage.CrystalSand;
        public int TreatedSand => ThisStage.TreatedSand;
        public double TreatedSandPercent => TreatedSand / 1.8;
        #endregion

        #region SetProperties
        public async Task SetUmbrite(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.Umbrite = value; await OnCharacterUpdate(); } }
        public async Task SetSand(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.CrystalSand = value; await OnCharacterUpdate(); } }
        public async Task SetTreated(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.TreatedSand = value; await OnCharacterUpdate(); } }
        public async Task IncreasTreated(int value)
        {
            ThisStage.Umbrite -= 1;
            ThisStage.CrystalSand -= 1;
            ThisStage.TreatedSand += value;
            await OnCharacterUpdate();
        }
        #endregion
        private int maxSandNeeded = 180;
        private int sandThreshold = 90;
        #region Remaining
        public string RemainingUmbrite => FormatNumber(lowRemainingUmbrite) + "-" + FormatNumber(highRemainingUmbrite);
        public string RemainingSand => FormatNumber(lowRemainingSand) + "-" + FormatNumber(highRemainingSand);
        public int RemainingTreated => FilterLow(maxSandNeeded - TreatedSand);
        private int highRemainingUmbrite
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 3 + (sandThreshold - TreatedSand) / 3.0) - Umbrite);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 3.0) - Umbrite);
                }
            }
        }
        private int lowRemainingUmbrite
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 6 + (sandThreshold - TreatedSand) / 3.0) - Umbrite);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 6.0) - Umbrite);
                }
            }
        }
        private int highRemainingSand
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold/3 + (sandThreshold - TreatedSand) / 3.0) - Sand);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 3.0) - Sand);
                }
            }
        }
        private int lowRemainingSand
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 6 + (sandThreshold - TreatedSand) / 3.0) - Sand);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 6.0) - Sand);
                }
            }
        }
        private int highTotalRemainingUmbrite
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 3 + (sandThreshold - TreatedSand) / 3.0) - Umbrite + (RemainingJobs - 1) * maxSandNeeded / 3);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 3.0) - Umbrite + (RemainingJobs - 1) * maxSandNeeded / 3);
                }
            }
        }
        private int lowTotalRemainingUmbrite
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 6 + (sandThreshold - TreatedSand) / 3.0) - Umbrite + (RemainingJobs - 1) * (sandThreshold / 3 + sandThreshold / 6));
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 6.0) - Umbrite + (RemainingJobs - 1) * (sandThreshold / 3 + sandThreshold / 6));
                }
            }
        }
        private int highTotalRemainingSand
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 3 + (sandThreshold - TreatedSand) / 3.0) - Sand + (RemainingJobs - 1) * maxSandNeeded / 3);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 3.0) - Sand + (RemainingJobs - 1) * maxSandNeeded/3);
                }
            }
        }
        private int lowTotalRemainingSand
        {
            get
            {
                if (TreatedSand < sandThreshold)
                {
                    return FilterLow((int)Math.Ceiling(sandThreshold / 6 + (sandThreshold - TreatedSand) / 3.0) - Sand + (RemainingJobs - 1) * (sandThreshold / 3 + sandThreshold / 6));
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((maxSandNeeded - TreatedSand) / 6.0) - Sand + (RemainingJobs - 1) * (sandThreshold/3+ sandThreshold/6));
                }
            }
        }

        public string TotalUmbrite => FormatNumber(lowTotalRemainingUmbrite) + "-" + FormatNumber(highTotalRemainingUmbrite);
        public string TotalSand => FormatNumber(lowTotalRemainingSand) + "-" + FormatNumber(highTotalRemainingSand);
        public int TotalTreated => FilterLow(maxSandNeeded * RemainingJobs - TreatedSand);

        public string RemainingPoetics => FormatNumber(lowTotalRemainingUmbrite * 75) + "-" + FormatNumber(highTotalRemainingUmbrite * 75);
        #endregion
    }
}
