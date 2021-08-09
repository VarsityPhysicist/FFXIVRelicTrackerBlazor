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
    public class Stage2ZenithBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage2ARR;


        public Stage2ARR ThisStage { get => character.ArrExpansion.Stage2ARR; }

        public int MistCount
        {
            get => ThisStage.MistCount;
            set
            {
                if (MistCount != value && value>=0 && value<=30)
                {
                    ThisStage.MistCount = value;
                    _ = OnCharacterUpdate();
                }

            }
        }
        public override string PreviousWeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return MiscArr.GetArrRelicName(ActiveJob);

                return "N/A";
            }
        }


        public override string WeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                    return PreviousWeaponName + " Zenith";

                return "N/A";
            }
        }

        public int RemainingMist => (RemainingJobs * 3)-MistCount;

        public override ArrStages StageName => ArrStages.Zenith;

        public override bool AnyCompleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
