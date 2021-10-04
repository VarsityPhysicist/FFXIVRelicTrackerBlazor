using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Extensions;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public abstract class AbstractStagePageBase : AbstractPageBase
    {
        public List<JobName> ValidJobs => JobsByExpansion.GetJobList(TargetExpansion.Expansion);
        public List<JobName> FilteredJobs => ValidJobs.Where(x => x != JobName.NA).ToList();
        public abstract AbstractExpansion TargetExpansion { get; }
        public abstract StageInfo TargetStage { get; }
        public string WeaponName => WeaponNames.GetWeaponName(TargetStage.ActiveJob, StageIndex, TargetExpansion.Expansion);
        public string PreviousWeaponName => WeaponNames.GetWeaponName(TargetStage.ActiveJob, StageIndex - 1, TargetExpansion.Expansion);
        public int StageIndex => TargetStage.StageIndex;

        public static string returnDec(bool inputBool)
        {
            if (!inputBool)
                return "text-decoration:line-through";
            return "";
        }
        public bool showAll;

        public virtual bool GetAnyCompleted()
        {
            return CompletedJobs > 0;
        }
        public virtual Task SetAnyCompleted(ChangeEventArgs e)
        {
            return null;
        }
        protected static int FilterLow(int input) => Math.Max(input, 0);

        public List<JobName> JobNames;
        protected int RemainingJobs => TargetExpansion.Jobs.Where(x => x.JobName != JobName.NA).Select(x => x.Stages.Single(y => y.StageIndex == StageIndex)).Where(x => x.Progress != Progress.Completed).Count();
        protected int CompletedJobs => TargetExpansion.Jobs.Select(x => x.Stages.Single(y => y.StageIndex == StageIndex)).Where(x => x.Progress == Progress.Completed).Count();
        public static string Collapse(bool inputBool) { if (inputBool) return "collapse"; return string.Empty; }
        protected static string FormatNumber(int input) => string.Format("{0:n0}", input);
        public static string GetEnumDisplayName(Enum enumType)
        {
            return EnumExtensions.GetEnumDisplayName(enumType);
        }
        public override async Task AdditionalInitializeAsync()
        {
            await CheckCharacter();
            await CheckJobs();
            await CheckActiveJob();

            await CheckDefaultJob();
        }
        internal async Task CheckDefaultJob()
        {
            if (character.DefaultJob != JobName.NA && TargetStage.ActiveJob == JobName.NA && FilteredJobs.Contains(character.DefaultJob))
            {
                if (TargetExpansion.Jobs.Single(x => x.JobName == character.DefaultJob).Stages.Single(x => x.StageIndex == StageIndex).Progress != Progress.Completed)
                {
                    await SetActiveJob(character.DefaultJob);
                }
            }
        }
        internal Task CheckCharacter()
        {
            if (character != null)
                showAll = true;
            else
                showAll = false;
            return Task.CompletedTask;
        }
        internal Task CheckJobs()
        {
            JobNames = new List<JobName>();
            foreach (var job in ValidJobs)
            {
                if (TargetExpansion.Jobs.Single(x => x.JobName == job).Stages.Single(x => x.StageIndex == StageIndex).Progress != Progress.Completed)
                {
                    JobNames.Add(job);
                }
            }
            return Task.CompletedTask;
        }
        internal async Task CheckActiveJob()
        {
            if (JobSelected)
            {
                if (TargetExpansion.Jobs.Single(x => x.JobName == GetActiveJob).Stages.Single(x => x.StageIndex == StageIndex).Progress == Progress.Completed)
                    await SetActiveJob(JobName.NA);
            }
        }

        public JobName GetActiveJob => TargetStage.ActiveJob;

        public async Task SetActiveJob(ChangeEventArgs e)
        {
            JobName jobName = (JobName)Enum.Parse(typeof(JobName), e.Value.ToString());
            if (jobName != TargetStage.ActiveJob && TargetStage.ActiveJob != JobName.NA)
                await ResetStage();
            TargetStage.ActiveJob = jobName;
            await OnCharacterUpdate();
            StateHasChanged();
        }
        public async Task SetActiveJob(JobName jobName)
        {
            if (jobName != TargetStage.ActiveJob && TargetStage.ActiveJob != JobName.NA)
                await ResetStage();
            TargetStage.ActiveJob = jobName;
            await OnCharacterUpdate();
            StateHasChanged();
        }
        public bool JobSelected => GetActiveJob != JobName.NA;
        public bool JobNotSelected => !JobSelected;

        public async Task CompleteStage()
        {
            if (GetActiveJob != JobName.NA)
            {

                if (StageIndex < TargetExpansion.StageCount - 1 && character.AutoAssignCompletion)
                {
                    var nextStage = TargetExpansion.GetStages().Single(x => x.StageIndex == StageIndex + 1);
                    var job = TargetExpansion.Jobs.Single(x => x.JobName == GetActiveJob);
                    if (nextStage.ActiveJob == JobName.NA && job.Stages.Single(x => x.StageIndex == StageIndex + 1).Progress != Progress.Completed)
                    {
                        nextStage.ActiveJob = GetActiveJob;
                    }
                }

                MasterStageHelper.CompleteStage(character, TargetStage.ActiveJob, StageIndex, TargetExpansion.Expansion, TargetExpansion.AdjustCounts);
                JobNames.Remove(GetActiveJob);

                await this.OnInitializedAsync();
                await SetActiveJob(JobName.NA);
                await OnCharacterUpdate();
            }
        }
        public async Task ResetStage()
        {
            MasterStageHelper.ResetStage(character, StageIndex, TargetExpansion.Expansion);
            TargetStage.ActiveJob = JobName.NA;
            await OnCharacterUpdate();
        }
    }
}
