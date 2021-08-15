using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.Misc
{
    public static class WeaponNames
    {
        public static string GetWeaponName(JobName job, int StageIndex, ExpansionName expansion)
        {
            switch (expansion)
            {
                case ExpansionName.HW:
                    return GetHWWeapon(job, StageIndex);
                default:
                    return null;
            }
        }

        #region HW Weapons
        private static string GetHWWeapon(JobName job, int stageIndex)
        {
            if (stageIndex < (int)HWStages.Reconditioned)
            {
                return InitialHWWeapon(job);
            }
            else if (stageIndex < (int)HWStages.Complete)
            {
                return SecondHWWeapon(job);
            }
            else
            {
                return FinalHWWeapon(job);
            }
        }

        private static string InitialHWWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Almace and Ancile";
                case JobName.WAR:
                    return "Ukonvasara";
                case JobName.DRK:
                    return "Nothung";
                case JobName.WHM:
                    return "Majestas";
                case JobName.SCH:
                    return "Tetrabiblos";
                case JobName.AST:
                    return "Deneb";
                case JobName.MNK:
                    return "Verethragna";
                case JobName.DRG:
                    return "Rhongomiant";
                case JobName.NIN:
                    return "Kannagi";
                case JobName.BRD:
                    return "Gandiva";
                case JobName.MCH:
                    return "Armageddon";
                case JobName.BLM:
                    return "Hvergelmir";
                case JobName.SMN:
                    return "Draconomicon";
                default:
                    return "Anima Weapon";
            }
        }
        private static string SecondHWWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Sword and Shield of the Twin Thegns";
                case JobName.WAR:
                    return "Axe of the Blood Emperor";
                case JobName.DRK:
                    return "Guillotine of the Tyrant";
                case JobName.WHM:
                    return "Cane of the White Tsar";
                case JobName.SCH:
                    return "Word of the Magnate";
                case JobName.AST:
                    return "Sphere of the Last Heir";
                case JobName.MNK:
                    return "Sultan's Fist";
                case JobName.DRG:
                    return "Trident of the Overlord";
                case JobName.NIN:
                    return "Spurs of the Thorn Prince";
                case JobName.BRD:
                    return "Bow of the Autarch";
                case JobName.MCH:
                    return "Flame of the Dynast";
                case JobName.BLM:
                    return "Rod of the Black Khan";
                case JobName.SMN:
                    return "Book of the Mad Queen";
                default:
                    return "Anima Weapon";
            }
        }
        private static string FinalHWWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Aettir and Priwen";
                case JobName.WAR:
                    return "Minos";
                case JobName.DRK:
                    return "Cronus";
                case JobName.WHM:
                    return "Sindri";
                case JobName.SCH:
                    return "Anabasis";
                case JobName.AST:
                    return "Canopus";
                case JobName.MNK:
                    return "Nyepel";
                case JobName.DRG:
                    return "Areadbhar";
                case JobName.NIN:
                    return "Sandung";
                case JobName.BRD:
                    return "Terpander";
                case JobName.MCH:
                    return "Deathlocke";
                case JobName.BLM:
                    return "Kaladanda";
                case JobName.SMN:
                    return "Mimesis";
                default:
                    return "Anima Weapon";
            }
        }
        #endregion

    }
}
