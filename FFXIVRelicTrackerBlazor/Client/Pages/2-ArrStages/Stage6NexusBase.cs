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
    public class Stage6NexusBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage6ARR;

        public override bool AnyCompleted { get => ValidJobs.Count != CompletedJobs; set => throw new NotImplementedException(); }

        public override ArrStages StageName => ArrStages.Nexus;
        public override string PreviousWeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                {
                    if(ActiveJob==JobName.PLD) return MiscArr.GetArrRelicName(ActiveJob) + " Novus & Holy Shield Novus";
                    else
                        return MiscArr.GetArrRelicName(ActiveJob) + " Novus";
                }

                return "Relic Weapon Novus";
            }
        }
        public override string WeaponName
        {
            get
            {
                if (ActiveJob != JobName.NA)
                {
                    if (ActiveJob == JobName.PLD) 
                        return MiscArr.GetArrRelicName(ActiveJob) + " Nexus & Holy Shield Nexus";
                    else
                        return MiscArr.GetArrRelicName(ActiveJob) + " Nexus";
                }

                return "Relic Weapon Nexus";
            }
        }

        public Stage6ARR ThisStage { get => character.ArrExpansion.Stage6ARR; }

        public int CurrentLight
        {
            get => ThisStage.CurrentLight;
            set
            {
                ThisStage.CurrentLight = value;
                _ = OnCharacterUpdate();
            }
        }

        public string LightString(int inputLight)
        {
            switch (inputLight)
            {
                case <= 199:
                    return "No";
                case <= 399:
                    return "Indistinct";
                case <= 599:
                    return "Faint";
                case <= 799:
                    return "Slight";
                case <= 1199:
                    return "Modest";
                case <= 1399:
                    return "Distinct";
                case <= 1599:
                    return "Robust";
                case <= 1799:
                    return "Vigorous";
                case <= 1999:
                    return "Extreme";
                case >= 2000:
                    return "Bursting";

            }
        }
        
        public void IncrementLight(int addLight)
        {
            CurrentLight += addLight;
        }

        
    }
}
