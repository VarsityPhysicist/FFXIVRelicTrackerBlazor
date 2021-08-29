using FFXIVRelicTrackerBlazor.Shared._3_HW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.StageCompleters
{
    public static class HWStageCompleter
    {
        private static bool adjustCount;
        public static void CompleteStage(JobName Job, int StageIndex, HWExpansion HWExpansion, bool AdjustCount)
        {
            adjustCount = AdjustCount;
            hwExpansion = HWExpansion;
            for (int index = StageIndex; index >= 0; index--)
            {
                var tempStage = HWExpansion.Jobs.Single(x => x.JobName == Job).Stages.Single(x => x.StageIndex == index);
                tempStage.Progress = Progress.Completed;
                CompleteSomeStage(Job, index);
            }
        }
        public static void InCompleteStage(JobName Job, int StageIndex, HWExpansion HWExpansion)
        {
            hwExpansion = HWExpansion;
            for (int index = StageIndex; index < HWExpansion.StageCount; index++)
            {
                var tempStage = HWExpansion.Jobs.Single(x => x.JobName == Job).Stages.Single(x => x.StageIndex == index);
                tempStage.Progress = Progress.NA;
            }
        }

        private static HWExpansion hwExpansion;
        private static void CompleteSomeStage(JobName Job, int stageIndex)
        {
            switch (stageIndex)
            {
                case (int)HWStages.Animated:
                    CompleteStage1(Job);
                    break;
                case (int)HWStages.Awoken:
                    CompleteStage2(Job);
                    break;
                case (int)HWStages.Anima:
                    CompleteStage3(Job);
                    break;
                case (int)HWStages.Hyperconductive:
                    CompleteStage4(Job);
                    break;
                case (int)HWStages.Reconditioned:
                    CompleteStage5(Job);
                    break;
                case (int)HWStages.Sharpened:
                    CompleteStage6(Job);
                    break;
                case (int)HWStages.Complete:
                    CompleteStage7(Job);
                    break;
                case (int)HWStages.Lux:
                    CompleteStage8(Job);
                    break;
            }
        }

        private static void CompleteStage1(JobName Job)
        {
            if (adjustCount)
            {
                hwExpansion.Stage1HW.WindCrystal -= 1;
                hwExpansion.Stage1HW.FireCrystal -= 1;
                hwExpansion.Stage1HW.LightningCrystal -= 1;
                hwExpansion.Stage1HW.IceCrystal -= 1;
                hwExpansion.Stage1HW.EarthCrystal -= 1;
                hwExpansion.Stage1HW.WaterCrystal -= 1;
            }
        }

        private static void CompleteStage2(JobName Job)
        {
            if (hwExpansion.Stage2HW.ActiveJob == Job)
            {
                hwExpansion.Stage2HW = new Stage2HW();
            }
        }
        private static void CompleteStage3(JobName Job)
        {
            if (adjustCount)
            {
                hwExpansion.Stage3HW.Bone -= 10;
                hwExpansion.Stage3HW.Shell -= 10;
                hwExpansion.Stage3HW.Ore -= 10;
                hwExpansion.Stage3HW.Seeds -= 10;

                hwExpansion.Stage3HW.Francesca -= 4;
                hwExpansion.Stage3HW.Mirror -= 4;
                hwExpansion.Stage3HW.Arrow -= 4;
                hwExpansion.Stage3HW.Kingcake -= 4;
            }
        }
        private static void CompleteStage4(JobName Job)
        {
            if (adjustCount)
            {
                hwExpansion.Stage4HW.OilCount -= 5;
            }
        }
        private static void CompleteStage5(JobName Job)
        {
            if (adjustCount)
            {
                hwExpansion.Stage5HW.Umbrite -= 80;
                hwExpansion.Stage5HW.CrystalSand -= 80;
            }
            
            if (hwExpansion.Stage5HW.ActiveJob == Job)
            {
                hwExpansion.Stage5HW.TreatedSand = 0;
            }

        }
        private static void CompleteStage6(JobName Job)
        {
            if (adjustCount)
            {
                hwExpansion.Stage6HW.SingingCluster -= 50;
            }
        }
        private static void CompleteStage7(JobName Job)
        {
            if (adjustCount)
            {
                hwExpansion.Stage7HW.Pneumite -= 15;
            }
            if (hwExpansion.Stage7HW.ActiveJob == Job)
            {
                hwExpansion.Stage7HW.Density = 0;
            }
        }
        private static void CompleteStage8(JobName Job)
        {
            int inkCount = hwExpansion.Stage8HW.InkCount;
            if (hwExpansion.Stage8HW.ActiveJob == Job)
            {
                hwExpansion.Stage8HW = new Stage8HW();
            }
            if (adjustCount)
            {
                hwExpansion.Stage8HW.InkCount = inkCount - 1;
            }
        }
    }
}
