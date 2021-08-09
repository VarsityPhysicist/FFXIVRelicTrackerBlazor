using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared.Helpers.StageResetters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.StageCompleters
{
    public static class ArrStageCompleter
    {
        public static void CompleteStage(JobName Job, int StageIndex, ArrExpansion ArrExpansion)
        {
            arrExpansion = ArrExpansion;
            for (int index = StageIndex; index >= 0; index --)
            {
                var tempStage = ArrExpansion.Jobs.Where(x => x.JobName == Job).First().Stages.Where(x => x.StageIndex == index).First();
                tempStage.Progress = Progress.Completed;
                CompleteSomeStage(index);
            }
        }
        public static void InCompleteStage(JobName Job, int StageIndex, ArrExpansion ArrExpansion)
        {
            arrExpansion = ArrExpansion;
            for (int index = StageIndex; index <ArrExpansion.StageCount; index ++)
            {
                var tempStage = ArrExpansion.Jobs.Where(x => x.JobName == Job).First().Stages.Where(x => x.StageIndex == index).First();
                tempStage.Progress = Progress.NA;
            }
        }

        private static ArrExpansion arrExpansion;
        private static void CompleteSomeStage(int stageIndex)
        {
            switch (stageIndex)
            {
                case (int)ArrStages.Relic:
                    CompleteStage1();
                    break;
                case (int)ArrStages.Zenith:
                    CompleteStage2();
                    break;
                case (int)ArrStages.Atma:
                    CompleteStage3();
                    break;
                case (int)ArrStages.Animus:
                    CompleteStage4();
                    break;
                case (int)ArrStages.Novus:
                    CompleteStage5();
                    break;
                case (int)ArrStages.Nexus:
                    CompleteStage6();
                    break;
                case (int)ArrStages.Braves:
                    CompleteStage7();
                    break;
                case (int)ArrStages.Zeta:
                    CompleteStage8();
                    break;
            }
        }

        private static void CompleteStage1()
        {
            arrExpansion.Stage1ARR.ActiveJob=JobName.NA;
            arrExpansion.Stage1ARR = new Stage1ARR();
        }

        private static void CompleteStage2()
        {
            arrExpansion.Stage2ARR.MistCount -= 3;
        }
        private static void CompleteStage3()
        {
            arrExpansion.Stage3ARR.LionCount -= 1;
            arrExpansion.Stage3ARR.WaterBearerCount -= 1;
            arrExpansion.Stage3ARR.RamCount -= 1;
            arrExpansion.Stage3ARR.CrabCount -= 1;
            arrExpansion.Stage3ARR.FishCount -= 1;
            arrExpansion.Stage3ARR.BullCount -= 1;
            arrExpansion.Stage3ARR.ScalesCount -= 1;
            arrExpansion.Stage3ARR.TwinsCount -= 1;
            arrExpansion.Stage3ARR.ScorpionCount -= 1;
            arrExpansion.Stage3ARR.ArcherCount -= 1;
            arrExpansion.Stage3ARR.GoatCount -= 1;
            arrExpansion.Stage3ARR.MaidenCount -= 1;
            
        }
        private static void CompleteStage4()
        {
            arrExpansion.Stage4ARR = new Stage4ARR();
        }
        private static void CompleteStage5()
        {
            int tempInt = arrExpansion.Stage5ARR.AlexandriteCount;
            arrExpansion.Stage5ARR = new Stage5ARR();
            arrExpansion.Stage5ARR.AlexandriteCount = tempInt;
        }
        private static void CompleteStage6()
        {
            arrExpansion.Stage6ARR = new Stage6ARR();
        }
        private static void CompleteStage7()
        {
            arrExpansion.Stage7ARR = new Stage7ARR();
        }
        private static void CompleteStage8()
        {
            arrExpansion.Stage8ARR = new Stage8ARR();
        }
    }
}
