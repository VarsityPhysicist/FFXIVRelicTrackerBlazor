using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public class SkysteelExpansion : AbstractExpansion
    {
        public override ExpansionName Expansion => ExpansionName.Skysteel;

        public override int StageCount => 6;

        public SkysteelExpansion()
        {
            GenerateJobs();

            Stage1Skysteel = new Stage1Skysteel();
            Stage2Skysteel = new Stage2Skysteel();
            Stage3Skysteel = new Stage3Skysteel();
            Stage4Skysteel = new Stage4Skysteel();
            Stage5Skysteel = new Stage5Skysteel();
            Stage6Skysteel = new Stage6Skysteel();
        }

        public Stage1Skysteel Stage1Skysteel { get; set; }
        public Stage2Skysteel Stage2Skysteel { get; set; }
        public Stage3Skysteel Stage3Skysteel { get; set; }
        public Stage4Skysteel Stage4Skysteel { get; set; }
        public Stage5Skysteel Stage5Skysteel { get; set; }
        public Stage6Skysteel Stage6Skysteel { get; set; }

        public override List<StageInfo> GetStages()
        {
            return new List<StageInfo>()
            {
                Stage1Skysteel,
                Stage2Skysteel,
                Stage3Skysteel,
                Stage4Skysteel,
                Stage5Skysteel,
                Stage6Skysteel
            };
        }
    }
}
