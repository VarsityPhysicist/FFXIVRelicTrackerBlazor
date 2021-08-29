using FFXIVRelicTrackerBlazor.Shared._3_HW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.StageResetters
{
    public static class HWStageResetter
    {
        public static void ResetStage(int stageIndex, HWExpansion HWExpansion)
        {
            hwExpansion = HWExpansion;
            switch (stageIndex)
            {
                case (int)HWStages.Animated:
                    ResetStage1();
                    break;
                case (int)HWStages.Awoken:
                    ResetStage2();
                    break;
                case (int)HWStages.Anima:
                    ResetStage3();
                    break;
                case (int)HWStages.Hyperconductive:
                    ResetStage4();
                    break;
                case (int)HWStages.Reconditioned:
                    ResetStage5();
                    break;
                case (int)HWStages.Sharpened:
                    ResetStage6();
                    break;
                case (int)HWStages.Complete:
                    ResetStage7();
                    break;
                case (int)HWStages.Lux:
                    ResetStage8();
                    break;
            }
        }
        private static HWExpansion hwExpansion;

        private static void ResetStage1()
        {
        }

        private static void ResetStage2()
        {
            hwExpansion.Stage2HW.AwokenStep = 0;
        }
        private static void ResetStage3()
        {
        }
        private static void ResetStage4()
        {
        }
        private static void ResetStage5()
        {
            hwExpansion.Stage5HW.TreatedSand = 0;
        }
        private static void ResetStage6()
        {
        }
        private static void ResetStage7()
        {
            hwExpansion.Stage7HW.Density = 0;
            hwExpansion.Stage7HW.Dungeons = new List<bool>() { false, false, false };
        }
        private static void ResetStage8()
        {
            hwExpansion.Stage8HW.LuxStep = 0;
        }
    }
}
