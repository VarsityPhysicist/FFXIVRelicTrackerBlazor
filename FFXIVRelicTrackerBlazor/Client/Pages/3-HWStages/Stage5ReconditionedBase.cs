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
        public double TreatedSandPercent => TreatedSand / 2.4;
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
        #region Remaining
        public string RemainingUmbrite => FormatNumber(lowRemainingUmbrite) + "-" + FormatNumber(highRemainingUmbrite);
        public string RemainingSand => FormatNumber(lowRemainingSand) + "-" + FormatNumber(highRemainingSand);
        public int RemainingTreated => FilterLow(240 - TreatedSand);
        private int highRemainingUmbrite
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(40 + (120 - TreatedSand) / 3.0) - Umbrite);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 3.0) - Umbrite);
                }
            }
        }
        private int lowRemainingUmbrite
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(20 + (120 - TreatedSand) / 3.0) - Umbrite);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 6.0) - Umbrite);
                }
            }
        }
        private int highRemainingSand
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(40 + (120 - TreatedSand) / 3.0) - Sand);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 3.0) - Sand);
                }
            }
        }
        private int lowRemainingSand
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(20 + (120 - TreatedSand) / 3.0) - Sand);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 6.0) - Sand);
                }
            }
        }
        private int highTotalRemainingUmbrite
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(40 + (120 - TreatedSand) / 3.0) - Umbrite + (RemainingJobs - 1) * 80);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 3.0) - Umbrite + (RemainingJobs - 1) * 80);
                }
            }
        }
        private int lowTotalRemainingUmbrite
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(20 + (120 - TreatedSand) / 3.0) - Umbrite + (RemainingJobs - 1) * 60);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 6.0) - Umbrite + (RemainingJobs - 1) * 60);
                }
            }
        }
        private int highTotalRemainingSand
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(40 + (120 - TreatedSand) / 3.0) - Sand + (RemainingJobs - 1) * 80);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 3.0) - Sand + (RemainingJobs - 1) * 80);
                }
            }
        }
        private int lowTotalRemainingSand
        {
            get
            {
                if (TreatedSand < 120)
                {
                    return FilterLow((int)Math.Ceiling(20 + (120 - TreatedSand) / 3.0) - Sand + (RemainingJobs - 1) * 60);
                }
                else
                {
                    return FilterLow((int)Math.Ceiling((240 - TreatedSand) / 6.0) - Sand + (RemainingJobs - 1) * 60);
                }
            }
        }

        public string TotalUmbrite => FormatNumber(lowTotalRemainingUmbrite) + "-" + FormatNumber(highTotalRemainingUmbrite);
        public string TotalSand => FormatNumber(lowTotalRemainingSand) + "-" + FormatNumber(highTotalRemainingSand);
        public int TotalTreated => FilterLow(240 * RemainingJobs - TreatedSand);

        public string RemainingPoetics => FormatNumber(lowTotalRemainingUmbrite * 75) + "-" + FormatNumber(highTotalRemainingUmbrite * 75);
        #endregion
    }
}
