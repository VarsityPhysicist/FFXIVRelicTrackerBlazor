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
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

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
        public override string PreviousWeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicName(GetActiveJob());

                return "Relic Weapon";
            }
        }


        public override string WeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return PreviousWeaponName + " Zenith";

                return "Relic Weapon Zenith";
            }
        }

        public int RemainingMist => Math.Max(0,(RemainingJobs * 3) - GetMistCount());

        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
