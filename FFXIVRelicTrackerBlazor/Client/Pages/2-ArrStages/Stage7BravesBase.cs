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
    public class Stage7BravesBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage7ARR;

        public override bool AnyCompleted { get => ValidJobs.Count != CompletedJobs; set => throw new NotImplementedException(); }

        public override ArrStages StageName => ArrStages.Braves;
        public override string PreviousWeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                {
                    if (ActiveJob == JobName.PLD) return MiscArr.GetArrRelicName(ActiveJob) + " Nexus & Holy Shield Nexus";
                    else
                        return MiscArr.GetArrRelicName(ActiveJob) + " Nexus";
                }

                return "Relic Weapon Nexus";
            }
        }
        public override string WeaponName
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

        public Stage7ARR ThisStage { get => character.ArrExpansion.Stage7ARR; }

        #region Model Properties
        public bool BookComplete
        {
            get => ThisStage.BookComplete;
            set
            {
                ThisStage.BookComplete = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool ZodiumComplete
        {
            get => ThisStage.ZodiumComplete;
            set
            {
                ThisStage.ZodiumComplete = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool AlexandriteComplete
        {
            get => ThisStage.AlexandriteComplete;
            set
            {
                ThisStage.AlexandriteComplete = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool ScrollComplete
        {
            get => ThisStage.ScrollComplete;
            set
            {
                ThisStage.ScrollComplete = value;
                _ = OnCharacterUpdate();
            }
        }
        #endregion

    }
}
