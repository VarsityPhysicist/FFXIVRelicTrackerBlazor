using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class HWExpansion : AbstractExpansion
    {
        public override ExpansionName Expansion => ExpansionName.HW;

        public override int StageCount => 8;
        public HWExpansion()
        {
            GenerateJobs();

            Stage1HW = new Stage1HW();
            Stage2HW = new Stage2HW();
            Stage3HW = new Stage3HW();
            Stage4HW = new Stage4HW();
            Stage5HW = new Stage5HW();
            Stage6HW = new Stage6HW();
            Stage7HW = new Stage7HW();
            Stage8HW = new Stage8HW();
        }

        public Stage1HW Stage1HW { get; set; }
        public Stage2HW Stage2HW { get; set; }
        public Stage3HW Stage3HW { get; set; }
        public Stage4HW Stage4HW { get; set; }
        public Stage5HW Stage5HW { get; set; }
        public Stage6HW Stage6HW { get; set; }
        public Stage7HW Stage7HW { get; set; }
        public Stage8HW Stage8HW { get; set; }

        public override List<StageInfo> GetStages()
        {
            return new List<StageInfo>()
            {
                Stage1HW,
                Stage2HW,
                Stage3HW,
                Stage4HW,
                Stage5HW,
                Stage6HW,
                Stage7HW,
                Stage8HW
            };
        }
    }
}
