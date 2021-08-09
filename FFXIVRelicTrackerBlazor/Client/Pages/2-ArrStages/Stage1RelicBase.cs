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
        
        public override bool AnyCompleted
        {
            get
            {
                return Stage0 | FilteredJobs.Count != RemainingJobs;
            }
            set
            {
                if(value)
                    SetRelicStage(ArrRelicStage.Stage0, value);
                else
                    SetRelicStage(ArrRelicStage.NA, value);

            }
        }
        public override ArrStages StageName => ArrStages.Relic;

        public Stage1ARR ThisStage { get => character.ArrExpansion.Stage1ARR; }
        private void SetRelicStage(ArrRelicStage arrRelicStage, bool newValue)
        {
            if (ArrRelicStage < arrRelicStage && newValue)
            {
                ArrRelicStage = arrRelicStage;
                StateHasChanged();
            }
            else if (ArrRelicStage >= arrRelicStage && !newValue)
            {
                ArrRelicStage = arrRelicStage-1;
                StateHasChanged();
            }
        }
        #region Model Properties
        public ArrRelicStage ArrRelicStage
        {
            get => ThisStage.ArrRelicStage;
            set 
            {
                if (ArrRelicStage != value)
                {
                    ThisStage.ArrRelicStage = value; 
                    _ = OnCharacterUpdate();
                }
                
            }
        }
        public bool BrokenWeapon
        {
            get => Stage1;
            set
            {
                SetRelicStage(ArrRelicStage.Stage1,value);
            }
        }
        public bool MeldedWeapon
        {
            get => Stage2;
            set
            {
                SetRelicStage(ArrRelicStage.Stage2, value);
            }
        }
        public bool SaltsAcquired
        {
            get => Stage3;
            set
            {
                SetRelicStage(ArrRelicStage.Stage3, value);
            }
        }
        public bool AmdaporCompleted
        {
            get => Stage4;
            set
            {
                SetRelicStage(ArrRelicStage.Stage4, value);
            }
        }
        public bool HydraComplete
        {
            get => Stage6;
            set
            {
                SetRelicStage(ArrRelicStage.Stage6, value);
            }
        }
        public bool IfritComplete
        {
            get => Stage7;
            set
            {
                SetRelicStage(ArrRelicStage.Stage7, value);
            }
        }
        public bool GarudaComplete
        {
            get => Stage8;
            set
            {
                SetRelicStage(ArrRelicStage.Stage8, value);
            }
        }
        public bool TitanComplete
        {
            get => Stage9;
            set
            {
                SetRelicStage(ArrRelicStage.Stage9, value);
            }
        }

        public bool CompletedBeast1
        {
            get => ThisStage.CompletedBeast1 | Stage5;
            set
            {
                if (CompletedBeast1 != value)
                {
                    ThisStage.CompletedBeast1 = value;
                    _ = OnCharacterUpdate();
                }
                SetRelicStage(ArrRelicStage.Stage5, ThisStage.CompletedBeast1 && ThisStage.CompletedBeast2 && ThisStage.CompletedBeast3);
            }
        }
        public bool CompletedBeast2
        {
            get => ThisStage.CompletedBeast2 | Stage5;
            set
            {
                if (CompletedBeast2 != value)
                {
                    ThisStage.CompletedBeast2 = value;
                    _ = OnCharacterUpdate();
                }
                SetRelicStage(ArrRelicStage.Stage5, ThisStage.CompletedBeast1 && ThisStage.CompletedBeast2 && ThisStage.CompletedBeast3);
            }
        }
        public bool CompletedBeast3
        {
            get => ThisStage.CompletedBeast3 | Stage5;
            set
            {
                if (CompletedBeast3 != value)
                {
                    ThisStage.CompletedBeast3 = value;
                    _ = OnCharacterUpdate();
                }
                SetRelicStage(ArrRelicStage.Stage5, ThisStage.CompletedBeast1 && ThisStage.CompletedBeast2 && ThisStage.CompletedBeast3);
            }
        }
        public bool CompletedBeasts
        {
            get => Stage5;
            set
            {
                SetRelicStage(ArrRelicStage.Stage5, value);
            }
        }
        public bool QuenchingComplete
        {
            get => Stage10;
            set
            {
                SetRelicStage(ArrRelicStage.Stage10, value);
            }
        }
        #endregion

        #region Map Properties
        public string MapSource
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrMap(ActiveJob);

                return "";
            }
        }
        public double BrokenX
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return BrokenLocation.X / 41 * 200;

                return 0.0;
            }
        }
        public double BrokenY
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return BrokenLocation.Y / 41 * 200;

                return 0.0;
            }
        }

        public double BrokenOpacity
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return 0.5;

                return 0.0;
            }
        }

        private PointF BrokenLocation
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrBrokenLocation(ActiveJob);

                return new PointF();
            }
        }
        #endregion

        #region MiscArr Properties
        public string RelicMat
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicMat(ActiveJob);

                return "N/A";
            }
        }
        public string RelicMateria
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicMateria(ActiveJob);

                return "N/A";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicName(ActiveJob);

                return "N/A";
            }
        }
        #endregion

        #region Beastmen Properties
        public List<string> BeastmenList
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrBeastmen(ActiveJob);

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
                if (ActiveJob != JobName.NA)
                    return "A Relic Reborn (" + WeaponName +")";

                return "";
            }
        }
        public string QuestLink
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return "https://ffxiv.gamerescape.com/wiki/" + QuestName.Replace(" ", "_");

                return "";
            }
        }
        #region Stage Bools

        private bool Stage0 { get => ArrRelicStage >= ArrRelicStage.Stage0; }
        private bool Stage1 { get => ArrRelicStage >= ArrRelicStage.Stage1; }
        private bool Stage2 { get => ArrRelicStage >= ArrRelicStage.Stage2; }
        private bool Stage3 { get => ArrRelicStage >= ArrRelicStage.Stage3; }
        private bool Stage4 { get => ArrRelicStage >= ArrRelicStage.Stage4; }
        private bool Stage5 { get => ArrRelicStage >= ArrRelicStage.Stage5; }
        private bool Stage6 { get => ArrRelicStage >= ArrRelicStage.Stage6; }
        private bool Stage7 { get => ArrRelicStage >= ArrRelicStage.Stage7; }
        private bool Stage8 { get => ArrRelicStage >= ArrRelicStage.Stage8; }
        private bool Stage9 { get => ArrRelicStage >= ArrRelicStage.Stage9; }
        private bool Stage10 { get => ArrRelicStage >= ArrRelicStage.Stage10; }

        public override string PreviousWeaponName => throw new NotImplementedException();

        #endregion
    }
}
