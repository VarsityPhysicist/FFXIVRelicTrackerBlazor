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
    public class Stage4AnimusBase : AbstractStagePageBase
    {
        public override List<JobName> ValidJobs => JobsByExpansion.ArrJobs;

        public override AbstractExpansion TargetExpansion => character.ArrExpansion;

        public override StageInfo TargetStage => character.ArrExpansion.Stage4ARR;

        public override bool AnyCompleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ArrStages StageName => ArrStages.Animus;

        public Stage4ARR ThisStage { get => character.ArrExpansion.Stage4ARR; }

        #region Book Related
        public AnimnusBookNames ActiveBook
        {
            get => ThisStage.ActiveBook;
            set
            {
                ThisStage.ActiveBook = value;
                _ = OnCharacterUpdate();
                GetBookInfo(ActiveBook);
            }
        }
        public static List<AnimnusBookNames> AvailableBooks
        {
            get
            {
                List<AnimnusBookNames> ReturnList = new List<AnimnusBookNames>();
                for (int i = 1; i <= Enum.GetValues(typeof(AnimnusBookNames)).Cast<int>().Max(); i++)
                {
                    ReturnList.Add((AnimnusBookNames)i);
                }
                return ReturnList;
            }
        }

        public bool BookSelected => ActiveBook != AnimnusBookNames.NA;
        #endregion
        #region Map Related
        public ArrMapNames ActiveMap
        {
            get => ThisStage.ActiveMap;
            set
            {
                ThisStage.ActiveMap = value;
                RecheckMapItems();
            }
        }
        public string MapSource => "Images//" + ActiveMap.ToString() + ".png";
        public bool MapSelected => ActiveMap != ArrMapNames.NA;
        public List<ArrMapNames> AvailableMaps { get; set; }
        #endregion
        #region Display Lists
        public List<MapItem> Creatures;
        public List<MapItem> FATEs;
        public List<MapItem> Leves;
        public List<String> Dungeons;
        public List<ArrMapNames> Maps;
        #endregion
        #region BookBools
        public bool SkyFire1Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyFire1Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFire1Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool SkyFire2Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyFire2Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFire2Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool NetherFire1Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.NetherFire1Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.NetherFire1Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool SkyFall1Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyFall1Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFall1Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool SkyFall2Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyFall2Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFall2Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool NetherFall1Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.NetherFall1Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.NetherFall1Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool SkyWind1Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyWind1Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyWind1Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool SkyWind2Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyWind2Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyWind2Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool SkyEarth1Complete
        {
            get => ThisStage.BookBools[(int)AnimnusBookNames.SkyEarth1Book];
            set
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyEarth1Book] = value;
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region CreatureBools
        public bool CreatureBool1
        {
            get => ThisStage.BeastMen[0];
            set
            {
                ThisStage.BeastMen[0] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool2
        {
            get => ThisStage.BeastMen[1];
            set
            {
                ThisStage.BeastMen[1] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool3
        {
            get => ThisStage.BeastMen[2];
            set
            {
                ThisStage.BeastMen[2] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool4
        {
            get => ThisStage.BeastMen[3];
            set
            {
                ThisStage.BeastMen[3] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool5
        {
            get => ThisStage.BeastMen[4];
            set
            {
                ThisStage.BeastMen[4] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool6
        {
            get => ThisStage.BeastMen[5];
            set
            {
                ThisStage.BeastMen[5] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool7
        {
            get => ThisStage.BeastMen[6];
            set
            {
                ThisStage.BeastMen[6] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool8
        {
            get => ThisStage.BeastMen[7];
            set
            {
                ThisStage.BeastMen[7] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool9
        {
            get => ThisStage.BeastMen[8];
            set
            {
                ThisStage.BeastMen[8] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool CreatureBool10
        {
            get => ThisStage.BeastMen[9];
            set
            {
                ThisStage.BeastMen[9] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region FATEBools
        public bool FateBool1
        {
            get => ThisStage.Fates[0];
            set
            {
                ThisStage.Fates[0] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool FateBool2
        {
            get => ThisStage.Fates[1];
            set
            {
                ThisStage.Fates[1] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool FateBool3
        {
            get => ThisStage.Fates[2];
            set
            {
                ThisStage.Fates[2] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region LeveBools
        public bool LeveBool1
        {
            get => ThisStage.Leves[0];
            set
            {
                ThisStage.Leves[0] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool LeveBool2
        {
            get => ThisStage.Leves[1];
            set
            {
                ThisStage.Leves[1] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        public bool LeveBool3
        {
            get => ThisStage.Leves[2];
            set
            {
                ThisStage.Leves[2] = value;
                RecheckMapItems();
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region DungeonBools
        public bool DungeonBool1
        {
            get => ThisStage.Dungeons[0];
            set
            {
                ThisStage.Dungeons[0] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool DungeonBool2
        {
            get => ThisStage.Dungeons[1];
            set
            {
                ThisStage.Dungeons[1] = value;
                _ = OnCharacterUpdate();
            }
        }
        public bool DungeonBool3
        {
            get => ThisStage.Dungeons[2];
            set
            {
                ThisStage.Dungeons[2] = value;
                _ = OnCharacterUpdate();
            }
        }
        #endregion
        #region MapItems
        public MapItem CreatureItem1;
        public MapItem CreatureItem2;
        public MapItem CreatureItem3;

        public MapItem FateItem1;
        public MapItem FateItem2;

        public MapItem LeveItem1;
        #endregion
        
        #region Configure Map Items
        private void SetMapInfo(ArrMapNames activeMap)
        {
            foreach (var creature in Creatures)
            {
                int mappedIndex = Creatures.IndexOf(creature);
                if (creature.ArrMapName == activeMap && !CompleteCreatures[mappedIndex])
                {
                    MappedCreatures[mappedIndex] = true;
                    if (CreatureItem1 == null) CreatureItem1 = creature;
                    else if (CreatureItem2 == null) CreatureItem2 = creature;
                    else if (CreatureItem3 == null) CreatureItem3 = creature;
                    else throw new Exception();
                }
            }

            foreach (var fate in FATEs)
            {
                int mappedIndex = FATEs.IndexOf(fate);
                if (fate.ArrMapName == activeMap && !CompleteFates[mappedIndex])
                {
                    MappedFATES[mappedIndex] = true;
                    if (FateItem1 == null) FateItem1 = fate;
                    else if (FateItem2 == null) FateItem2 = fate;
                    else throw new Exception();
                }
            }

            foreach (var leve in Leves)
            {
                int mappedIndex = Leves.IndexOf(leve);
                if (leve.ArrMapName == activeMap && !CompleteLeves[mappedIndex])
                {
                    MappedLeves[mappedIndex] = true;
                    LeveItem1 = leve;
                }
            }
        }
        private void ResetMapItems()
        {
            CreatureItem1 = null;
            CreatureItem2 = null;
            CreatureItem3 = null;

            FateItem1 = null;
            FateItem2 = null;

            LeveItem1 = null;
        }
        private void HideMapItems()
        {
            if (CreatureItem1 == null) CreatureItem1 = new MapItem() { Hide = true };
            if (CreatureItem2 == null) CreatureItem2 = new MapItem() { Hide = true };
            if (CreatureItem3 == null) CreatureItem3 = new MapItem() { Hide = true };

            if (FateItem1 == null) FateItem1 = new MapItem() { Hide = true };
            if (FateItem2 == null) FateItem2 = new MapItem() { Hide = true };

            if (LeveItem1 == null) LeveItem1 = new MapItem() { Hide = true };
        }
        #endregion
        #region GetBookFromMisc
        private void GetBookInfo(AnimnusBookNames animnusBookName)
        {
            if (BookSelected)
            {
                Creatures = GetCreatures(animnusBookName);
                FATEs = GetFates(animnusBookName);
                Leves = GetLeves(animnusBookName);
                Dungeons = GetDungeons(animnusBookName);

                HashSet<ArrMapNames> arrMapNames = new HashSet<ArrMapNames>();

                for (int i = 0; i < Creatures.Count; i++) if (!ThisStage.BeastMen[i]) arrMapNames.Add(Creatures[i].ArrMapName);
                for (int i = 0; i < FATEs.Count; i++) if (!ThisStage.Fates[i]) arrMapNames.Add(FATEs[i].ArrMapName);
                for (int i = 0; i < Leves.Count; i++) if (!ThisStage.Leves[i]) arrMapNames.Add(Leves[i].ArrMapName);


                int initialMaps;
                if (AvailableMaps != null) initialMaps = AvailableMaps.Count;
                else initialMaps = 0;

                AvailableMaps = new List<ArrMapNames>(arrMapNames.ToList().OrderBy(x => x.ToString()));

                if (initialMaps > AvailableMaps.Count)
                {
                    if (AvailableMaps.Count > 0)
                        ActiveMap = AvailableMaps[0];
                    else
                        ActiveMap = ArrMapNames.NA;
                }
            }
        }
        private static List<MapItem> GetCreatures(AnimnusBookNames animnusBookName)
        {
            List<MapItem> returnList = MiscArr.ReturnCreatures(animnusBookName);
            return returnList;
        }
        private static List<MapItem> GetLeves(AnimnusBookNames animnusBookName)
        {
            List<MapItem> returnList = MiscArr.ReturnLeves(animnusBookName);
            return returnList;
        }
        private static List<MapItem> GetFates(AnimnusBookNames animnusBookName)
        {
            List<MapItem> returnList = MiscArr.ReturnFATEs(animnusBookName);
            return returnList;
        }
        private static List<string> GetDungeons(AnimnusBookNames animnusBookName)
        {
            List<string> returnList = MiscArr.ReturnBookDungeons(animnusBookName);
            return returnList;
        }
        #endregion
        #region Text Decoration Lists
        private void ResetMapped()
        {
            MappedCreatures = new List<bool>()
                    {
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false
                    };
            MappedFATES = new List<bool>()
                    {
                        false,
                        false,
                        false
                    };
            MappedLeves = new List<bool>()
                    {
                        false,
                        false,
                        false
                    };
        }
        public List<bool> HighlightCreatures = new List<bool>()
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false
        };
        public List<bool> HighlightFATES = new List<bool>()
        {
            false,
            false,
            false
        };
        public List<bool> HighlightLeves = new List<bool>()
        {
            false,
            false,
            false
        };
        public List<bool> MappedCreatures = new List<bool>()
        {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false
        };
        public List<bool> MappedFATES = new List<bool>()
        {
            false,
            false,
            false
        };
        public List<bool> MappedLeves = new List<bool>()
        {
            false,
            false,
            false
        };
        private List<bool> CompleteCreatures => ThisStage.BeastMen;
        private List<bool> CompleteFates => ThisStage.Fates;
        private List<bool> CompleteLeves => ThisStage.Leves;

        public override string WeaponName => throw new NotImplementedException();

        public override string PreviousWeaponName => throw new NotImplementedException();

        #endregion
        #region UI Interactions
        public void CompleteItem(MapItem mapItem)
        {
            int tempint;
            switch (mapItem.MapType)
            {
                case MapType.Creature:
                    tempint = Creatures.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                    if (tempint < 0) break;
                    ThisStage.BeastMen[tempint] = true;
                    HighlightCreatures[tempint] = false;
                    _ = OnCharacterUpdate();
                    break;
                case MapType.FATE:
                    tempint = FATEs.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                    if (tempint < 0) break;
                    ThisStage.Fates[tempint] = true;
                    HighlightFATES[tempint] = false;
                    _ = OnCharacterUpdate();
                    break;
                case MapType.Leve:
                    tempint = Leves.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                    if (tempint < 0) break;
                    ThisStage.Leves[tempint] = true;
                    HighlightLeves[tempint] = false;
                    _ = OnCharacterUpdate();
                    break;
            }
            mapItem.Hide = true;
            GetBookInfo(ActiveBook);
        }
        public void MouseOverItem(MapItem mapItem)
        {
            if (!mapItem.Hide)
            {
                int tempint;
                switch (mapItem.MapType)
                {
                    case MapType.Creature:
                        tempint = Creatures.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                        if (tempint < 0) break;
                        HighlightCreatures[tempint] = true;
                        break;
                    case MapType.FATE:
                        tempint = FATEs.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                        if (tempint < 0) break;
                        HighlightFATES[tempint] = true;
                        break;
                    case MapType.Leve:
                        tempint = Leves.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                        if (tempint < 0) break;
                        HighlightLeves[tempint] = true;
                        break;
                }
            }
        }
        public void MouseOutItem(MapItem mapItem)
        {
            if (!mapItem.Hide)
            {
                int tempint;
                switch (mapItem.MapType)
                {
                    case MapType.Creature:
                        tempint = Creatures.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                        if (tempint < 0) break;
                        HighlightCreatures[tempint] = false;
                        break;
                    case MapType.FATE:
                        tempint = FATEs.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                        if (tempint < 0) break;
                        HighlightFATES[tempint] = false;
                        break;
                    case MapType.Leve:
                        tempint = Leves.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                        if (tempint < 0) break;
                        HighlightLeves[tempint] = false;
                        break;
                }
            }
        }
        #endregion
        private void RecheckMapItems()
        {
            GetBookInfo(ActiveBook);
            ResetMapped();
            ResetMapItems();
            if (MapSelected) SetMapInfo(ActiveMap);
            HideMapItems();
        }
        public string returnDec(int index, MapType mapType)
        {
            string returnDec = string.Empty;
            string colorDec = string.Empty;
            List<bool> mapList = new List<bool>();
            List<bool> highlightList = new List<bool>();
            List<bool> completeBool = new List<bool>();

            switch (mapType)
            {
                case MapType.Creature:
                    mapList = MappedCreatures;
                    highlightList = HighlightCreatures;
                    completeBool = CompleteCreatures;
                    colorDec = "color: OrangeRed;";
                    break;
                case MapType.FATE:
                    mapList = MappedFATES;
                    highlightList = HighlightFATES;
                    completeBool = CompleteFates;
                    colorDec = "color: Purple;";
                    break;
                case MapType.Leve:
                    mapList = MappedLeves;
                    highlightList = HighlightLeves;
                    completeBool = CompleteLeves;
                    colorDec = "color: Blue;";
                    break;
                default:
                    return "";
            }

            bool isComplete = completeBool[index];
            bool isHighlighted = highlightList[index];
            bool isMapped = mapList[index];

            if (isComplete) returnDec = "text-decoration:line-through;";
            else
            {
                if (isMapped) returnDec = colorDec + "font-weight: bold;";
                else returnDec = "color: Black;";

                if (isHighlighted) returnDec += " text-decoration: underline;";
            }
            return returnDec;
        }
        
        public override async Task AdditionalInitializeAsync()
        {
            await CheckCharacter();
            await CheckJobs();
            GetBookInfo(ActiveBook);
            RecheckMapItems();
        }
       
    }
}
