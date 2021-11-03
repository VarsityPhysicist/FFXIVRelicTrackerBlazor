using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers.Misc
{
    public static class SkysteelMisc
    {
        public static string GetStageTurnInMats(JobName job, int stageindex, int matIndex = 1)
        {
            switch (stageindex)
            {
                case (int)SkySteelStages.AugmentedDragonsung:
                    return Stage4TurnInMats(job, matIndex);
                case (int)SkySteelStages.Skybuilders:
                    return Stage5TurnInMats(job, matIndex);
                case (int)SkySteelStages.Skysung:
                    return Stage6TurnInMats(job, matIndex);
                default:
                    return string.Empty;
            }
        }
        public static string GetStageCraftMats(JobName job, int stageindex, int matIndex = 1)
        {
            switch (stageindex)
            {
                case (int)SkySteelStages.Skysteel_1:
                    return Stage2CraftMats(job, matIndex);
                case (int)SkySteelStages.Dragonsung:
                    return Stage3CraftMats(job, matIndex);
                case (int)SkySteelStages.AugmentedDragonsung:
                    return Stage4CraftMats(job, matIndex);
                case (int)SkySteelStages.Skybuilders:
                    return Stage5CraftMats(job, matIndex);
                case (int)SkySteelStages.Skysung:
                    return Stage6CraftMats(job, matIndex);
                default:
                    return string.Empty;
            }
        }
        public static string GetStageRawMats(JobName job, int stageindex, int matIndex)
        {
            switch (stageindex)
            {
                case (int)SkySteelStages.Skysteel_1:
                    return Stage2RawMats(job, matIndex);
                case (int)SkySteelStages.Dragonsung:
                    return Stage3RawMats(job, matIndex);
                case (int)SkySteelStages.AugmentedDragonsung:
                    return Stage4RawMats(job, matIndex);
                case (int)SkySteelStages.Skysung:
                    return Stage5RawMats(job, matIndex);
                case (int)SkySteelStages.Skybuilders:
                    return Stage6RawMats(job, matIndex);
                default:
                    return string.Empty;
            }
        }

        private static string Stage2CraftMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Oddly Specific Petrified Orb";
                case JobName.BSM:
                    return "Oddly Specific Rivets";
                case JobName.ARM:
                    return "Oddly Specific Wire";
                case JobName.GSM:
                    return "Oddly Specific Whetstone";
                case JobName.LTW:
                    return "Oddly Specific Leather";
                case JobName.WVR:
                    return "Oddly Specific Moonbeam Silk";
                case JobName.ALC:
                    return "Oddly Specific Synthetic Resin";
                case JobName.CUL:
                    return "Oddly Specific Seed Extract";
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Obsidian";
                        case 2:
                            return "Oddly Specific Mineral Sand";
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Latex";
                        case 2:
                            return "Oddly Specific Fossil Dust";
                    }
                case JobName.FSH:
                    return "Thinker's Coral";
                default:
                    return string.Empty;
            }
        }
        private static string Stage3CraftMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Oddly Specific Shaft";
                case JobName.BSM:
                    return "Oddly Specific Fitting";
                case JobName.ARM:
                    return "Oddly Specific Chainmail sheet";
                case JobName.GSM:
                    return "Oddly Specific Gemstone";
                case JobName.LTW:
                    return "Oddly Specific Vellum";
                case JobName.WVR:
                    return "Oddly Specific Velvet";
                case JobName.ALC:
                    return "Oddly Specific Glass";
                case JobName.CUL:
                    return "Oddly Specific Seed Flour";
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Dark Matter";
                        case 2:
                            return "Oddly Specific Striking Stone";
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Amber";
                        case 2:
                            return "Oddly Specific Bauble";
                    }
                case JobName.FSH:
                    return "Dragonspine";
                default:
                    return string.Empty;
            }
        }
        private static string Stage4CraftMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Oddly Specific Cedar Lumber";
                case JobName.BSM:
                    return "Oddly Specific Iron Nails";
                case JobName.ARM:
                    return "Oddly Specific Mythril Rings";
                case JobName.GSM:
                    return "Oddly Specific Silver Nugget";
                case JobName.LTW:
                    return "Oddly Specific Gaganaskin Strap";
                case JobName.WVR:
                    return "Oddly Specific Cloth";
                case JobName.ALC:
                    return "Oddly Specific Glue";
                case JobName.CUL:
                    return "Oddly Specific Oil";
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Schorl";
                        case 2:
                            return "Oddly Specific Landborne Aethersand";
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Dark Chestnut Log";
                        case 2:
                            return "Oddly Specific Leafborne Aethersand";
                    }
                case JobName.FSH:
                    return "Petal Shell";
                default:
                    return string.Empty;
            }
        }
        private static string Stage5CraftMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Oddly Specific Cedar Plank";
                case JobName.BSM:
                    return "Oddly Specific Iron Ingot";
                case JobName.ARM:
                    return "Oddly Specific Mythril Plate";
                case JobName.GSM:
                    return "Oddly Specific Silver Ingot";
                case JobName.LTW:
                    return "Oddly Specific Gagana Leather";
                case JobName.WVR:
                    return "Oddly Specific Undyed Woolen Cloth";
                case JobName.ALC:
                    return "Oddly Specific Rubber";
                case JobName.CUL:
                    return "Oddly Specific Paste";
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Primordial Ore";
                        case 2:
                            return "Oddly Specific Primordial Asphaltum";
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Primordial Log";
                        case 2:
                            return "Oddly Specific Primordial Resin";
                    }
                case JobName.FSH:
                    return "Allagan Hunter";
                default:
                    return string.Empty;
            }
        }
        private static string Stage6CraftMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Oddly Delicate Pine Lumber";
                case JobName.BSM:
                    return "Oddly Delicate Silver Gear";
                case JobName.ARM:
                    return "Oddly Delicate Wolfram Square";
                case JobName.GSM:
                    return "Oddly Delicate Celestine";
                case JobName.LTW:
                    return "Oddly Delicate Gazelle Leather";
                case JobName.WVR:
                    return "Oddly Delicate Rhea Cloth";
                case JobName.ALC:
                    return "Oddly Delicate Holy Water";
                case JobName.CUL:
                    return "Oddly Delicate Shark Oil";
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Adamantite Ore";
                        case 2:
                            return "Oddly Delicate Raw Jade";
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Feather";
                        case 2:
                            return "Oddly Delicate Birch Log";
                    }
                case JobName.FSH:
                    switch (matIndex)
                    {
                        default:
                            return "Flintstrike";
                        case 2:
                            return "Pickled Pom";
                    }
                default:
                    return string.Empty;
            }
        }

        private static string Stage2RawMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Petrified Log";
                        case 2:
                            return "White Ash Log";
                    }
                case JobName.BSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Iron Sand";
                        case 2:
                            return "Manasilver Sand";
                    }
                case JobName.ARM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Iron Ore";
                        case 2:
                            return "Manasilver Sand";
                    }
                case JobName.GSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Uncut Gemstone";
                        case 2:
                            return "Manasilver Sand";
                    }
                case JobName.LTW:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Skin";
                        case 2:
                            return "Atrociraptor Skin";
                    }
                case JobName.WVR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Cotton";
                        case 2:
                            return "Pixie Floss Boll";
                    }
                case JobName.ALC:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Quartz";
                        case 2:
                            return "Vampire Vine Sap";
                    }
                case JobName.CUL:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Seeds";
                        case 2:
                            return "Highland Spring Water";
                    }
                default:
                    return string.Empty;
            }
        }
        private static string Stage3RawMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Petrified Log";
                        case 2:
                            return "Sandteak Lumber";
                    }
                case JobName.BSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Iron Sand";
                        case 2:
                            return "Titanbronze Ingot";
                    }
                case JobName.ARM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Iron Ore";
                        case 2:
                            return "Titanbronze Ingot";
                    }
                case JobName.GSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Uncut Gemstone";
                        case 2:
                            return "Tuff Whetstone";
                    }
                case JobName.LTW:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Skin";
                        case 2:
                            return "Zonure Leather";
                    }
                case JobName.WVR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Cotton";
                        case 2:
                            return "Ovim Wool";
                    }
                case JobName.ALC:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Quartz";
                        case 2:
                            return "Refined Natron";
                    }
                case JobName.CUL:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Seeds";
                        case 2:
                            return "Night Vinegar";
                    }
                default:
                    return string.Empty;
            }
        }
        private static string Stage4RawMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Cedar Log";
                        case 2:
                            return "Lignum Vitae Log";
                    }
                case JobName.BSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Coerthan Iron Ore";
                        case 2:
                            return "Dimythrite Ore";
                    }
                case JobName.ARM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Mythrite Sand";
                        case 2:
                            return "Dimythrite Ore";
                    }
                case JobName.GSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Silver Ore";
                        case 2:
                            return "Dimythrite Sand";
                    }
                case JobName.LTW:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Gagana Skin";
                        case 2:
                            return "Yellow Alumen";
                    }
                case JobName.WVR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Fleece";
                        case 2:
                            return "Dwarven Cottom Boll";
                    }
                case JobName.ALC:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Sap";
                        case 2:
                            return "Vampire Cup Vine";
                    }
                case JobName.CUL:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Aloe";
                        case 2:
                            return "Frantoio";
                    }
                default:
                    return string.Empty;
            }
        }
        private static string Stage5RawMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Cedar Log";
                        case 2:
                            return "Lignum Vitae Lumber";
                    }
                case JobName.BSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Coerthan Iron Ore";
                        case 2:
                            return "Dwarven Mythril Ingot";
                    }
                case JobName.ARM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Mythrite Sand";
                        case 2:
                            return "Dwarven Mythril Ingot";
                    }
                case JobName.GSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Silver Ore";
                        case 2:
                            return "Dwarven Mythril Nugget";
                    }
                case JobName.LTW:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Gagana Skin";
                        case 2:
                            return "Sea Swallow Leather";
                    }
                case JobName.WVR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Fleece";
                        case 2:
                            return "Dwarven Cotton";
                    }
                case JobName.ALC:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Sap";
                        case 2:
                            return "Refined Natron";
                    }
                case JobName.CUL:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Specific Aloe";
                        case 2:
                            return "Night Vinegar";
                    }
                default:
                    return string.Empty;
            }
        }
        private static string Stage6RawMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Pine Log";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Log";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Barbgrass";
                    }
                case JobName.BSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Silvergrace Ore";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Cloudstone";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Silex";
                    }
                case JobName.ARM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Scheelite";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Cloudstone";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Prismstone";
                    }
                case JobName.GSM:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Celestine";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Silex";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Barbgrass";
                    }
                case JobName.LTW:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Gazelle Hide";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Log";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Caiman";
                    }
                case JobName.WVR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Rhea";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Cocoon";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Stalagmite";
                    }
                case JobName.ALC:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Mistletoe";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Spring Water";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Raspberry";
                    }
                case JobName.CUL:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Shark";
                        case 2:
                            return "Approved Grade 4 Artisanal Skybuilders' Spring Water";
                        case 3:
                            return "Approved Grade 4 Artisanal Skybuilders' Stalagmite";
                    }
                default:
                    return string.Empty;
            }
        }

        private static string Stage4TurnInMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Carpenter's Gobbiegoo";
                case JobName.BSM:
                    return "Blacksmith's Gobbiegoo";
                case JobName.ARM:
                    return "Armorer's Gobbiegoo";
                case JobName.GSM:
                    return "Goldsmith's Gobbiegoo";
                case JobName.LTW:
                    return "Leatherworker's Gobbiegoo";
                case JobName.WVR:
                    return "Weaver's Gobbiegoo";
                case JobName.ALC:
                    return "Alchemist's Gobbiegoo";
                case JobName.CUL:
                    return "Culinarian's Gobbiegoo";
                case JobName.MNR:
                    return "Miner's Gobbiegoo";
                case JobName.BTN:
                    return "Botanist's Gobbiegoo";
                case JobName.FSH:
                    return "Fisher's Gobbiegoo";
                default:
                    return string.Empty;
            }
        }
        private static string Stage5TurnInMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Highly Viscous Carpenter's Gobbiegoo";
                case JobName.BSM:
                    return "Highly Viscous Blacksmith's Gobbiegoo";
                case JobName.ARM:
                    return "Highly Viscous Armorer's Gobbiegoo";
                case JobName.GSM:
                    return "Highly Viscous Goldsmith's Gobbiegoo";
                case JobName.LTW:
                    return "Highly Viscous Leatherworker's Gobbiegoo";
                case JobName.WVR:
                    return "Highly Viscous Weaver's Gobbiegoo";
                case JobName.ALC:
                    return "Highly Viscous Alchemist's Gobbiegoo";
                case JobName.CUL:
                    return "Highly Viscous Culinarian's Gobbiegoo";
                case JobName.MNR:
                    return "Highly Viscous Miner's Gobbiegoo";
                case JobName.BTN:
                    return "Highly Viscous Botanist's Gobbiegoo";
                case JobName.FSH:
                    return "Highly Viscous Fisher's Gobbiegoo";
                default:
                    return string.Empty;
            }
        }
        private static string Stage6TurnInMats(JobName job, int matIndex)
        {
            switch (job)
            {
                case JobName.CRP:
                    return "Oddly Delicate Saw Part";
                case JobName.BSM:
                    return "Oddly Delicate Cross-pein Hammer Part";
                case JobName.ARM:
                    return "Oddly Delicate Raising Hammer Part";
                case JobName.GSM:
                    return "Oddly Delicate Lapidary Hammer Part";
                case JobName.LTW:
                    return "Oddly Delicate Round Knife Part";
                case JobName.WVR:
                    return "Oddly Delicate Needle Part";
                case JobName.ALC:
                    return "Oddly Delicate Alembic Part";
                case JobName.CUL:
                    return "Oddly Delicate Frypan Part";
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Pickaxe Part";
                        case 2:
                            return "Inconceivably Delicate Pickaxe Part";
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Hatchet Part";
                        case 2:
                            return "Inconceivably Delicate Frypan Part";
                    }
                case JobName.FSH:
                    switch (matIndex)
                    {
                        default:
                            return "Oddly Delicate Fishing Rod Part";
                        case 2:
                            return "Inconceivably Delicate Fishing Rod Part";
                    }
                default:
                    return string.Empty;
            }
        }


    }
}
