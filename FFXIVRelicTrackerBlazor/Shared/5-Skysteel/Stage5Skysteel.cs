using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public class Stage5Skysteel : AbstractSkysteel
    {
        public override int StageIndex => (int)SkySteelStages.Skysung;

        public override int CrafterCount => 105;

        public override int GatherCount1 => 600;

        public override int GatherCount2 => 200;

        public override int FSHCount1 => 70;

        public override int FSHCount2 => 0;
    }
}
