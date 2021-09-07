using FFXIVRelicTrackerBlazor.Shared;
using Microsoft.AspNetCore.Components;
using FFXIVRelicTrackerBlazor.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Text.Json;
using FFXIVRelicTrackerBlazor.Shared.XIVAPI;
using FFXIVRelicTrackerBlazor.Shared.Helpers;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public class HomePageBase : AbstractPageBase
    {

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public ICallXIVAPI CallXIVAPI { get; set; }

        public string CharacterName
        {
            get => character.Name;
            set
            {
                if (value != null)
                {
                    State.SetCharacterAsync(value);
                }
            }
        }

        private List<string> characterStringList = new List<string>();
        public List<string> CharacterStringList
        {
            get => characterStringList;
            set { characterStringList = value; _ = SaveCharacterListAsync(); }
        }

        public override async Task AdditionalInitializeAsync()
        {
            //await LocalStorage.SetItemAsync("CharacterList", new List<String>());

            await LoadCharacterListAsync();
            await GetServers();
        }

        private async Task SaveCharacterListAsync()
        {
            await LocalStorage.SetItemAsync("CharacterList", characterStringList);
        }
        private async Task LoadCharacterListAsync()
        {
            var stringList = await LocalStorage.GetItemAsync<List<string>>("CharacterList");
            if (stringList != null)
                CharacterStringList = stringList;
            else { CharacterStringList = new List<string>(); }
            if (!State.PlaceHolderCharacter && !CharacterStringList.Contains(character.Name)) CharacterStringList.Add(character.Name);
        }

        public bool ShowRename = false;
        public bool ShowAdd = false;
        public bool ShowRemove = false;
        public bool ShowSelect = false;
        public string NewName { get; set; }
        public string RemoveName { get; set; }
        public string AddName { get; set; }
        public async Task CreateCharacter(string addName)
        {
            if (addName == string.Empty | addName == null | NewName == "DefaultCharacter") return;
            if (CharacterStringList.Contains(addName)) return;

            var tempCharacter = new Character() { Name = addName };
            CharacterStringList.Add(addName);
            character = tempCharacter;
            await State.UpdateCharacterAsync();
            await State.SetDefaultCharacterAsync();
            await SaveCharacterListAsync();
            ShowAdd = false;
            AddName = string.Empty;
        }
        internal async Task ChangeCharacterName(string newName)
        {
            if (newName == string.Empty | newName == null | NewName == "DefaultCharacter") return;
            if (CharacterStringList.Contains(newName)) return;

            int oldIndex = characterStringList.IndexOf(character.Name);
            characterStringList.RemoveAt(oldIndex);
            characterStringList.Insert(oldIndex, newName);

            await LocalStorage.RemoveItemAsync(CharacterName);

            character.Name = newName;
            await State.UpdateCharacterAsync();
            await State.SetDefaultCharacterAsync();
            await SaveCharacterListAsync();
            ShowRename = false;
            NewName = string.Empty;
        }
        internal async Task RemoveCharacter(string removeName)
        {
            if (removeName == string.Empty | removeName == null) return;
            if (characterStringList.Count == 1)
            {
                character = new Character();
                characterStringList.Remove(removeName);
                await LocalStorage.RemoveItemAsync(removeName);
                await CreateCharacter("Default Character");
            }
            else
            {
                characterStringList.Remove(removeName);
                await LocalStorage.RemoveItemAsync(removeName);
            }
            if (character.Name == removeName) await State.SetCharacterAsync(characterStringList[0]);

            await SaveCharacterListAsync();
            ShowRemove = false;
            RemoveName = string.Empty;
        }

        #region Call Character XIVAPI
        public List<APICharacter> apiCharacters = new List<APICharacter>();
        public bool ShowCallAPI = false;

        public string CharacterListMessage;
        public bool CharacterListFetched = false;
        public async Task GetCharacterListButton()
        {
            CharacterListFetched = false;
            CharacterListMessage = "Fetching matching Characters...";
            try
            {
                apiCharacters = (await CallXIVAPI.GetCharacterByName(character.Name, GetCharacterServer)).Results;

                if (apiCharacters == null) { CharacterListMessage = "Error parsing characters"; }
                else if (apiCharacters.Count == 0) { CharacterListMessage = "No characters found with specified Name and Server"; }
                else
                {
                    CharacterListMessage = string.Empty;
                    CharacterListFetched = true;
                }
            }
            catch(Exception ex)
            {
                CharacterListMessage = "Error fetching characters";
            }

        }
        public string CharacterMessage;
        public bool CharacterFetched = false;

        public string GetCharacterServer => character.Server;
        public async Task SetCharacterServer(Microsoft.AspNetCore.Components.ChangeEventArgs e)
        {
            character.Server = e.Value.ToString();
            await OnCharacterUpdate();
        }

        public int GetCharacterID => character.ID;
        public async Task SetCharacterID(Microsoft.AspNetCore.Components.ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                character.ID = value;
                await OnCharacterUpdate();
            }
        }


        public bool APICharacterSelected => GetCharacterID != 0;
        public bool APICharacterNotSelected => GetCharacterID == 0;


        public async Task GetCharacterDataButton()
        {
            CharacterMessage = string.Empty;
            if (GetCharacterID != 0)
            {
                CharacterMessage = "Fetching selected Character data...";

                try
                {
                    CharacterData characterData = await CallXIVAPI.GetCharacterByID(GetCharacterID);
                    if (characterData == null) { CharacterMessage = "Character not identified"; }
                    else if (!characterData.AchievementsPublic) { CharacterMessage = "Character achievements not public. Cannot import"; }
                    else
                    {
                        CharacterMessage = "Parsing achievements";
                        await ProcessAchievements(characterData);
                        CharacterMessage = "Achievements Parsed";
                    }
                }
                catch(Exception ex)
                {
                    CharacterMessage = "Error encountered fetching data";
                }

            }
        }
        #endregion
        #region Call Server XIVAPI
        public bool ServersLoaded = false;
        public string ServerMessage;
        public List<string> Servers { get; set; }
        private async Task GetServers()
        {
            ServerMessage = "Fetching list of Servers...";
            try
            {
                if (!ServersLoaded)
                {
                    Servers = (await CallXIVAPI.GetServers());
                }

                if (Servers == null) { ServerMessage = "Error fetching list of Servers"; }
                else { ServerMessage = ""; }

                ServersLoaded = true;
            }
            catch(Exception ex)
            {
                ServerMessage = "Error encountered fetching list of Servers";
            }

        }
        #endregion

        #region Process Achievements
        private async Task ProcessAchievements(CharacterData characterData)
        {
            #region ARR
            if (characterData.Achievements.List.Exists(x => x.ID == 136))
            {
                MasterStageHelper.CompleteStage(character, JobName.PLD, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.WAR, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.WHM, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.SCH, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.MNK, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.DRG, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.NIN, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.BRD, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.BLM, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
                MasterStageHelper.CompleteStage(character, JobName.SMN, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false);
            }
            else
            {
                if (characterData.Achievements.List.Exists(x => x.ID == 129)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 131)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 134)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 598)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 130)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 132)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 1053)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 133)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 135)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
                if (characterData.Achievements.List.Exists(x => x.ID == 597)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)ArrStages.Relic, character.ArrExpansion.Expansion, false); }
            }
            #endregion
            #region HW
            if (characterData.Achievements.List.Exists(x => x.ID == 1708)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1695)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1667)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1605)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1499)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1406)) { MasterStageHelper.CompleteStage(character, JobName.PLD, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1709)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1696)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1668)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1606)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1500)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1407)) { MasterStageHelper.CompleteStage(character, JobName.MNK, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1710)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1697)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1669)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1607)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1501)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1408)) { MasterStageHelper.CompleteStage(character, JobName.WAR, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1711)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1698)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1670)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1608)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1502)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1409)) { MasterStageHelper.CompleteStage(character, JobName.DRG, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1712)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1699)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1671)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1609)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1503)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1410)) { MasterStageHelper.CompleteStage(character, JobName.BRD, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1713)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1700)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1672)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1610)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1504)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1411)) { MasterStageHelper.CompleteStage(character, JobName.WHM, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1714)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1701)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1673)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1611)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1505)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1412)) { MasterStageHelper.CompleteStage(character, JobName.BLM, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1715)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1702)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1674)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1612)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1506)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1413)) { MasterStageHelper.CompleteStage(character, JobName.SMN, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1716)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1703)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1675)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1613)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1507)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1414)) { MasterStageHelper.CompleteStage(character, JobName.SCH, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1717)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1704)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1676)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1614)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1508)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1415)) { MasterStageHelper.CompleteStage(character, JobName.NIN, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1718)) { MasterStageHelper.CompleteStage(character, JobName.MCH, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1705)) { MasterStageHelper.CompleteStage(character, JobName.MCH, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1677)) { MasterStageHelper.CompleteStage(character, JobName.MCH, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1615)) { MasterStageHelper.CompleteStage(character, JobName.MCH, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1509)) { MasterStageHelper.CompleteStage(character, JobName.MCH, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1416)) { MasterStageHelper.CompleteStage(character, JobName.MCH, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1719)) { MasterStageHelper.CompleteStage(character, JobName.DRK, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1706)) { MasterStageHelper.CompleteStage(character, JobName.DRK, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1678)) { MasterStageHelper.CompleteStage(character, JobName.DRK, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1616)) { MasterStageHelper.CompleteStage(character, JobName.DRK, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1510)) { MasterStageHelper.CompleteStage(character, JobName.DRK, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1417)) { MasterStageHelper.CompleteStage(character, JobName.DRK, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            if (characterData.Achievements.List.Exists(x => x.ID == 1720)) { MasterStageHelper.CompleteStage(character, JobName.AST, (int)HWStages.Lux, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1707)) { MasterStageHelper.CompleteStage(character, JobName.AST, (int)HWStages.Complete, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1679)) { MasterStageHelper.CompleteStage(character, JobName.AST, (int)HWStages.Sharpened, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1617)) { MasterStageHelper.CompleteStage(character, JobName.AST, (int)HWStages.Reconditioned, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1511)) { MasterStageHelper.CompleteStage(character, JobName.AST, (int)HWStages.Hyperconductive, character.HWExpansion.Expansion, false); }
            else if (characterData.Achievements.List.Exists(x => x.ID == 1418)) { MasterStageHelper.CompleteStage(character, JobName.AST, (int)HWStages.Anima, character.HWExpansion.Expansion, false); }

            #endregion

            await OnCharacterUpdate();
        }
        #endregion
    }
}
