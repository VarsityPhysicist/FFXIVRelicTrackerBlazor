using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage7HW : StageInfo
    {
        public Stage7HW()
        {
            Dungeons = new List<bool>() { false, false, false };
        }
        public override int StageIndex => (int)HWStages.Complete;

        private int pneumite { get; set; }
        private int density { get; set; }

        public int Pneumite
        {
            get => pneumite;
            set
            {
                pneumite = FilterChange(value, 195);
            }
        }
        public int Density
        {
            get => density;
            set
            {
                density = FilterChange(value, 2000);
            }
        }
        public List<bool> Dungeons { get; set; }
    }
}
