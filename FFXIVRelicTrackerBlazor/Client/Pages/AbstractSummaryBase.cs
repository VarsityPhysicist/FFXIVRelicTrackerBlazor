using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public abstract class AbstractSummaryBase : AbstractPageBase
    {
        public abstract List<JobName> ValidJobs { get; }
        public abstract AbstractExpansion TargetExpansion { get; }
        public int StageCount => TargetExpansion.StageCount;
        public List<JobName> JobNames;
        public bool showAll;

        public override async Task AdditionalInitializeAsync()
        {
            await CheckCharacter();
        }
        internal Task CheckCharacter()
        {
            if (character != null)
                showAll = true;
            else
                showAll = false;
            return Task.CompletedTask;
        }

        public void ToggleComplete(int StageIndex, JobName job)
        {
            if (TargetExpansion.Jobs.Where(x => x.JobName == job).First().Stages.Where(x => x.StageIndex == StageIndex).First().Progress == Progress.Completed)
                InCompleteStage(StageIndex, job);
            else CompleteStage(StageIndex, job);

        }
        private void CompleteStage(int StageIndex, JobName job)
        {
            MasterStageHelper.CompleteStage(character, job, StageIndex, TargetExpansion.Expansion);
            _ = OnCharacterUpdate();
        }
        private void InCompleteStage(int StageIndex, JobName job)
        {
            MasterStageHelper.InCompleteStage(character, job, StageIndex, TargetExpansion.Expansion);
            _ = OnCharacterUpdate();
        }

    }
}
