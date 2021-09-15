using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class Stage3ShB : StageInfo
    {
        public override int StageIndex => (int)ShBStages.Recollection;
        private int bitterMemory { get; set; }

        public int BitterMemory
        {
            get => bitterMemory;
            set { bitterMemory = FilterChange(value, 6 * 17); }
        }
    }
}
