using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage5HW : StageInfo
    {
        public override int StageIndex => (int)HWStages.Reconditioned;

        private int umbrite { get; set; }
        private int crystalSand { get; set; }
        private int treatedSand { get; set; }

        public int Umbrite
        {
            get => umbrite;
            set
            {
                umbrite = FilterChange(value,1040);
            }
        }
        public int CrystalSand
        {
            get => crystalSand;
            set
            {
                crystalSand = FilterChange(value, 1040);
            }
        }
        public int TreatedSand
        {
            get => treatedSand;
            set
            {
                treatedSand = FilterChange(value, 180);
            }
        }
    }
}
