using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    [Serializable]
    public class ArrExpansion : AbstractExpansion
    {

        public ArrExpansion()
        {

            GenerateJobs();

            Stage1ARR = new Stage1ARR();
            Stage2ARR = new Stage2ARR();
            Stage3ARR = new Stage3ARR();
            Stage4ARR = new Stage4ARR();
            Stage5ARR = new Stage5ARR();
            Stage6ARR = new Stage6ARR();
            Stage7ARR = new Stage7ARR();
            Stage8ARR = new Stage8ARR();
        }


        public Stage1ARR Stage1ARR { get; set; }
        public Stage2ARR Stage2ARR { get; set; }
        public Stage3ARR Stage3ARR { get; set; }
        public Stage4ARR Stage4ARR { get; set; }
        public Stage5ARR Stage5ARR { get; set; }
        public Stage6ARR Stage6ARR { get; set; }
        public Stage7ARR Stage7ARR { get; set; }
        public Stage8ARR Stage8ARR { get; set; }

        public override ExpansionName Expansion => ExpansionName.Arr;

        public override int StageCount => 8;
    }
}
