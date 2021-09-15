using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class Stage4ShB : StageInfo
    {
        public override int StageIndex => (int)ShBStages.LawsOrder;

        private int loathsomeMemory { get; set; }

        public int LoathsomeMemory
        {
            get => loathsomeMemory;
            set { loathsomeMemory = FilterChange(value, 15 * 17); }
        }
    }
}
