using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
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

        public override bool AnyCompleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ArrStages StageName => ArrStages.Atma;
        public override string PreviousWeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicName(ActiveJob) + " Zenith";

                return "Relic Weapon Zenith";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicName(ActiveJob) + " Atma";

                return "Relic Weapon Atma";
            }
        }
        private Stage3ARR ThisStage => character.ArrExpansion.Stage3ARR;

        #region Model Properties
        public int LionCount 
        { 
            get=> ThisStage.LionCount;
            set
            {
                ThisStage.LionCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int WaterBearerCount
        {
            get => ThisStage.WaterBearerCount;
            set
            {
                ThisStage.WaterBearerCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int RamCount
        {
            get => ThisStage.RamCount;
            set
            {
                ThisStage.RamCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int CrabCount
        {
            get => ThisStage.CrabCount;
            set
            {
                ThisStage.CrabCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int FishCount
        {
            get => ThisStage.FishCount;
            set
            {
                ThisStage.FishCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int BullCount
        {
            get => ThisStage.BullCount;
            set
            {
                ThisStage.BullCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int ScalesCount
        {
            get => ThisStage.ScalesCount;
            set
            {
                ThisStage.ScalesCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int TwinsCount
        {
            get => ThisStage.TwinsCount;
            set
            {
                ThisStage.TwinsCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int ScorpionCount
        {
            get => ThisStage.ScorpionCount;
            set
            {
                ThisStage.ScorpionCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int ArcherCount
        {
            get => ThisStage.ArcherCount;
            set
            {
                ThisStage.ArcherCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int GoatCount
        {
            get => ThisStage.GoatCount;
            set
            {
                ThisStage.GoatCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public int MaidenCount
        {
            get => ThisStage.MaidenCount;
            set
            {
                ThisStage.MaidenCount = value;
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region Remaining Properties
        public int LionRemaining => RemainingJobs - LionCount;
        public int WaterBearerRemaining => RemainingJobs - WaterBearerCount;
        public int RamRemaining => RemainingJobs - RamCount;
        public int CrabRemaining => RemainingJobs - CrabCount;
        public int FishRemaining => RemainingJobs - FishCount;
        public int BullRemaining => RemainingJobs - BullCount;
        public int ScalesRemaining => RemainingJobs - ScalesCount;
        public int TwinsRemaining => RemainingJobs - TwinsCount;
        public int ScorpionRemaining => RemainingJobs - ScorpionCount;
        public int ArcherRemaining => RemainingJobs - ArcherCount;
        public int GoatRemaining => RemainingJobs - GoatCount;
        public int MaidenRemaining => RemainingJobs - MaidenCount;
        #endregion
    }
}
