using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared
{
    public class Character
    {
        public string Name { get; set; }
        public Character()
        {
            ArrExpansion = new ArrExpansion();
            Name = "Default Character";
        }
        public Character(Character oldCharacter)
        {
            this.Name = oldCharacter.Name;

            if (oldCharacter.ArrExpansion == null) this.ArrExpansion = new ArrExpansion();
            else this.ArrExpansion = oldCharacter.ArrExpansion;
        }
        public ArrExpansion ArrExpansion { get; set; }
    }
}
