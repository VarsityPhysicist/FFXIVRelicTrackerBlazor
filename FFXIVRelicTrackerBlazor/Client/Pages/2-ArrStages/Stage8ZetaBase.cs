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
    public class Stage8ZetaBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage8ARR;

        public override bool GetAnyCompleted()
        {
            return FilteredJobs.Count != RemainingJobs;
        }

        public override string PreviousWeaponName
        {
            get
            {
                if (GetActiveJob != JobName.NA)
                {
                    if (GetActiveJob == JobName.PLD)
                        return MiscArr.GetArrZodiacName(GetActiveJob) + " & Aegis Shield";
                    else
                        return MiscArr.GetArrZodiacName(GetActiveJob) + "";
                }

                return "Zodiac Braves Weapon";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (GetActiveJob != JobName.NA)
                {
                    if (GetActiveJob == JobName.PLD)
                        return MiscArr.GetArrZodiacName(GetActiveJob) + "Zeta  & Aegis Shield Zeta";
                    else
                        return MiscArr.GetArrZodiacName(GetActiveJob) + "";
                }

                return "Zodiac Weapon Zeta";
            }
        }

        public Stage8ARR ThisStage { get => character.ArrExpansion.Stage8ARR; }

        #region Model Properties
        private bool CheckStageProgress(ArrZodiacStage arrZodiacStage)
        {
            return ThisStage.ArrZodiacStage < arrZodiacStage;
        }
        public async Task SetStageProgress(ArrZodiacStage arrZodiacStage)
        {
            if (ThisStage.ArrZodiacStage>= arrZodiacStage)
            {
                ThisStage.ArrZodiacStage = (ArrZodiacStage)((int)arrZodiacStage - 1);
            }
            else ThisStage.ArrZodiacStage = arrZodiacStage;
            await OnCharacterUpdate();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool GetRamComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage0);
        }

        public async Task SetRamComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage0);
        }
        public bool GetBullComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage1);
        }

        public async Task SetBullComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage1);
        }
        public bool GetTwinsComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage2);
        }

        public async Task SetTwinsComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage2);
        }
        public bool GetCrabComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage3);
        }

        public async Task SetCrabComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage3);
        }
        public bool GetLionComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage4);
        }

        public async Task SetLionComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage4);
        }
        public bool GetMaidenComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage5);
        }

        public async Task SetMaidenComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage5);
        }
        public bool GetScalesComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage6);
        }

        public async Task SetScalesComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage6);
        }
        public bool GetScorpionComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage7);
        }

        public async Task SetScorpionComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage7);
        }
        public bool GetArcherComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage8);
        }

        public async Task SetArcherComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage8);
        }
        public bool GetGoatComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage9);
        }

        public async Task SetGoatComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage9);
        }
        public bool GetWaterBearerComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage10);
        }

        public async Task SetWaterBearerComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage10);
        }
        public bool GetFishComplete()
        {
            return CheckStageProgress(ArrZodiacStage.Stage11);
        }

        public async Task SetFishComplete()
        {
            await SetStageProgress(ArrZodiacStage.Stage11);
        }
        #endregion
    }
}
