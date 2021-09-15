using FFXIVRelicTrackerBlazor.Shared._5_ShB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.StageCompleters
{
    public class ShBStageCompleter
    {
        private static bool adjustCount;
        public static void CompleteStage(JobName Job, int StageIndex, ShBExpansion ShBExpansion, bool AdjustCount)
        {
            adjustCount = AdjustCount;
            shBExpansion = ShBExpansion;
            for (int index = StageIndex; index >= 0; index--)
            {
                var tempStage = ShBExpansion.Jobs.Single(x => x.JobName == Job).Stages.Single(x => x.StageIndex == index);
                tempStage.Progress = Progress.Completed;
                CompleteSomeStage(Job, index);
            }
        }
        public static void InCompleteStage(JobName Job, int StageIndex, ShBExpansion ShBExpansion)
        {
            shBExpansion = ShBExpansion;
            for (int index = StageIndex; index < ShBExpansion.StageCount; index++)
            {
                var tempStage = ShBExpansion.Jobs.Single(x => x.JobName == Job).Stages.Single(x => x.StageIndex == index);
                tempStage.Progress = Progress.NA;
            }
        }

        private static ShBExpansion shBExpansion;
        private static void CompleteSomeStage(JobName Job, int stageIndex)
        {
            switch (stageIndex)
            {
                case (int)ShBStages.Resistance:
                    CompleteStage1(Job);
                    break;
                case (int)ShBStages.AugmentedResistance:
                    CompleteStage2(Job);
                    break;
                case (int)ShBStages.Recollection:
                    CompleteStage3(Job);
                    break;
                case (int)ShBStages.LawsOrder:
                    CompleteStage4(Job);
                    break;
                case (int)ShBStages.AugmentedLawsOrder:
                    CompleteStage5(Job);
                    break;
                case (int)ShBStages.Blades:
                    CompleteStage6(Job);
                    break;
            }
        }

        private static void CompleteStage1(JobName Job)
        {
            if (adjustCount)
            {
                shBExpansion.Stage1ShB.ScalePowder -= 4;
            }
        }

        private static void CompleteStage2(JobName Job)
        {
            if (adjustCount)
            {
                shBExpansion.Stage2ShB.HarrowingMemory -= 20;
                shBExpansion.Stage2ShB.SorrowfulMemory -= 20;
                shBExpansion.Stage2ShB.TorturedMemory -= 20;
            }
        }
        private static void CompleteStage3(JobName Job)
        {
            if (adjustCount)
            {
                shBExpansion.Stage3ShB.BitterMemory -= 6;
            }
        }
        private static void CompleteStage4(JobName Job)
        {
            if (adjustCount)
            {
                shBExpansion.Stage4ShB.LoathsomeMemory -= 15;
            }
        }
        private static void CompleteStage5(JobName Job)
        {
            if (adjustCount)
            {
                shBExpansion.Stage5ShB.TimewornArtifact -= 15;
            }
        }
        private static void CompleteStage6(JobName Job)
        {
            if (adjustCount)
            {
                shBExpansion.Stage6ShB.RawEmotion -= 15;
            }
        }

    }
}