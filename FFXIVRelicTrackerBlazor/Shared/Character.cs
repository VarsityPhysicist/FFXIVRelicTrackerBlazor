using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared._3_HW;
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
            HWExpansion = new HWExpansion();
            Name = "Default Character";
        }
        public Character(Character oldCharacter)
        {
            this.Name = oldCharacter.Name;

            if (oldCharacter.ArrExpansion == null) this.ArrExpansion = new ArrExpansion();
            else this.ArrExpansion = oldCharacter.ArrExpansion;

            if (oldCharacter.HWExpansion == null) this.HWExpansion = new HWExpansion();
            else this.HWExpansion = oldCharacter.HWExpansion;
        }
        public ArrExpansion ArrExpansion { get; set; }
        public HWExpansion HWExpansion { get; set; }
    }
}
