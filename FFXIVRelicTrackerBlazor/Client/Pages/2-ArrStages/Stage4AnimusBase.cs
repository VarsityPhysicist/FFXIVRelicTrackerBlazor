using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using Microsoft.AspNetCore.Components;
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

        public override bool GetAnyCompleted()
        {
            throw new NotImplementedException();
        }

        public Stage4ARR ThisStage { get => character.ArrExpansion.Stage4ARR; }

        #region Book Related
        public AnimnusBookNames GetActiveBook()
        {
            return ThisStage.ActiveBook;
        }
        public async Task SetActiveBook(AnimnusBookNames value)
        {
            ThisStage.ActiveBook = value;
            await OnCharacterUpdate();
            await GetBookInfo(GetActiveBook());
            
            if (value != AnimnusBookNames.NA)
            {
                await SetDisplayInterface(true);
            }
            else
            {
                await SetDisplayInterface(false);
            }
        }
        public async Task SetActiveBook(ChangeEventArgs e)
        {
            if(Enum.TryParse<AnimnusBookNames>(e.Value.ToString(),out AnimnusBookNames value))
            {
                if (value != ThisStage.ActiveBook)
                {
                    await ChangedBook();
                }
                ThisStage.ActiveBook = value;
                await OnCharacterUpdate();
                await GetBookInfo(GetActiveBook());
                
                if (value != AnimnusBookNames.NA)
                {
                    await SetDisplayInterface(true);
                }
                else
                {
                    await SetDisplayInterface(false);
                }
            }
        }
        private async Task ChangedBook()
        {
            character.ArrExpansion.Stage4ARR = new Stage4ARR(ThisStage);
            await OnCharacterUpdate();
        }
        public List<AnimnusBookNames> AvailableBooks;

        private async Task GetAvailableBooks()
        {
            List<AnimnusBookNames> ReturnList = new List<AnimnusBookNames>();
            for (int i = 1; i <= Enum.GetValues(typeof(AnimnusBookNames)).Cast<int>().Max(); i++)
            {
                if (!ThisStage.BookBools[i])
                {
                    ReturnList.Add((AnimnusBookNames)i);
                }
            }
            if (!ReturnList.Contains(GetActiveBook())) await SetActiveBook(AnimnusBookNames.NA);
            AvailableBooks = ReturnList;
        }

        public bool BookSelected => GetActiveBook() != AnimnusBookNames.NA;

        #endregion
        #region Map Related
        public ArrMapNames GetActiveMap()
        {
            return ThisStage.ActiveMap;
        }

        private bool mapVisible;

        public bool GetMapVisible()
        {
            return mapVisible;
        }

        public async Task SetMapVisible(bool value)
        {
            mapVisible = value;
            await OnCharacterUpdate();
        }

        public async Task MapLoaded()
        {
            await SetMapVisible(true);
        }
        public async Task SetActiveMap(ArrMapNames value)
        {
            await SetMapVisible(false);
            ThisStage.ActiveMap = value;
            await RecheckMapItems();
            await OnCharacterUpdate();
        }
        public async Task SetActiveMap(ChangeEventArgs e)
        {
            if(Enum.TryParse<ArrMapNames>(e.Value.ToString(),out ArrMapNames value))
            {
                await SetMapVisible(false);
                ThisStage.ActiveMap = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }
        public string MapSource => "Images//" + GetActiveMap().ToString() + ".png";
        public bool MapSelected => GetActiveMap() != ArrMapNames.NA;
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
        public bool GetSkyFire1Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyFire1Book];
        }
        public async Task SetSkyFire1Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFire1Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetSkyFire2Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyFire2Book];
        }

        public async Task SetSkyFire2Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFire2Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetNetherFire1Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.NetherFire1Book];
        }

        public async Task SetNetherFire1Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.NetherFire1Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetSkyFall1Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyFall1Book];
        }

        public async Task SetSkyFall1Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFall1Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetSkyFall2Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyFall2Book];
        }

        public async Task SetSkyFall2Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyFall2Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetNetherFall1Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.NetherFall1Book];
        }

        public async Task SetNetherFall1Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.NetherFall1Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetSkyWind1Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyWind1Book];
        }

        public async Task SetSkyWind1Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyWind1Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetSkyWind2Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyWind2Book];
        }

        public async Task SetSkyWind2Complete(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyWind2Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        public bool GetSkyEarth1Complete()
        {
            return ThisStage.BookBools[(int)AnimnusBookNames.SkyEarth1Book];
        }

        public async Task SetSkyEarth1Complete(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.BookBools[(int)AnimnusBookNames.SkyEarth1Book] = value;
                await GetAvailableBooks();
                await OnCharacterUpdate();
            }
        }

        #endregion
        #region CreatureBools
        public bool GetCreatureBool1()
        {
            return ThisStage.BeastMen[0];
        }
        public async Task SetCreatureBool1(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[0] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool2()
        {
            return ThisStage.BeastMen[1];
        }

        public async Task SetCreatureBool2(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[1] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool3()
        {
            return ThisStage.BeastMen[2];
        }

        public async Task SetCreatureBool3(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[2] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool4()
        {
            return ThisStage.BeastMen[3];
        }

        public async Task SetCreatureBool4(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[3] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool5()
        {
            return ThisStage.BeastMen[4];
        }

        public async Task SetCreatureBool5(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[4] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool6()
        {
            return ThisStage.BeastMen[5];
        }

        public async Task SetCreatureBool6(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[5] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool7()
        {
            return ThisStage.BeastMen[6];
        }

        public async Task SetCreatureBool7(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[6] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool8()
        {
            return ThisStage.BeastMen[7];
        }

        public async Task SetCreatureBool8(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[7] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool9()
        {
            return ThisStage.BeastMen[8];
        }

        public async Task SetCreatureBool9(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.BeastMen[8] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetCreatureBool10()
        {
            return ThisStage.BeastMen[9];
        }

        public async Task SetCreatureBool10(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.BeastMen[9] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        #endregion
        #region FATEBools
        public bool GetFateBool1()
        {
            return ThisStage.Fates[0];
        }
        public async Task SetFateBool1(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.Fates[0] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }

        }

        public bool GetFateBool2()
        {
            return ThisStage.Fates[1];
        }

        public async Task SetFateBool2(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.Fates[1] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetFateBool3()
        {
            return ThisStage.Fates[2];
        }

        public async Task SetFateBool3(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.Fates[2] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        #endregion
        #region LeveBools
        public bool GetLeveBool1()
        {
            return ThisStage.Leves[0];
        }
        public async Task SetLeveBool1(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.Leves[0] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetLeveBool2()
        {
            return ThisStage.Leves[1];
        }

        public async Task SetLeveBool2(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.Leves[1] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        public bool GetLeveBool3()
        {
            return ThisStage.Leves[2];
        }

        public async Task SetLeveBool3(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.Leves[2] = value;
                await RecheckMapItems();
                await OnCharacterUpdate();
            }
        }

        #endregion
        #region DungeonBools
        public bool GetDungeonBool1()
        {
            return ThisStage.Dungeons[0];
        }
        public async Task SetDungeonBool1(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.Dungeons[0] = value;
                await OnCharacterUpdate();
            }
        }

        public bool GetDungeonBool2()
        {
            return ThisStage.Dungeons[1];
        }

        public async Task SetDungeonBool2(ChangeEventArgs e)
        {
            if (bool.TryParse(e.Value.ToString(), out bool value))
            {
                ThisStage.Dungeons[1] = value;
                await OnCharacterUpdate();
            }
        }

        public bool GetDungeonBool3()
        {
            return ThisStage.Dungeons[2];
        }

        public async Task SetDungeonBool3(ChangeEventArgs e)
        {
            if(bool.TryParse(e.Value.ToString(),out bool value))
            {
                ThisStage.Dungeons[2] = value;
                await OnCharacterUpdate();
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
            if (activeMap == ArrMapNames.NA) return;

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
        public bool GetDisplayInterface()
        {
            return ThisStage.DisplayInterface;
        }
        public async Task SetDisplayInterface(bool value)
        {
            ThisStage.DisplayInterface = value;
            await OnCharacterUpdate();
        }

        private async Task GetBookInfo(AnimnusBookNames animnusBookName)
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
                        await SetActiveMap(AvailableMaps[0]);
                    else
                        await SetActiveMap(ArrMapNames.NA);
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


        #endregion
        #region UI Interactions
        public async Task CompleteItem(MapItem mapItem)
        {
            int tempint;
            switch (mapItem.MapType)
            {
                case MapType.Creature:
                    tempint = Creatures.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                    if (tempint < 0) break;
                    ThisStage.BeastMen[tempint] = true;
                    HighlightCreatures[tempint] = false;
                    await OnCharacterUpdate();
                    break;
                case MapType.FATE:
                    tempint = FATEs.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                    if (tempint < 0) break;
                    ThisStage.Fates[tempint] = true;
                    HighlightFATES[tempint] = false;
                    await OnCharacterUpdate();
                    break;
                case MapType.Leve:
                    tempint = Leves.Select(x => x.DisplayName).ToList().IndexOf(mapItem.DisplayName);
                    if (tempint < 0) break;
                    ThisStage.Leves[tempint] = true;
                    HighlightLeves[tempint] = false;
                    await OnCharacterUpdate();
                    break;
            }
            mapItem.Hide = true;
            await GetBookInfo(GetActiveBook());
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
        private async Task RecheckMapItems()
        {
            await GetBookInfo(GetActiveBook());
            ResetMapped();
            ResetMapItems();
            if (MapSelected) SetMapInfo(GetActiveMap());
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
                    colorDec = "color: OrangeRed !important;";
                    break;
                case MapType.FATE:
                    mapList = MappedFATES;
                    highlightList = HighlightFATES;
                    completeBool = CompleteFates;
                    colorDec = "color: Purple !important;";
                    break;
                case MapType.Leve:
                    mapList = MappedLeves;
                    highlightList = HighlightLeves;
                    completeBool = CompleteLeves;
                    colorDec = "color: Blue !important;";
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
            if (!BookSelected) await SetDisplayInterface(false);
            await GetAvailableBooks();
            await CheckCharacter();
            await CheckJobs();
            await GetBookInfo(GetActiveBook());
            await RecheckMapItems();
        }

        public override Task SetAnyCompleted(ChangeEventArgs e)
        {
            throw new NotImplementedException();
        }
        public override string WeaponName => throw new NotImplementedException();
        public override string PreviousWeaponName => throw new NotImplementedException();
    }
}
