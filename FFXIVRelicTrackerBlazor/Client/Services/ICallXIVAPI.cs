using FFXIVRelicTrackerBlazor.Shared.XIVAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Services
{
    public interface ICallXIVAPI
    {
        public Task<CharacterByName> GetCharacterByName(string characterName, string serverName);
        public Task<CharacterData> GetCharacterByID(int charID);
        public Task<List<string>> GetServers();
    }
}
