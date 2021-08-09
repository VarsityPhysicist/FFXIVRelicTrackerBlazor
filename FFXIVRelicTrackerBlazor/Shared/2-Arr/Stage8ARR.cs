using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage8ARR : StageInfo
    {
        public override int StageIndex => (int)ArrStages.Zeta;
        public ArrZodiacStage ArrZodiacStage { get; set; }
    }
    public enum ArrZodiacStage
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
