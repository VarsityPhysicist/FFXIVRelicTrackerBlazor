using FFXIVRelicTrackerBlazor.Shared.XIVAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Services
{
    public class CallXIVAPI : ICallXIVAPI
    {
        private readonly HttpClient _httpClient;
        public CallXIVAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CharacterData> GetCharacterByID(int charID)
        {
            string callString = string.Format("https://xivapi.com/character/{0}?data=ac", charID);
            //var callResult = await _httpClient.GetAsync(callString);
            var callResult = await _httpClient.SendAsync(MakeRequest(callString));

            if (callResult.IsSuccessStatusCode)
            {
                try
                {
                    CharacterData characterData= await JsonSerializer.DeserializeAsync<CharacterData>
                    (await callResult.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return characterData;
                }
                catch(Exception ex) { return null; }
            }
            else
                return null;
        }

        public async Task<CharacterByName> GetCharacterByName(string characterName, string serverName)
        {
            characterName = characterName.Replace(" ", "+");
            string callString = string.Format("https://xivapi.com/character/search?name={0}&server={1}", characterName, serverName);

            //var callResult = await _httpClient.GetAsync(callString);
            var callResult = await _httpClient.SendAsync(MakeRequest(callString));
            if (callResult.IsSuccessStatusCode)
            {
                try
                {
                    CharacterByName character = await JsonSerializer.DeserializeAsync<CharacterByName>
                    (await callResult.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if (character.Pagination.PageTotal > 1) 
                    { 
                        for(int index=1;index<=character.Pagination.PageTotal; index++)
                        {
                            character.Results.AddRange((await GetCharacterByName(callString, index)).Results);
                        }
                    }

                    return character;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }

            else
                return null;
        }
        public async Task<CharacterByName> GetCharacterByName(string callString, int page)
        {
            callString = callString + string.Format("&page={0}", page);
            //var callResult = await _httpClient.GetAsync(callString);
            var callResult = await _httpClient.SendAsync(MakeRequest(callString));

            CharacterByName character = await JsonSerializer.DeserializeAsync<CharacterByName>
                   (await callResult.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return character;
        }

        public async Task<List<string>> GetServers()
        {
            var request = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri=new Uri("https://xivapi.com/servers")
            };
            request.Headers.Add("Accept", "text/plain");

            var callResult = await _httpClient.SendAsync(MakeRequest("https://xivapi.com/servers"));
            //var callResult = await _httpClient.GetAsync("https://xivapi.com/servers",HttpCompletionOption.ResponseHeadersRead);
            if (callResult.IsSuccessStatusCode)
            {
                try
                {
                    var serverList = await JsonSerializer.DeserializeAsync<List<string>>
                    (await callResult.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    return serverList;
                }
                catch(Exception ex)
                {
                    return null;
                }
                
            }
            
            else
                return null;
        }

        private HttpRequestMessage MakeRequest(string uriTarget)
        {
            var request = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri(uriTarget)
            };
            request.Headers.Add("Accept", "text/plain");

            return request;
        }
    }
}
