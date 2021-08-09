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
    public class Stage8ZetaBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage8ARR;

        public override bool AnyCompleted { get => FilteredJobs.Count != RemainingJobs; set => throw new NotImplementedException(); }

        public override ArrStages StageName => ArrStages.Zeta;
        public override string PreviousWeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                {
                    if (ActiveJob == JobName.PLD)
                        return MiscArr.GetArrZodiacName(ActiveJob) + " & Aegis Shield";
                    else
                        return MiscArr.GetArrZodiacName(ActiveJob) + "";
                }

                return "Zodiac Braves Weapon";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                {
                    if (ActiveJob == JobName.PLD)
                        return MiscArr.GetArrZodiacName(ActiveJob) + "Zeta  & Aegis Shield Zeta";
                    else
                        return MiscArr.GetArrZodiacName(ActiveJob) + "";
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
        public void SetStageProgress(ArrZodiacStage arrZodiacStage)
        {
            ThisStage.ArrZodiacStage = arrZodiacStage;
        }

        public bool RamComplete { get => CheckStageProgress(ArrZodiacStage.Stage0); set { SetStageProgress(ArrZodiacStage.Stage0); _ = OnCharacterUpdate(); } }
        public bool BullComplete { get => CheckStageProgress(ArrZodiacStage.Stage1); set { SetStageProgress(ArrZodiacStage.Stage1); _ = OnCharacterUpdate(); } }
        public bool TwinsComplete { get => CheckStageProgress(ArrZodiacStage.Stage2); set { SetStageProgress(ArrZodiacStage.Stage2); _ = OnCharacterUpdate(); } }
        public bool CrabComplete { get => CheckStageProgress(ArrZodiacStage.Stage3); set { SetStageProgress(ArrZodiacStage.Stage3); _ = OnCharacterUpdate(); } }
        public bool LionComplete { get => CheckStageProgress(ArrZodiacStage.Stage4); set { SetStageProgress(ArrZodiacStage.Stage4); _ = OnCharacterUpdate(); } }
        public bool MaidenComplete { get => CheckStageProgress(ArrZodiacStage.Stage5); set { SetStageProgress(ArrZodiacStage.Stage5); _ = OnCharacterUpdate(); } }
        public bool ScalesComplete { get => CheckStageProgress(ArrZodiacStage.Stage6); set { SetStageProgress(ArrZodiacStage.Stage6); _ = OnCharacterUpdate(); } }
        public bool ScorpionComplete { get => CheckStageProgress(ArrZodiacStage.Stage7); set { SetStageProgress(ArrZodiacStage.Stage7); _ = OnCharacterUpdate(); } }
        public bool ArcherComplete { get => CheckStageProgress(ArrZodiacStage.Stage8); set { SetStageProgress(ArrZodiacStage.Stage8); _ = OnCharacterUpdate(); } }
        public bool GoatComplete { get => CheckStageProgress(ArrZodiacStage.Stage9); set { SetStageProgress(ArrZodiacStage.Stage9); _ = OnCharacterUpdate(); } }
        public bool WaterBearerComplete { get => CheckStageProgress(ArrZodiacStage.Stage10); set { SetStageProgress(ArrZodiacStage.Stage10); _ = OnCharacterUpdate(); } }
        public bool FishComplete { get => CheckStageProgress(ArrZodiacStage.Stage11); set { SetStageProgress(ArrZodiacStage.Stage11); _ = OnCharacterUpdate(); } }
        #endregion
    }
}
