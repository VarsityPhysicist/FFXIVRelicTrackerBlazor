using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage6HW : StageInfo
    {
        public override int StageIndex => (int)HWStages.Sharpened;

        private int singingCluster { get; set; }

        public int SingingCluster
        {
            get => singingCluster;
            set
            {
                singingCluster = FilterChange(value,650);
            }
        }
    }
}
