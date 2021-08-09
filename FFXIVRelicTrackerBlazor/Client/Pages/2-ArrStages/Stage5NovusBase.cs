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
    public class Stage5NovusBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage5ARR;

        public override bool AnyCompleted { get => FilteredJobs.Count == RemainingJobs; set => throw new NotImplementedException(); }

        public override ArrStages StageName => ArrStages.Novus;

        public Stage5ARR ThisStage { get => character.ArrExpansion.Stage5ARR; }

        public bool AcquiredScroll
        {
            get => ThisStage.AcquiredScroll;
            set
            {
                ThisStage.AcquiredScroll = value;
                _ = OnCharacterUpdate();
            }
        }
        public int AlexandriteCount
        {
            get => ThisStage.AlexandriteCount;
            set
            {
                ThisStage.AlexandriteCount = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool DisplaySecondary => ActiveJob == JobName.PLD;
        public int RemainingAlexandrite => RemainingJobs * 75 - AlexandriteCount;
        public override string PreviousWeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicName(ActiveJob) + " Animus";

                return "Relic Weapon Animus";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicName(ActiveJob) + " Novus";

                return "Relic Weapon Novus";
            }
        }


        #region Materia Counts
        #region Primary Materia
        public int PrimaryBattleDanceCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.Battledance];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Battledance] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int PrimaryHeavensEyeCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.HeavensEye];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.HeavensEye] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int PrimaryPietyCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.Piety];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Piety] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int PrimaryQuickarmCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.Quickarm];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Quickarm] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int PrimaryQuicktongueCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.Quicktongue];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Quicktongue] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int PrimarySavageAimCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.SavageAim];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.SavageAim] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int PrimarySavageMightCount
        {
            get => ThisStage.PrimaryCounts[(int)ValidMateria.SavageMight];
            set
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.SavageMight] = value;
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region Secondary Materia
        public int SecondaryBattleDanceCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.Battledance];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Battledance] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int SecondaryHeavensEyeCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.HeavensEye];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.HeavensEye] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int SecondaryPietyCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.Piety];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Piety] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int SecondaryQuickarmCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.Quickarm];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Quickarm] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int SecondaryQuicktongueCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.Quicktongue];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Quicktongue] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int SecondarySavageAimCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.SavageAim];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.SavageAim] = value;
                _ = OnCharacterUpdate();
            }
        }
        public int SecondarySavageMightCount
        {
            get => ThisStage.SecondaryCounts[(int)ValidMateria.SavageMight];
            set
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.SavageMight] = value;
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #endregion

    }
}
