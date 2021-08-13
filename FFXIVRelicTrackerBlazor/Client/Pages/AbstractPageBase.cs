using FFXIVRelicTrackerBlazor.Client.Services;
using FFXIVRelicTrackerBlazor.Shared;
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
