using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.StageResetters
{
    public static class ArrStageResetter
    {
        public static void ResetArrStage(int stageIndex, ArrExpansion ArrExpansion)
        {
            arrExpansion = ArrExpansion;
            switch (stageIndex)
            {
                case (int)ArrStages.Relic:
                    ResetStage1();
                    break;
                case (int)ArrStages.Zenith:
                    ResetStage2();
                    break;
                case (int)ArrStages.Atma:
                    ResetStage3();
                    break;
                case (int)ArrStages.Animus:
                    ResetStage4();
                    break;
                case (int)ArrStages.Novus:
                    ResetStage5();
                    break;
                case (int)ArrStages.Nexus:
                    ResetStage6();
                    break;
                case (int)ArrStages.Braves:
                    ResetStage7();
                    break;
                case (int)ArrStages.Zeta:
                    ResetStage8();
                    break;
            }
        }
        private static ArrExpansion arrExpansion;

        private static void ResetStage1()
        {
            arrExpansion.Stage1ARR.ActiveJob = JobName.NA;
            arrExpansion.Stage1ARR = new Stage1ARR();
        }

        private static void ResetStage2()
        {
        }
        private static void ResetStage3()
        {
        }
        private static void ResetStage4()
        {
            arrExpansion.Stage4ARR = new Stage4ARR();
        }
        private static void ResetStage5()
        {
            int tempInt = arrExpansion.Stage5ARR.AlexandriteCount;
            arrExpansion.Stage5ARR = new Stage5ARR();
            arrExpansion.Stage5ARR.AlexandriteCount = tempInt;
        }
        private static void ResetStage6()
        {
            arrExpansion.Stage6ARR = new Stage6ARR();
        }
        private static void ResetStage7()
        {
            arrExpansion.Stage7ARR = new Stage7ARR();
        }
        private static void ResetStage8()
        {
            arrExpansion.Stage8ARR = new Stage8ARR();
        }
    }
}
