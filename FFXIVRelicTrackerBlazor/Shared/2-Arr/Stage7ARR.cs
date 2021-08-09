using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage7ARR : StageInfo
    {
        public override int StageIndex => (int)ArrStages.Braves;

        public bool BookComplete { get; set; }
        public bool ZodiumComplete { get; set; }
        public bool AlexandriteComplete { get; set; }
        public bool ScrollComplete { get; set; }
    }
}
