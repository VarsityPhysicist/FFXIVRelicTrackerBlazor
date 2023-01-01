using FFXIVRelicTrackerBlazor.Shared;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Services
{
    public static class Importer
    {
        public async static Task<Tuple<List<Character>, Tuple<ImportResult, string>>> Import(IBrowserFile file)
        {
            if (file is null)
                return new Tuple<List<Character>, Tuple<ImportResult, string>>(new List<Character>(), new Tuple<ImportResult, string>(ImportResult.Failure, "Specified file does not exist"));

            try
            {
                var reader = await new StreamReader(file.OpenReadStream()).ReadToEndAsync();
                var characters = System.Text.Json.JsonSerializer.Deserialize<List<Character>>(reader);
                return new Tuple<List<Character>, Tuple<ImportResult, string>>(characters, new Tuple<ImportResult, string>(ImportResult.Success, String.Empty));
            }
            catch
            {
                return new Tuple<List<Character>, Tuple<ImportResult, string>>(new List<Character>(), new Tuple<ImportResult, string>(ImportResult.Failure, "Unable to deserialize file"));
            }
        }
        public enum ImportResult
        {
            Success,
            Failure
        }

    }

}
