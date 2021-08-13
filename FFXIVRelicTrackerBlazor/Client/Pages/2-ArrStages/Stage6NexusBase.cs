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
    public class Stage6NexusBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage6ARR;

        public override bool GetAnyCompleted()
        {
            return ValidJobs.Count != CompletedJobs;
        }

        public override ArrStages StageName => ArrStages.Nexus;
        public override string PreviousWeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                {
                    if(GetActiveJob() == JobName.PLD) return MiscArr.GetArrRelicName(GetActiveJob()) + " Novus & Holy Shield Novus";
                    else
                        return MiscArr.GetArrRelicName(GetActiveJob()) + " Novus";
                }

                return "Relic Weapon Novus";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                {
                    if (GetActiveJob() == JobName.PLD) 
                        return MiscArr.GetArrRelicName(GetActiveJob()) + " Nexus & Holy Shield Nexus";
                    else
                        return MiscArr.GetArrRelicName(GetActiveJob()) + " Nexus";
                }

                return "Relic Weapon Nexus";
            }
        }

        public Stage6ARR ThisStage { get => character.ArrExpansion.Stage6ARR; }

        public int GetCurrentLight()
        {
            return ThisStage.CurrentLight;
        }

        public async Task SetCurrentLight(int value)
        {
            ThisStage.CurrentLight = value;
            await OnCharacterUpdate();
        }
        public async Task SetCurrentLight(ChangeEventArgs e)
        {
            if(int.TryParse(e.Value.ToString(),out int value))
            {
                ThisStage.CurrentLight = value;
                await OnCharacterUpdate();
            }
            
        }

        public static string LightString(int inputLight)
        {
            switch (inputLight)
            {
                case <= 199:
                    return "No";
                case <= 399:
                    return "Indistinct";
                case <= 599:
                    return "Faint";
                case <= 799:
                    return "Slight";
                case <= 1199:
                    return "Modest";
                case <= 1399:
                    return "Distinct";
                case <= 1599:
                    return "Robust";
                case <= 1799:
                    return "Vigorous";
                case <= 1999:
                    return "Extreme";
                case >= 2000:
                    return "Bursting";

            }
        }
        
        public async Task IncrementLight(int addLight)
        {
            await SetCurrentLight(GetCurrentLight() + addLight);
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
