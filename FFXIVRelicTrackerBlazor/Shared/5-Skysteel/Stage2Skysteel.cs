using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public class Stage2Skysteel : AbstractSkysteel
    {
        public override int StageIndex => (int)SkySteelStages.Skysteel_1;

        public override int CrafterCount => 20;

        public override int GatherCount1 => 340;

        public override int GatherCount2 => 120;

        public override int FSHCount1 => 40;

        public override int FSHCount2 => 0;
    }
}
