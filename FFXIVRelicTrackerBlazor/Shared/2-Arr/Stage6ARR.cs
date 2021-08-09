using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage6ARR : StageInfo
    {
        public override int StageIndex => (int)ArrStages.Nexus;
        public int CurrentLight { get; set; }
    }
}
