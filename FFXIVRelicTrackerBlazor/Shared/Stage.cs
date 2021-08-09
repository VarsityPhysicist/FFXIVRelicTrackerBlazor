using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared
{
    public class Stage
    {
        public Progress Progress { get; set; }
        public string StageName { get; set; }
        public int StageIndex { get; set; }
    }
}
