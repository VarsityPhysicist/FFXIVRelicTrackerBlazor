using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage4HW : StageInfo
    {
        public override int StageIndex => (int)HWStages.Hyperconductive;

        private int oilCount { get; set; }

        public int OilCount
        {
            get => oilCount;
            set
            {
                oilCount = FilterChange(value,65);
            }
        }
    }
}
