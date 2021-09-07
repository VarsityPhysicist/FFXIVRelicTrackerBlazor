using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.XIVAPI
{
    public class CharacterByName
    {
        public Pagination Pagination { get; set; }
        public List<APICharacter> Results { get; set; }
    }

    public class Pagination
    {
        public int Page { get; set; }
        public object PageNext { get; set; }
        public object PagePrev { get; set; }
        public int PageTotal { get; set; }
        public int Results { get; set; }
        public int ResultsPerPage { get; set; }
        public int ResultsTotal { get; set; }
    }
    public class APICharacter
    {
        public string Avatar { get; set; }
        public int FeastMatches { get; set; }
        public int ID { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public object Rank { get; set; }
        public object RankIcon { get; set; }
        public string Server { get; set; }
    }
}
