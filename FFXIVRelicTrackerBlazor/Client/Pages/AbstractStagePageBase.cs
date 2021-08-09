using FFXIVRelicTrackerBlazor.Client.Extensions;
using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
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

        public string returnDec(bool inputBool)
        {
            if (!inputBool)
                return "text-decoration:line-through";
            return "";
        }
        public bool showAll;
        public abstract bool AnyCompleted { get; set; }
        public List<JobName> JobNames;
        public abstract ArrStages StageName { get; }
        protected int RemainingJobs=> TargetExpansion.Jobs.Where(x=>x.JobName!=JobName.NA).Select(x => x.Stages.Where(y => y.StageIndex == StageIndex).First()).Where(x=>x.Progress!=Progress.Completed).Count();
        protected int CompletedJobs=> TargetExpansion.Jobs.Select(x => x.Stages.Where(y => y.StageIndex == StageIndex).First()).Where(x=>x.Progress==Progress.Completed).Count();
        public string Collapse(bool inputBool) { if (inputBool) return "collapse"; return string.Empty; }
        public string GetEnumDisplayName(Enum enumType)
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
        internal Task CheckActiveJob()
        {
            if (ActiveJob != JobName.NA)
            {
                if (TargetExpansion.Jobs.Where(x => x.JobName == ActiveJob).First().Stages.Where(x => x.StageIndex == StageIndex).First().Progress == Progress.Completed)
                    ActiveJob = JobName.NA;
            }
            return Task.CompletedTask;
        }
        public JobName ActiveJob
        {
            get => TargetStage.ActiveJob;
            set
            {
                if (value != TargetStage.ActiveJob && TargetStage.ActiveJob!=JobName.NA)
                    ResetStage();
                TargetStage.ActiveJob = value;
                _ = OnCharacterUpdate();
                StateHasChanged();
            }
        }
        public bool JobSelected
        {
            get => ActiveJob != JobName.NA;
        }
        public bool JobNotSelected
        {
            get => !JobSelected;
        }

        public void CompleteStage()
        {
            if (TargetStage.ActiveJob != JobName.NA)
            {
                MasterStageHelper.CompleteStage(character, TargetStage.ActiveJob, StageIndex, TargetExpansion.Expansion);
                JobNames.Remove(ActiveJob);
                _ = this.OnInitializedAsync();
                ActiveJob = default;
                _ = OnCharacterUpdate();
            }
        }
        public void ResetStage()
        {
            MasterStageHelper.ResetStage(character, StageIndex, TargetExpansion.Expansion);
            _ = OnCharacterUpdate();
        }
    }
}
