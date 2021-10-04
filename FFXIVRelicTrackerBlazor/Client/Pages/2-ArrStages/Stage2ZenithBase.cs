using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._2_ArrStages
{
    public class Stage2ZenithBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage2ARR;


        public Stage2ARR ThisStage { get => character.ArrExpansion.Stage2ARR; }

        public int GetMistCount()
        {
            return ThisStage.MistCount;
        }

        public async Task SetMistCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
                if (GetMistCount() != value && value >= 0 && value <= 30)
                {
                    ThisStage.MistCount = value;
                    await OnCharacterUpdate();
                }

        }
        public int RemainingMist => Math.Max(0,(RemainingJobs * 3) - GetMistCount());
    }
}
