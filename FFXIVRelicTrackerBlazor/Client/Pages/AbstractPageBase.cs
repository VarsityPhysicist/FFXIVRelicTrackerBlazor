using FFXIVRelicTrackerBlazor.Client.Services;
using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public abstract class AbstractPageBase : ComponentBase, IDisposable
    {
        [Inject]
        public IState State { get; set; }
        public Character character
        {
            get
            {
                return State.Character;
            }
            set
            {
                State.Character = value;
            }
        }
        public abstract AbstractExpansion TargetExpansion { get; }
        public bool GetAdjustCount => TargetExpansion.AdjustCounts;
        public bool IsJobComplete(JobName job, int StageIndex) => TargetExpansion.Jobs.Single(x => x.JobName == job).Stages.Single(x => x.StageIndex == StageIndex).Progress == Progress.Completed;

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
        public abstract Task AdditionalInitializeAsync();
        protected override async Task OnInitializedAsync()
        {
            Subscribe();
            await State.InitializeComponent();
            await AdditionalInitializeAsync();
        }

        public void Subscribe()
        {
            State.Notify += StateNotify;
        }
        public void UnSubscribe()
        {
            State.Notify -= StateNotify;
        }
        public void Dispose()
        {
            UnSubscribe();
        }
        public async Task OnNotify()
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
        public void StateNotify()
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
        public async Task OnCharacterUpdate()
        {
            await State.UpdateCharacterAsync();
        }
    }
}
