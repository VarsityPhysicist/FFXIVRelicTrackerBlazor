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
    public class Stage5NovusBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage5ARR;

        public override bool GetAnyCompleted()
        {
            return FilteredJobs.Count == RemainingJobs;
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override ArrStages StageName => ArrStages.Novus;

        public Stage5ARR ThisStage { get => character.ArrExpansion.Stage5ARR; }

        public bool GetAcquiredScroll()
        {
            return ThisStage.AcquiredScroll;
        }

        public async Task SetAcquiredScroll(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.AcquiredScroll = value;
                await OnCharacterUpdate();
            }
        }

        public int GetAlexandriteCount()
        {
            return ThisStage.AlexandriteCount;
        }

        public async Task SetAlexandriteCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.AlexandriteCount = value;
                await OnCharacterUpdate();
            }
        }
        public bool DisplaySecondary => GetActiveJob() == JobName.PLD;
        public int RemainingAlexandrite => RemainingJobs * 75 - GetAlexandriteCount();
        public override string PreviousWeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicName(GetActiveJob()) + " Animus";

                return "Relic Weapon Animus";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicName(GetActiveJob()) + " Novus";

                return "Relic Weapon Novus";
            }
        }


        #region Materia Counts
        #region Primary Materia
        public int GetPrimaryBattleDanceCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.Battledance];
        }

        public async Task SetPrimaryBattleDanceCount(ChangeEventArgs e)
        {
            if(int.TryParse(e.Value.ToString(),out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Battledance] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetPrimaryHeavensEyeCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.HeavensEye];
        }

        public async Task SetPrimaryHeavensEyeCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.HeavensEye] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetPrimaryPietyCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.Piety];
        }

        public async Task SetPrimaryPietyCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Piety] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetPrimaryQuickarmCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.Quickarm];
        }

        public async Task SetPrimaryQuickarmCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Quickarm] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetPrimaryQuicktongueCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.Quicktongue];
        }

        public async Task SetPrimaryQuicktongueCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.Quicktongue] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetPrimarySavageAimCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.SavageAim];
        }

        public async Task SetPrimarySavageAimCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.SavageAim] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetPrimarySavageMightCount()
        {
            return ThisStage.PrimaryCounts[(int)ValidMateria.SavageMight];
        }

        public async Task SetPrimarySavageMightCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.PrimaryCounts[(int)ValidMateria.SavageMight] = value;
                await OnCharacterUpdate();
            }
        }

        #endregion
        #region Secondary Materia
        public int GetSecondaryBattleDanceCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.Battledance];
        }

        public async Task SetSecondaryBattleDanceCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Battledance] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetSecondaryHeavensEyeCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.HeavensEye];
        }

        public async Task SetSecondaryHeavensEyeCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.HeavensEye] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetSecondaryPietyCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.Piety];
        }

        public async Task SetSecondaryPietyCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Piety] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetSecondaryQuickarmCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.Quickarm];
        }

        public async Task SetSecondaryQuickarmCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Quickarm] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetSecondaryQuicktongueCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.Quicktongue];
        }

        public async Task SetSecondaryQuicktongueCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.Quicktongue] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetSecondarySavageAimCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.SavageAim];
        }

        public async Task SetSecondarySavageAimCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.SavageAim] = value;
                await OnCharacterUpdate();
            }
        }

        public int GetSecondarySavageMightCount()
        {
            return ThisStage.SecondaryCounts[(int)ValidMateria.SavageMight];
        }

        public async Task SetSecondarySavageMightCount(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.SecondaryCounts[(int)ValidMateria.SavageMight] = value;
                await OnCharacterUpdate();
            }
        }

        #endregion
        #endregion

    }
}
