using FFXIVRelicTrackerBlazor.Client.Extensions;
using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public abstract class AbstractStagePageBase : AbstractPageBase
    {
        public abstract List<JobName> ValidJobs { get; }
        public List<JobName> FilteredJobs => ValidJobs.Where(x => x != JobName.NA).ToList();
        public abstract AbstractExpansion TargetExpansion { get; }
        public abstract StageInfo TargetStage { get; }
        public abstract string WeaponName { get; }
        public abstract string PreviousWeaponName { get; }
        public int StageIndex => TargetStage.StageIndex;

        public static string returnDec(bool inputBool)
        {
            if (!inputBool)
                return "text-decoration:line-through";
            return "";
        }
        public bool showAll;

        public abstract bool GetAnyCompleted();
        public abstract Task SetAnyCompleted(ChangeEventArgs e);

        public List<JobName> JobNames;
        public abstract ArrStages StageName { get; }
        protected int RemainingJobs=> TargetExpansion.Jobs.Where(x=>x.JobName!=JobName.NA).Select(x => x.Stages.Where(y => y.StageIndex == StageIndex).First()).Where(x=>x.Progress!=Progress.Completed).Count();
        protected int CompletedJobs=> TargetExpansion.Jobs.Select(x => x.Stages.Where(y => y.StageIndex == StageIndex).First()).Where(x=>x.Progress==Progress.Completed).Count();
        public static string Collapse(bool inputBool) { if (inputBool) return "collapse"; return string.Empty; }
        public static string GetEnumDisplayName(Enum enumType)
        {
            return EnumExtensions.GetEnumDisplayName(enumType);
        }
        public override async Task AdditionalInitializeAsync()
        {
            await CheckCharacter();
            await CheckJobs();
            await CheckActiveJob();
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
                if (TargetExpansion.Jobs.Where(x => x.JobName == job).First().Stages.Where(x => x.StageIndex ==StageIndex).First().Progress != Progress.Completed)
                {
                    JobNames.Add(job);
                }
            }
            return Task.CompletedTask;
        }
        internal async Task CheckActiveJob()
        {
            if (GetActiveJob() != JobName.NA)
            {
                if (TargetExpansion.Jobs.Where(x => x.JobName == GetActiveJob()).First().Stages.Where(x => x.StageIndex == StageIndex).First().Progress == Progress.Completed)
                    await SetActiveJob(JobName.NA);
            }
        }

        public JobName GetActiveJob()
        {
            return TargetStage.ActiveJob;
        }

        public async Task SetActiveJob(ChangeEventArgs e)
        {
            JobName jobName = (JobName)Enum.Parse(typeof(JobName), e.Value.ToString());
            if (jobName != TargetStage.ActiveJob && TargetStage.ActiveJob != JobName.NA)
                ResetStage();
            TargetStage.ActiveJob = jobName;
            await OnCharacterUpdate();
            StateHasChanged();
        }
        public async Task SetActiveJob(JobName jobName)
        {
            if (jobName != TargetStage.ActiveJob && TargetStage.ActiveJob != JobName.NA)
                ResetStage();
            TargetStage.ActiveJob = jobName;
            await OnCharacterUpdate();
            StateHasChanged();
        }
        public bool JobSelected
        {
            get => GetActiveJob() != JobName.NA;
        }
        public bool JobNotSelected
        {
            get => !JobSelected;
        }

        public async Task CompleteStage()
        {
            if (TargetStage.ActiveJob != JobName.NA)
            {
                MasterStageHelper.CompleteStage(character, TargetStage.ActiveJob, StageIndex, TargetExpansion.Expansion);
                JobNames.Remove(GetActiveJob());
                await this.OnInitializedAsync();
                await SetActiveJob(JobName.NA);
                await OnCharacterUpdate();
            }
        }
        public void ResetStage()
        {
            MasterStageHelper.ResetStage(character, StageIndex, TargetExpansion.Expansion);
            _ = OnCharacterUpdate();
        }
    }
}
