using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage5ARR : StageInfo
    {
        public Stage5ARR()
        {
            PrimaryCounts = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
            SecondaryCounts = new List<int>() { 0, 0, 0, 0, 0, 0, 0 };
        }
        public override int StageIndex => (int)ArrStages.Novus;
        public int AlexandriteCount { get; set; }
        public List<int> PrimaryCounts { get; set; }
        public List<int> SecondaryCounts { get; set; }
        public bool AcquiredScroll { get; set; }
    }
    public enum ValidMateria
    {
        [Display(Name = "Battledance Materia")]
        Battledance,
        [Display(Name = "Heaven's Eye Materia")]
        HeavensEye,
        [Display(Name = "Piety Materia")]
        Piety,
        [Display(Name = "Quickarm Materia")]
        Quickarm,
        [Display(Name = "Quicktongue Materia")]
        Quicktongue,
        [Display(Name = "Savage Aim Materia")]
        SavageAim,
        [Display(Name = "Savage Might Materia")]
        SavageMight
    }
}
