﻿using FFXIVRelicTrackerBlazor.Shared;
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
    public class Stage7BravesBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage7ARR;

        public Stage7ARR ThisStage { get => character.ArrExpansion.Stage7ARR; }

        #region Model Properties
        public bool GetBookComplete()
        {
            return ThisStage.BookComplete;
        }

        public async Task SetBookComplete(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.BookComplete = value;
                await OnCharacterUpdate();
            }
            
        }

        public bool GetZodiumComplete()
        {
            return ThisStage.ZodiumComplete;
        }

        public async Task SetZodiumComplete(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.ZodiumComplete = value;
                await OnCharacterUpdate();
            }
        }

        public bool GetAlexandriteComplete()
        {
            return ThisStage.AlexandriteComplete;
        }

        public async Task SetAlexandriteComplete(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.AlexandriteComplete = value;
                await OnCharacterUpdate();
            }
        }

        public bool GetScrollComplete()
        {
            return ThisStage.ScrollComplete;
        }

        public async Task SetScrollComplete(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.ScrollComplete = value;
                await OnCharacterUpdate();
            }
        }
        #endregion

    }
}
