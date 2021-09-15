using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class Stage1ShB : StageInfo
    {
        public override int StageIndex => (int)ShBStages.Resistance;
        private int scalePowder { get; set; }
        
        public int ScalePowder
        {
            get => scalePowder;
            set
            {
                scalePowder = FilterChange(value, 4 * 17);
            }
        }
    }
}
