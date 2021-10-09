using FFXIVRelicTrackerBlazor.Shared.Extensions;
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
                case ExpansionName.Arr:
                    return GetARRWeapon(job, StageIndex);
                case ExpansionName.HW:
                    return GetHWWeapon(job, StageIndex);
                case ExpansionName.ShB:
                    return GetShBWeapon(job, StageIndex);
                case ExpansionName.Skysteel:
                    return GetSkysteelWeapon(job, StageIndex);
                default:
                    return null;
            }
        }
        #region ARR Weapons
        private static string GetARRWeapon(JobName job, int stageIndex)
        {
            ArrStages stage = (ArrStages)stageIndex;
            string modifier=EnumExtensions.GetEnumDisplayName(stage);
            if (job == JobName.NA)
            {
                return modifier + " Weapon";
            }

            modifier = Enum.GetName(typeof(ArrStages), stageIndex);
            string tempWeapon = string.Empty;
            if (stageIndex < (int)ArrStages.Braves)
            {
                tempWeapon = InitialARRWeapon(job);
            }
            else
            {
                tempWeapon = FinalARRWeapon(job);
            }
            switch (stageIndex)
            {
                case (int)ArrStages.Zenith:
                case (int)ArrStages.Atma:
                case (int)ArrStages.Animus:
                case (int)ArrStages.Novus:
                case (int)ArrStages.Nexus:
                case (int)ArrStages.Zeta:
                    tempWeapon = tempWeapon + " " + modifier;
                    break;
            }
            return tempWeapon;
        }
        private static string InitialARRWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Curtana and Holy Shield";
                case JobName.WAR:
                    return "Bravura";
                case JobName.WHM:
                    return "Thyrus";
                case JobName.SCH:
                    return "Omnilex";
                case JobName.MNK:
                    return "Sphairai";
                case JobName.DRG:
                    return "Gae Bolg";
                case JobName.NIN:
                    return "Yoshimitsu";
                case JobName.BRD:
                    return "Artemis Bow";
                case JobName.BLM:
                    return "Stardust Rod";
                case JobName.SMN:
                    return "The Veil of Wiyu";
                default:
                    return "Zodiac Weapon";
            }
        }
        private static string FinalARRWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Excalibur and Aegis Shield";
                case JobName.WAR:
                    return "Ragnarok";
                case JobName.WHM:
                    return "Nirvana";
                case JobName.SCH:
                    return "Last Resort";
                case JobName.MNK:
                    return "Kaiser Knuckles";
                case JobName.DRG:
                    return "Longinus";
                case JobName.NIN:
                    return "Sasuke's Blades";
                case JobName.BRD:
                    return "Yoichi Bow";
                case JobName.BLM:
                    return "Lilith Rod";
                case JobName.SMN:
                    return "Apocalypse";
                default:
                    return "Zodiac Weapon";
            }
        }
        #endregion
        #region HW Weapons
        private static string GetHWWeapon(JobName job, int stageIndex)
        {
            HWStages stage = (HWStages)stageIndex;
            string modifier = EnumExtensions.GetEnumDisplayName(stage);
            if (job == JobName.NA)
            {
                return modifier + " Weapon";
            }

            modifier = Enum.GetName(typeof(HWStages), stageIndex);
            string tempWeapon = string.Empty;
            if (stageIndex < (int)HWStages.Anima)
            {
                tempWeapon= InitialHWWeapon(job);
            }
            else if (stageIndex < (int)HWStages.Reconditioned)
            {
                tempWeapon= SecondHWWeapon(job);
            }
            else if (stageIndex < (int)HWStages.Complete)
            {
                tempWeapon= ThirdHWWeapon(job);
            }
            else
            {
                tempWeapon= FinalHWWeapon(job);
            }
            switch (stageIndex)
            {
                case (int)HWStages.Animated:
                case (int)HWStages.Hyperconductive:
                case (int)HWStages.Sharpened:
                    tempWeapon = modifier + " " + tempWeapon;
                    break;
                case (int)HWStages.Awoken:
                case (int)HWStages.Lux:
                    tempWeapon = tempWeapon + " " + modifier;
                    break;
            }
            return tempWeapon;
        }

        private static string InitialHWWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Hauteclaire and Prytwen";
                case JobName.WAR:
                    return "Parashu";
                case JobName.DRK:
                    return "Deathbringer";
                case JobName.WHM:
                    return "Seraph Cane";
                case JobName.SCH:
                    return "Elements";
                case JobName.AST:
                    return "Atlas";
                case JobName.MNK:
                    return "Rising Suns";
                case JobName.DRG:
                    return "Brionac";
                case JobName.NIN:
                    return "Yukimitsu";
                case JobName.BRD:
                    return "Berimbau";
                case JobName.MCH:
                    return "Ferdinand";
                case JobName.BLM:
                    return "Lunaris Rod";
                case JobName.SMN:
                    return "Almandal";
                default:
                    return "Anima Weapon";
            }
        }
        private static string SecondHWWeapon(JobName job)
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
                    return "Rhongomient";
                case JobName.NIN:
                    return "Kannagi";
                case JobName.BRD:
                    return "Gandiva";
                case JobName.MCH:
                    return "Armageddon";
                case JobName.BLM:
                    return "Gvergelmir";
                case JobName.SMN:
                    return "Draconnomicon";
                default:
                    return "Anima Weapon";
            }
        }
        private static string ThirdHWWeapon(JobName job)
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
        #region ShB Weapons
        private static string GetShBWeapon(JobName job, int stageIndex)
        {
            ShBStages stage = (ShBStages)stageIndex;
            string modifier = EnumExtensions.GetEnumDisplayName(stage);
            if (job == JobName.NA)
            {
                return modifier + " Weapon";
            }

            modifier = Enum.GetName(typeof(ShBStages), stageIndex);
            string tempWeapon = string.Empty;
            if (stageIndex < (int)ShBStages.LawsOrder)
            {
                tempWeapon = InitialShBWeapon(job);
            }
            else if (stageIndex < (int)ShBStages.Blades)
            {
                tempWeapon = SecondShBWeapon(job);
            }
            else
            {
                tempWeapon = FinalShBWeapon(job);
            }
            switch (stageIndex)
            {
                case (int)ShBStages.AugmentedLawsOrder:
                case (int)ShBStages.AugmentedResistance:
                    tempWeapon = "Augmented " + tempWeapon;
                    break;
                case (int)ShBStages.Recollection:
                    tempWeapon = tempWeapon + " " + modifier;
                    break;
            }
            return tempWeapon;
        }
        private static string InitialShBWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Honorbound and Tenacity";
                case JobName.WAR:
                    return "Skullrender";
                case JobName.DRK:
                    return "Woebord";
                case JobName.GNB:
                    return "Crownsblade";
                case JobName.WHM:
                    return "Ingrimm";
                case JobName.SCH:
                    return "Akademos";
                case JobName.AST:
                    return "Solstice";
                case JobName.MNK:
                    return "Samsara";
                case JobName.DRG:
                    return "Dreizack";
                case JobName.NIN:
                    return "Honeshirazu";
                case JobName.SAM:
                    return "Hoshikiri";
                case JobName.BRD:
                    return "Brilliance";
                case JobName.MCH:
                    return "Lawman";
                case JobName.DNC:
                    return "Enchufla";
                case JobName.BLM:
                    return "Soulscourge";
                case JobName.SMN:
                    return "Espiritus";
                case JobName.RDM:
                    return "Talekeeper";
                default:
                    return "Resistance Weapon";
            }
        }
        private static string SecondShBWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Law's Order Bastard Sword and Kite Shield";
                case JobName.WAR:
                    return "Law's Order Labrys";
                case JobName.DRK:
                    return "Law's Order Zweihander";
                case JobName.GNB:
                    return "Law's Order Manatrigger";
                case JobName.WHM:
                    return "Law's Order Cane";
                case JobName.SCH:
                    return "Law's Order Codex";
                case JobName.AST:
                    return "Law's Order Astrometer";
                case JobName.MNK:
                    return "Law's Order Knuckles";
                case JobName.DRG:
                    return "Law's Order Spear";
                case JobName.NIN:
                    return "Law's Order Knives";
                case JobName.SAM:
                    return "Law's Order Samurai Blade";
                case JobName.BRD:
                    return "Law's Order Composite Bow";
                case JobName.MCH:
                    return "Law's Order Revolver";
                case JobName.DNC:
                    return "Law's Order Chakrams";
                case JobName.BLM:
                    return "Law's Order Rod";
                case JobName.SMN:
                    return "Law's Order Index";
                case JobName.RDM:
                    return "Law's Order Rapier";
                default:
                    return "Law's Order Weapon";
            }
        }
        private static string FinalShBWeapon(JobName job)
        {
            switch (job)
            {
                case JobName.PLD:
                    return "Blade's Honor and Fortitude";
                case JobName.WAR:
                    return "Blade's Valor";
                case JobName.DRK:
                    return "Blade's Justice";
                case JobName.GNB:
                    return "Blade's Resolve";
                case JobName.WHM:
                    return "Blade's Mercy";
                case JobName.SCH:
                    return "Blade's Wisdom";
                case JobName.AST:
                    return "Blade's Providence";
                case JobName.MNK:
                    return "Blade's Serenity";
                case JobName.DRG:
                    return "Blade's Glory";
                case JobName.NIN:
                    return "Blade's Subtlety";
                case JobName.SAM:
                    return "Blade's Fealty";
                case JobName.BRD:
                    return "Blade's Muse";
                case JobName.MCH:
                    return "Blade's Ingenuity";
                case JobName.DNC:
                    return "Blade's Euphoria";
                case JobName.BLM:
                    return "Blade's Fury";
                case JobName.SMN:
                    return "Blade's Acumen";
                case JobName.RDM:
                    return "Blade's Temperance";
                default:
                    return "Blade's of Gunhildr Weapon";
            }
        }
        #endregion

        #region Skysteel Weapons
        private static string GetSkysteelWeapon(JobName job, int stageIndex)
        {
            SkySteelStages stage = (SkySteelStages)stageIndex;
            string modifier = EnumExtensions.GetEnumDisplayName(stage);
            if (job == JobName.NA)
            {
                return modifier + " Tool";
            }
            else
            {
                string tempWeapon = SkysteelToolNames(job);
                if (stageIndex == (int)SkySteelStages.Skysteel_1)
                {
                    modifier = "Skysteel";
                    return modifier + " " + tempWeapon + " +1";
                }
                else return modifier + " " + tempWeapon;

            }
        }

        private static string SkysteelToolNames(JobName job)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Saw";
                case JobName.BSM:
                    return "Cross-pein Hammer";
                case JobName.ARM:
                    return "Raising Hammer";
                case JobName.GSM:
                    return "Lapidary Hammer";
                case JobName.LTW:
                    return "Round Knife";
                case JobName.WVR:
                    return "Needle";
                case JobName.ALC:
                    return "Alembic";
                case JobName.CUL:
                    return "Frypan";
                case JobName.MNR:
                    return "Pickaxe";
                case JobName.BTN:
                    return "Hatchet";
                case JobName.FSH:
                    return "Fishing Rod";
                default:
                    return "";
            }
        }
        #endregion
    }
}
