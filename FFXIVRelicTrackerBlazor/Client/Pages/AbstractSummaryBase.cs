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

        public string AdjustCountString => TargetExpansion.AdjustCounts ? "will" : "will not";
        public async Task ToggleAdjustCount()
        {
            TargetExpansion.AdjustCounts = !TargetExpansion.AdjustCounts;
            await OnCharacterUpdate();
        }
        

    }
}
