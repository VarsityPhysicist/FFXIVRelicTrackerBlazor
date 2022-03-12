using FFXIVRelicTrackerBlazor.Shared._5_Skysteel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.StageCompleters
{
    public static class SkysteelStageCompleter
    {
        public static void CompleteStage(JobName Job, int StageIndex, SkysteelExpansion SkysteelExpansion)
        {
            skysteelExpansion = SkysteelExpansion;
            for (int index = StageIndex; index >= 0; index--)
            {
                var tempStage = SkysteelExpansion.Jobs.Single(x => x.JobName == Job).Stages.Single(x => x.StageIndex == index);
                tempStage.Progress = Progress.Completed;
            }
        }
        public static void InCompleteStage(JobName Job, int StageIndex, SkysteelExpansion SkysteelExpansion)
        {
            skysteelExpansion = SkysteelExpansion;
            for (int index = StageIndex; index < SkysteelExpansion.StageCount; index++)
            {
                var tempStage = skysteelExpansion.Jobs.Single(x => x.JobName == Job).Stages.Single(x => x.StageIndex == index);
                tempStage.Progress = Progress.NA;
            }
        }

        private static SkysteelExpansion skysteelExpansion;
    }
}
