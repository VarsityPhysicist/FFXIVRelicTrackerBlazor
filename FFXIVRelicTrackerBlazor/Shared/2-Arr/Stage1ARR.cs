using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFXIVRelicTrackerBlazor.Shared.Helpers;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage1ARR: StageInfo
    {
        public ArrRelicStage ArrRelicStage { get; set; }

        public bool CompletedBeast1 { get; set; }
        public bool CompletedBeast2 { get; set; }
        public bool CompletedBeast3 { get; set; }
        public override int StageIndex => (int)ArrStages.Relic;
    }
    public enum ArrRelicStage
    {
        NA,
        Stage0,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Stage6,
        Stage7,
        Stage8,
        Stage9,
        Stage10,
        Stage11
    }
}
