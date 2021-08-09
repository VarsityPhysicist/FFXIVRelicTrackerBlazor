using FFXIVRelicTrackerBlazor.Shared;
using Microsoft.AspNetCore.Components;
using FFXIVRelicTrackerBlazor.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Text.Json;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public class HomePageBase: AbstractPageBase
    {
        
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public string newName { get; set; }

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
        }

        private async Task SaveCharacterListAsync()
        {
            await LocalStorage.SetItemAsync("CharacterList", characterStringList);
        }
        private async Task LoadCharacterListAsync()
        {
            var stringList = await LocalStorage.GetItemAsync<List<string>>("CharacterList");
            if(stringList!=null)
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
            if (newName == string.Empty | newName == null | NewName=="DefaultCharacter") return;
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
            if(character.Name==removeName)  await State.SetCharacterAsync(characterStringList[0]);

            await SaveCharacterListAsync();
            ShowRemove = false;
            RemoveName = string.Empty;
        }
    }
}
