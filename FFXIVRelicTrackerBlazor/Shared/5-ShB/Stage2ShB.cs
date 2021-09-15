using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class Stage2ShB : StageInfo
    {
        public override int StageIndex => (int)ShBStages.AugmentedResistance;

        private int harrowingMemory { get; set; }
        private int sorrowfulMemory { get; set; }
        private int torturedMemory { get; set; }

        public int HarrowingMemory
        {
            get => harrowingMemory;
            set { harrowingMemory = FilterChange(value, 20 * 17); }
        }
        public int SorrowfulMemory
        {
            get => sorrowfulMemory;
            set { sorrowfulMemory = FilterChange(value, 20 * 17); }
        }
        public int TorturedMemory
        {
            get => torturedMemory;
            set { torturedMemory = FilterChange(value, 20 * 17); }
        }
    }
}
