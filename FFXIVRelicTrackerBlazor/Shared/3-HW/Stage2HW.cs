using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage2HW : StageInfo
    {
        public override int StageIndex =>(int)HWStages.Awoken;

        public AwokenStep AwokenStep { get; set; }
    }
    public enum AwokenStep
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
        Step10
    }
}
