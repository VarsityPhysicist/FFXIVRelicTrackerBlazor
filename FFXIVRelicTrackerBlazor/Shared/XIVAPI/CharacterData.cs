using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.XIVAPI
{
    public class CharacterData
    {
        public Achievements Achievements { get; set; }
    }
    public class Achievements
    {
        public List<Items> List { get; set; }
        public int Points { get; set; }
    }
    public class Items
    {
        public int Date { get; set; }
        public int ID { get; set; }
    }
}
