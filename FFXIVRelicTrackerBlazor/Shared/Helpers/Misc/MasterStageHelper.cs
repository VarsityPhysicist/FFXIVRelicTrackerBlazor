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
        public static void CompleteStage(Character character, JobName Job, int StageIndex, ExpansionName expansionName)
        {
            switch (expansionName)
            {
                case ExpansionName.Arr:
                    ArrStageCompleter.CompleteStage(Job, StageIndex, character.ArrExpansion);
                    break;
                case ExpansionName.HW:
                    break;
                case ExpansionName.SB:
                    break;
                case ExpansionName.ShB:
                    break;
            }
        }
        public static void InCompleteStage(Character character, JobName Job, int StageIndex, ExpansionName expansionName)
        {
            switch (expansionName)
            {
                case ExpansionName.Arr:
                    ArrStageCompleter.InCompleteStage(Job, StageIndex, character.ArrExpansion);
                    break;
                case ExpansionName.HW:
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
                    break;
                case ExpansionName.SB:
                    break;
                case ExpansionName.ShB:
                    break;
            }
        }
    }
}
