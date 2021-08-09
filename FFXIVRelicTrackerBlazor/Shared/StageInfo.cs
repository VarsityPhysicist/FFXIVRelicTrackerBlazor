using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared
{
    public abstract class StageInfo
    {
        public JobName ActiveJob { get; set; }
        public abstract int StageIndex { get; }
    }
}
