using FFXIVRelicTrackerBlazor.Shared.Helpers.StageCompleters;
using FFXIVRelicTrackerBlazor.Shared.Helpers.StageResetters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers
{
    public static class MasterStageHelper
    {
        public static void CompleteStage(Character character, JobName Job, int StageIndex, ExpansionName expansionName, bool adjustCounts = true)
        {

            switch (expansionName)
            {
                case ExpansionName.Arr:
                    ArrStageCompleter.CompleteStage(Job, StageIndex, character.ArrExpansion, adjustCounts);
                    break;
                case ExpansionName.HW:
                    HWStageCompleter.CompleteStage(Job, StageIndex, character.HWExpansion, adjustCounts);
                    break;
                case ExpansionName.SB:
                    break;
                case ExpansionName.ShB:
                    ShBStageCompleter.CompleteStage(Job, StageIndex, character.ShBExpansion, adjustCounts);
                    break;
                case ExpansionName.Skysteel:
                    SkysteelStageCompleter.CompleteStage(Job, StageIndex, character.SkysteelExpansion);
                    break;
            }

            StageInfo targetStage = character.GetExpansions().Single(x => x.Expansion == expansionName).GetStages().Single(x => x.StageIndex == StageIndex);
            JobName activeJob = targetStage.ActiveJob;
            if (activeJob == Job) targetStage.ActiveJob = JobName.NA;
        }
        public static void InCompleteStage(Character character, JobName Job, int StageIndex, ExpansionName expansionName)
        {
            switch (expansionName)
            {
                case ExpansionName.Arr:
                    ArrStageCompleter.InCompleteStage(Job, StageIndex, character.ArrExpansion);
                    break;
                case ExpansionName.HW:
                    HWStageCompleter.InCompleteStage(Job, StageIndex, character.HWExpansion);
                    break;
                case ExpansionName.SB:
                    break;
                case ExpansionName.ShB:
                    ShBStageCompleter.InCompleteStage(Job, StageIndex, character.ShBExpansion);
                    break;
                case ExpansionName.Skysteel:
                    SkysteelStageCompleter.InCompleteStage(Job, StageIndex, character.SkysteelExpansion);
                    break;
            }
        }

        public static void ResetStage(Character character, int StageIndex, ExpansionName expansionName)
        {
            switch (expansionName)
            {
                case ExpansionName.Arr:
                    ArrStageResetter.ResetArrStage(StageIndex, character.ArrExpansion);
                    break;
                case ExpansionName.HW:
                    HWStageResetter.ResetStage(StageIndex, character.HWExpansion);
                    break;
                case ExpansionName.SB:
                    break;
                case ExpansionName.ShB:
                    //No Reset needed for ShBStages
                    break;
                case ExpansionName.Skysteel:
                    //No Reset needed for SkysteelStages
                    break;
            }
        }
    }
}
