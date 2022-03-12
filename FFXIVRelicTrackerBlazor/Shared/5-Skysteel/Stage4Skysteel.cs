using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public class Stage4Skysteel : AbstractSkysteel
    {
        public override int StageIndex => (int)SkySteelStages.AugmentedDragonsung;

        public override int CrafterCount => 90;

        public override int GatherCount1 => 500;

        public override int GatherCount2 => 180;

        public override int FSHCount1 => 60;

        public override int FSHCount2 => 0;
        
    }
}
