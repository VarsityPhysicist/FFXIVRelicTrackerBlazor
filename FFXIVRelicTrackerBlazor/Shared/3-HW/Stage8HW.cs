using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage8HW : StageInfo
    {
        public Stage8HW()
        {
            Step1 = new List<bool>() { false, false, false };
            Step2 = new List<bool>() { false, false, false, false };
            Step3 = new List<bool>() { false, false };
            Step4 = new List<bool>() { false, false, false };
        }
        public override int StageIndex => (int)HWStages.Lux;

        public LuxStep LuxStep { get; set; }

        private int inkCount { get; set; }

        public int InkCount
        {
            get => inkCount;
            set
            {
                inkCount = FilterChange(value, 13);
            }
        }

        public List<bool> Step1 { get; set; }
        public List<bool> Step2 { get; set; }
        public List<bool> Step3 { get; set; }
        public List<bool> Step4 { get; set; }

    }
    public enum LuxStep
    {
        NA,
        Step0,
        Step1,
        Step2,
        Step3,
        Step4,
        Step5,
        Step6,
        Step7,
        Step8,
        Step9,
        Step10,
        Step11,
        Step12
    }
}
