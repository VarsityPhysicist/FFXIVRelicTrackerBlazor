using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public class Stage6Skysteel : AbstractSkysteel
    {
        public override int StageIndex => (int)SkySteelStages.Skybuilders;

        public override int CrafterCount => 60;

        public override int GatherCount1 => 250;

        public override int GatherCount2 => 25;

        public override int FSHCount1 => 200;

        public override int FSHCount2 => 200;
    }
}
