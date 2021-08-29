using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage3HW : StageInfo
    {
        public override int StageIndex => (int)HWStages.Anima;

        private int bone { get; set; }
        private int shell { get; set; }
        private int ore { get; set; }
        private int seeds { get; set; }

        public int Bone
        {
            get => bone;
            set
            {
                bone = FilterChange(value, 130);
            }
        }
        public int Shell
        {
            get => shell;
            set
            {
                shell = FilterChange(value, 130);
            }
        }
        public int Ore
        {
            get => ore;
            set
            {
                ore = FilterChange(value, 130);
            }
        }
        public int Seeds
        {
            get => seeds;
            set
            {
                seeds = FilterChange(value, 130);
            }
        }

        private int francesca { get; set; }
        private int mirror { get; set; }
        private int arrow { get; set; }
        private int kingcake { get; set; }

        public int Francesca
        {
            get => francesca;
            set
            {
                francesca = FilterChange(value, 52);
            }
        }
        public int Mirror
        {
            get => mirror;
            set
            {
                mirror = FilterChange(value, 52);
            }
        }
        public int Arrow
        {
            get => arrow;
            set
            {
                arrow = FilterChange(value, 52);
            }
        }
        public int Kingcake
        {
            get => kingcake;
            set
            {
                kingcake = FilterChange(value, 52);
            }
        }
    }
}
