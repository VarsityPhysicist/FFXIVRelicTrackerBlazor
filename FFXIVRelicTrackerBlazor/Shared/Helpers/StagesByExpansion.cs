using System;
using System.Collections.Generic;
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
    }
    public enum ArrStages
    {
        Relic,
        Zenith,
        Atma,
        Animus,
        Novus,
        Nexus,
        Braves,
        Zeta
    }
    public enum HWStages
    {
        Animated,
        Awoken,
        Anima,
        Hyperconductive,
        Reconditioned,
        Sharpened,
        Complete,
        Lux
    }
}
