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
    public class Stage3AtmaBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage3ARR;

        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override ArrStages StageName => ArrStages.Atma;
        public override string PreviousWeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicName(GetActiveJob()) + " Zenith";

                return "Relic Weapon Zenith";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicName(GetActiveJob()) + " Atma";

                return "Relic Weapon Atma";
            }
        }
        private Stage3ARR ThisStage => character.ArrExpansion.Stage3ARR;

        #region Model Properties
        public int GetLionCount()
        {
            return ThisStage.LionCount;
        }

        public async Task SetLionCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.LionCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetWaterBearerCount()
        {
            return ThisStage.WaterBearerCount;
        }

        public async Task SetWaterBearerCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.WaterBearerCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetRamCount()
        {
            return ThisStage.RamCount;
        }

        public async Task SetRamCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.RamCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetCrabCount()
        {
            return ThisStage.CrabCount;
        }

        public async Task SetCrabCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.CrabCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetFishCount()
        {
            return ThisStage.FishCount;
        }

        public async Task SetFishCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.FishCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetBullCount()
        {
            return ThisStage.BullCount;
        }

        public async Task SetBullCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.BullCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetScalesCount()
        {
            return ThisStage.ScalesCount;
        }

        public async Task SetScalesCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.ScalesCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetTwinsCount()
        {
            return ThisStage.TwinsCount;
        }

        public async Task SetTwinsCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.TwinsCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetScorpionCount()
        {
            return ThisStage.ScorpionCount;
        }

        public async Task SetScorpionCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.ScorpionCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetArcherCount()
        {
            return ThisStage.ArcherCount;
        }

        public async Task SetArcherCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.ArcherCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetGoatCount()
        {
            return ThisStage.GoatCount;
        }

        public async Task SetGoatCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.GoatCount = value;
                await OnCharacterUpdate();
            }
        }

        public int GetMaidenCount()
        {
            return ThisStage.MaidenCount;
        }

        public async Task SetMaidenCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.MaidenCount = value;
                await OnCharacterUpdate();
            }
        }
        #endregion
        #region Remaining Properties
        public int LionRemaining => RemainingJobs - GetLionCount();
        public int WaterBearerRemaining => RemainingJobs - GetWaterBearerCount();
        public int RamRemaining => RemainingJobs - GetRamCount();
        public int CrabRemaining => RemainingJobs - GetCrabCount();
        public int FishRemaining => RemainingJobs - GetFishCount();
        public int BullRemaining => RemainingJobs - GetBullCount();
        public int ScalesRemaining => RemainingJobs - GetScalesCount();
        public int TwinsRemaining => RemainingJobs - GetTwinsCount();
        public int ScorpionRemaining => RemainingJobs - GetScorpionCount();
        public int ArcherRemaining => RemainingJobs - GetArcherCount();
        public int GoatRemaining => RemainingJobs - GetGoatCount();
        public int MaidenRemaining => RemainingJobs - GetMaidenCount();
        #endregion
    }
}
