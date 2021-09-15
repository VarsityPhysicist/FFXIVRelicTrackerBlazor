using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class Stage5ShB : StageInfo
    {
        public override int StageIndex => (int)ShBStages.AugmentedLawsOrder;

        private int hauntingMemory { get; set; }

        public int HauntingMemory
        {
            get => hauntingMemory;
            set { hauntingMemory = FilterChange(value,18); }
        }
        private int vexatiousMemory { get; set; }

        public int VexatiousMemory
        {
            get => vexatiousMemory;
            set { vexatiousMemory = FilterChange(value, 18); }
        }
        private int timewornArtifact { get; set; }

        public int TimewornArtifact
        {
            get => timewornArtifact;
            set { timewornArtifact = FilterChange(value, 15 * 17); }
        }
    }
}
