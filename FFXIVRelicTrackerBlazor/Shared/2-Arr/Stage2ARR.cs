using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage2ARR : StageInfo
    {
        public override int StageIndex => (int)ArrStages.Zenith;
        private int mistCount { get; set; }
        public int MistCount
        {
            get => mistCount;
            set
            {
                if (value >= 0 && value <= 30)
                    mistCount = value;
            }
        }
    }
}
