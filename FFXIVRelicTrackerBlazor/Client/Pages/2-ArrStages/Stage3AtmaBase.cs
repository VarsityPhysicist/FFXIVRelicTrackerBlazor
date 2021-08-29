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
        public int LionRemaining => Math.Max(0, RemainingJobs - GetLionCount());
        public int WaterBearerRemaining => Math.Max(0, RemainingJobs - GetWaterBearerCount());
        public int RamRemaining => Math.Max(0, RemainingJobs - GetRamCount());
        public int CrabRemaining => Math.Max(0, RemainingJobs - GetCrabCount());
        public int FishRemaining => Math.Max(0, RemainingJobs - GetFishCount());
        public int BullRemaining => Math.Max(0, RemainingJobs - GetBullCount());
        public int ScalesRemaining => Math.Max(0, RemainingJobs - GetScalesCount());
        public int TwinsRemaining => Math.Max(0, RemainingJobs - GetTwinsCount());
        public int ScorpionRemaining => Math.Max(0, RemainingJobs - GetScorpionCount());
        public int ArcherRemaining => Math.Max(0, RemainingJobs - GetArcherCount());
        public int GoatRemaining => Math.Max(0, RemainingJobs - GetGoatCount());
        public int MaidenRemaining => Math.Max(0, RemainingJobs - GetMaidenCount());
        #endregion
    }
}
