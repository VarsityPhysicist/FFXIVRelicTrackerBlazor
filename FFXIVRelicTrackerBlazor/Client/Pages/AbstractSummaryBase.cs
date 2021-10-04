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
        public List<JobName> ValidJobs => JobsByExpansion.GetJobList(TargetExpansion.Expansion);
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

        public bool GetAdjustCount => TargetExpansion.AdjustCounts;
        public string AdjustCountString => TargetExpansion.AdjustCounts ? "will" : "will not";
        public async Task ToggleAdjustCount()
        {
            TargetExpansion.AdjustCounts = !TargetExpansion.AdjustCounts;
            await OnCharacterUpdate();
        }
        public async Task ToggleComplete(int StageIndex, JobName job)
        {
            if (TargetExpansion.Jobs.Where(x => x.JobName == job).First().Stages.Where(x => x.StageIndex == StageIndex).First().Progress == Progress.Completed)
                await InCompleteStage(StageIndex, job);
            else await CompleteStage(StageIndex, job);

        }
        private async Task CompleteStage(int StageIndex, JobName job)
        {
            MasterStageHelper.CompleteStage(character, job, StageIndex, TargetExpansion.Expansion, GetAdjustCount);
            await OnCharacterUpdate();
        }
        private async Task InCompleteStage(int StageIndex, JobName job)
        {
            MasterStageHelper.InCompleteStage(character, job, StageIndex, TargetExpansion.Expansion);
            await OnCharacterUpdate();
        }

    }
}
