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
                    break;
            }
        }
    }
}
