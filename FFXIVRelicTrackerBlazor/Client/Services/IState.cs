using FFXIVRelicTrackerBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace FFXIVRelicTrackerBlazor.Client.Services
{
    public interface IState
    {
        public event Action Notify;
        public Character Character { get; set; }
        public Task SetCharacterAsync(string characterName);
        public Task UpdateCharacterAsync();
        public Task InitializeComponent();
        public Task SetDefaultCharacterAsync();
        public bool PlaceHolderCharacter { get; set; }
    }

    public class State : IState
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        public State(ILocalStorageService localStorageService)
        {
            LocalStorage = localStorageService;
            Character = new Character();
            PlaceHolderCharacter = true;
        }
        public bool PlaceHolderCharacter { get; set; }
        private Character character;
        public Character Character
        {
            get => character;
            set
            {
                if (character != value)
                {
                    character = value;
                    if (Notify != null)
                    {
                        Notify?.Invoke();
                    }
                }
            }
        }

        public event Action Notify;

        private async Task SaveCharacterAsync()
        {
            if (character == null)
                return;
            await LocalStorage.SetItemAsync(character.Name, character);
        }

        public async Task SetCharacterAsync(string characterName)
        {
            var tempChar = await LocalStorage.GetItemAsync<Character>(characterName);
            if (tempChar == null)
            {
                Character = new Character() { Name = characterName };
            }
            else 
            { 
                Character = new Character(tempChar);
            }
            await SetDefaultCharacterAsync();
        }

        public async Task SetDefaultCharacterAsync()
        {
            if (character != null) await LocalStorage.SetItemAsync("DefaultCharacter", character.Name);
        }

        public async Task UpdateCharacterAsync()
        {
            await SaveCharacterAsync();

            if (Notify != null)
            {
                Notify?.Invoke();
            }
        }
        public async Task InitializeComponent()
        {
            if (PlaceHolderCharacter) await CheckForDefaultCharacter();
            if (PlaceHolderCharacter) await CheckCharacterList();
            if (PlaceHolderCharacter) Character = new Character();
            PlaceHolderCharacter = false;

        }
        public async Task CheckForDefaultCharacter()
        {
            var defaultName = await LocalStorage.GetItemAsync<string>("DefaultCharacter");
            if (defaultName != null)
            {
                var defaultCharacter = await LocalStorage.GetItemAsync<Character>(defaultName);
                if (defaultCharacter != null)
                {
                    character = defaultCharacter;
                    PlaceHolderCharacter = false;
                }
            }

        }
        public async Task CheckCharacterList()
        {
            var characterStringList = await LocalStorage.GetItemAsync<List<string>>("CharacterList");
            if (characterStringList != null)
            {
                for (int i = 0; i < characterStringList.Count; i++)
                {
                    var tempCharacter = await LocalStorage.GetItemAsync<Character>(characterStringList[i]);
                    if (tempCharacter != null)
                    {
                        character = tempCharacter;
                        PlaceHolderCharacter = false;
                        return;
                    }
                }
            }
        }
    }
}
