using FFXIVRelicTrackerBlazor.Client.Services;
using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using FFXIVRelicTrackerBlazor.Shared.Helpers.StageCompleters;
using FFXIVRelicTrackerBlazor.Shared.Helpers.StageResetters;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._2_ArrStages
{
    public class Stage1RelicBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;
        public override AbstractExpansion TargetExpansion => character.ArrExpansion;
        public override StageInfo TargetStage => character.ArrExpansion.Stage1ARR;

        public override bool GetAnyCompleted()
        {
            return Stage0 | FilteredJobs.Count != RemainingJobs;
        }

        public override async Task SetAnyCompleted(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            if (value)
                await SetRelicStage(ArrRelicStage.Stage0, value);
            else
                await SetRelicStage(ArrRelicStage.NA, value);

        }
        public Stage1ARR ThisStage { get => character.ArrExpansion.Stage1ARR; }
        private async Task SetRelicStage(ArrRelicStage arrRelicStage, bool newValue)
        {
            if (GetArrRelicStage() < arrRelicStage && newValue)
            {
                await SetArrRelicStage(arrRelicStage);
                StateHasChanged();
            }
            else if (GetArrRelicStage() >= arrRelicStage && !newValue)
            {
                await SetArrRelicStage(arrRelicStage - 1);
                StateHasChanged();
            }
        }

        #region Model Properties
        public ArrRelicStage GetArrRelicStage()
        {
            return ThisStage.ArrRelicStage;
        }

        public async Task SetArrRelicStage(ArrRelicStage value)
        {
            if (GetArrRelicStage() != value)
            {
                ThisStage.ArrRelicStage = value;
                await OnCharacterUpdate();
            }

        }

        public bool GetBrokenWeapon()
        {
            return Stage1;
        }

        public async Task SetBrokenWeapon(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage1, value);
        }

        public bool GetMeldedWeapon()
        {
            return Stage2;
        }

        public async Task SetMeldedWeapon(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage2, value);
        }

        public bool GetSaltsAcquired()
        {
            return Stage3;
        }

        public async Task SetSaltsAcquired(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage3, value);
        }

        public bool GetAmdaporCompleted()
        {
            return Stage4;
        }

        public async Task SetAmdaporCompleted(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage4, value);
        }

        public bool GetHydraComplete()
        {
            return Stage6;
        }

        public async Task SetHydraComplete(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage6, value);
        }

        public bool GetIfritComplete()
        {
            return Stage7;
        }

        public async Task SetIfritComplete(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage7, value);
        }

        public bool GetGarudaComplete()
        {
            return Stage8;
        }

        public async Task SetGarudaComplete(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage8, value);
        }

        public bool GetTitanComplete()
        {
            return Stage9;
        }

        public async Task SetTitanComplete(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage9, value);
        }

        public bool GetCompletedBeast1()
        {
            return ThisStage.CompletedBeast1 | Stage5;
        }

        public async Task SetCompletedBeast1(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            if (GetCompletedBeast1() != value)
            {
                ThisStage.CompletedBeast1 = value;
                _ = OnCharacterUpdate();
            }
            await SetRelicStage(ArrRelicStage.Stage5, ThisStage.CompletedBeast1 && ThisStage.CompletedBeast2 && ThisStage.CompletedBeast3);
        }

        public bool GetCompletedBeast2()
        {
            return ThisStage.CompletedBeast2 | Stage5;
        }

        public async Task SetCompletedBeast2(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            if (GetCompletedBeast2() != value)
            {
                ThisStage.CompletedBeast2 = value;
                _ = OnCharacterUpdate();
            }
            await SetRelicStage(ArrRelicStage.Stage5, ThisStage.CompletedBeast1 && ThisStage.CompletedBeast2 && ThisStage.CompletedBeast3);
        }

        public bool GetCompletedBeast3()
        {
            return ThisStage.CompletedBeast3 | Stage5;
        }

        public async Task SetCompletedBeast3(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            if (GetCompletedBeast3() != value)
            {
                ThisStage.CompletedBeast3 = value;
                _ = OnCharacterUpdate();
            }
            await SetRelicStage(ArrRelicStage.Stage5, ThisStage.CompletedBeast1 && ThisStage.CompletedBeast2 && ThisStage.CompletedBeast3);
        }

        public bool GetCompletedBeasts()
        {
            return Stage5;
        }

        public async Task SetCompletedBeasts(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage5, value);
        }

        public bool GetQuenchingComplete()
        {
            return Stage10;
        }

        public async Task SetQuenchingComplete(ChangeEventArgs e)
        {
            bool value = (bool)e.Value;
            await SetRelicStage(ArrRelicStage.Stage10, value);
        }

        #endregion

        #region Map Properties
        public string MapSource
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrMap(GetActiveJob());

                return "";
            }
        }
        public double BrokenX
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return BrokenLocation.X / 41 * 200;

                return 0.0;
            }
        }
        public double BrokenY
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return BrokenLocation.Y / 41 * 200;

                return 0.0;
            }
        }

        public double BrokenOpacity
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return 0.5;

                return 0.0;
            }
        }

        private PointF BrokenLocation
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrBrokenLocation(GetActiveJob());

                return new PointF();
            }
        }
        #endregion

        #region MiscArr Properties
        public string RelicMat
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicMat(GetActiveJob());

                return "N/A";
            }
        }
        public string RelicMateria
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicMateria(GetActiveJob());

                return "N/A";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrRelicName(GetActiveJob());

                return "N/A";
            }
        }
        #endregion

        #region Beastmen Properties
        public List<string> BeastmenList
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return MiscArr.GetArrBeastmen(GetActiveJob());

                return new List<string>() { "", "", "" };
            }
        }
        public string Beastman1 { get => BeastmenList[0]; }
        public string Beastman2 { get => BeastmenList[1]; }
        public string Beastman3 { get => BeastmenList[2]; }
        #endregion

        public string QuestName
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return "A Relic Reborn (" + WeaponName +")";

                return "";
            }
        }
        public string QuestLink
        {
            get
            {
                if (GetActiveJob() != JobName.NA)
                    return "https://ffxiv.gamerescape.com/wiki/" + QuestName.Replace(" ", "_");

                return "";
            }
        }
        #region Stage Bools

        private bool Stage0 { get => GetArrRelicStage() >= ArrRelicStage.Stage0; }
        private bool Stage1 { get => GetArrRelicStage() >= ArrRelicStage.Stage1; }
        private bool Stage2 { get => GetArrRelicStage() >= ArrRelicStage.Stage2; }
        private bool Stage3 { get => GetArrRelicStage() >= ArrRelicStage.Stage3; }
        private bool Stage4 { get => GetArrRelicStage() >= ArrRelicStage.Stage4; }
        private bool Stage5 { get => GetArrRelicStage() >= ArrRelicStage.Stage5; }
        private bool Stage6 { get => GetArrRelicStage() >= ArrRelicStage.Stage6; }
        private bool Stage7 { get => GetArrRelicStage() >= ArrRelicStage.Stage7; }
        private bool Stage8 { get => GetArrRelicStage() >= ArrRelicStage.Stage8; }
        private bool Stage9 { get => GetArrRelicStage() >= ArrRelicStage.Stage9; }
        private bool Stage10 { get => GetArrRelicStage() >= ArrRelicStage.Stage10; }

        public override string PreviousWeaponName => throw new NotImplementedException();

        #endregion
    }
}
