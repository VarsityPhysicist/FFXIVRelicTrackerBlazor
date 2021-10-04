using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers
{
    public static class StagesByExpansion
    {
        public static List<string> GetStageList(ExpansionName expansion)
        {
            switch (expansion)
            {
                case ExpansionName.Arr:
                    return ArrStages;
                case ExpansionName.HW:
                    return HWStages;
                case ExpansionName.ShB:
                    return ShBStages;
                default:
                    return null;
            }
        }
        public static List<string> ArrStages = new List<string>()
        {
           "Relic",
           "Zenith",
           "Atma",
           "Animus",
           "Novus",
           "Nexus",
           "Braves",
           "Zeta"
        };
        public static List<string> HWStages = new List<string>()
        {
            "Animated",
            "Awoken",
            "Anima",
            "Hyperconductive",
            "Reconditioned",
            "Sharpened",
            "Complete",
            "Lux"
        };
        public static List<string> ShBStages = new List<string>()
        {
            "Resistance",
            "Augmented Resistance",
            "Recollection",
            "Law's Order",
            "Augmented Law's Order",
            "Blades of Gunhildr"
        };
    }
    public enum ArrStages
    {
        [Display(Name = "Relic")]
        Relic,
        [Display(Name = "Zenith")]
        Zenith,
        [Display(Name = "Atma")]
        Atma,
        [Display(Name = "Animus")]
        Animus,
        [Display(Name = "Novus")]
        Novus,
        [Display(Name = "Nexus")]
        Nexus,
        [Display(Name = "Zodiac Braves")]
        Braves,
        [Display(Name = "Zodiac Zeta")]
        Zeta
    }
    public enum HWStages
    {
        [Display(Name = "Animated")]
        Animated,
        [Display(Name = "Awoken")]
        Awoken,
        [Display(Name = "Anima")]
        Anima,
        [Display(Name = "Hyperconductive")]
        Hyperconductive,
        [Display(Name = "Reconditioned")]
        Reconditioned,
        [Display(Name = "Sharpened")]
        Sharpened,
        [Display(Name = "Complete")]
        Complete,
        [Display(Name = "Lux")]
        Lux
    }

    public enum ShBStages
    {
        [Display(Name = "Resistance")]
        Resistance,
        [Display(Name = "Augmented Resistance")]
        AugmentedResistance,
        [Display(Name = "Recollection")]
        Recollection,
        [Display(Name = "Law's Order")]
        LawsOrder,
        [Display(Name = "Augmented Law's Order")]
        AugmentedLawsOrder,
        [Display(Name = "Blades of Gunhildr")]
        Blades
    }

    public enum SkySteelStages
    {
        [Display(Name ="Skysteel")]
        Skysteel,
        [Display(Name ="Skysteel+1")]
        Skysteel_1,
        [Display(Name ="Dragonsung")]
        Dragonsung,
        [Display(Name ="Augmented Dragonsung")]
        AugmentedDragonsung,
        [Display(Name ="Skysung")]
        Skysung,
        [Display(Name ="Skybuilders")]
        Skybuilders
    }
}
