using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class ShBExpansion : AbstractExpansion
    {
        public override ExpansionName Expansion => ExpansionName.ShB;
        public ShBExpansion()
        {
            GenerateJobs();

            Stage1ShB = new Stage1ShB();
            Stage2ShB = new Stage2ShB();
            Stage3ShB = new Stage3ShB();
            Stage4ShB = new Stage4ShB();
            Stage5ShB = new Stage5ShB();
            Stage6ShB = new Stage6ShB();
        }
        public override int StageCount => 6;

        public Stage1ShB Stage1ShB { get; set; }
        public Stage2ShB Stage2ShB { get; set; }
        public Stage3ShB Stage3ShB { get; set; }
        public Stage4ShB Stage4ShB { get; set; }
        public Stage5ShB Stage5ShB { get; set; }
        public Stage6ShB Stage6ShB { get; set; }

        public override List<StageInfo> GetStages()
        {
            return new List<StageInfo>()
            {
                Stage1ShB,
                Stage2ShB,
                Stage3ShB,
                Stage4ShB,
                Stage5ShB,
                Stage6ShB
            };
        }
    }
}
