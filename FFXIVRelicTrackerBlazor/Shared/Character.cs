﻿using FFXIVRelicTrackerBlazor.Shared._2_Arr;
using FFXIVRelicTrackerBlazor.Shared._3_HW;
using FFXIVRelicTrackerBlazor.Shared._5_ShB;
using FFXIVRelicTrackerBlazor.Shared._5_Skysteel;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
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
        public string Server { get; set; }
        public int ID { get; set; }
        public Character()
        {
            ArrExpansion = new ArrExpansion();
            HWExpansion = new HWExpansion();
            ShBExpansion = new ShBExpansion();
            SkysteelExpansion = new SkysteelExpansion();
            Name = "Default Character";
        }
        public Character(Character oldCharacter)
        {
            this.Name = oldCharacter.Name;
            this.Server = oldCharacter.Server;
            this.ID = oldCharacter.ID;
            this.DefaultJob = oldCharacter.DefaultJob;

            if (oldCharacter.ArrExpansion == null) this.ArrExpansion = new ArrExpansion();
            else this.ArrExpansion = oldCharacter.ArrExpansion;

            if (oldCharacter.HWExpansion == null) this.HWExpansion = new HWExpansion();
            else this.HWExpansion = oldCharacter.HWExpansion;

            if (oldCharacter.ShBExpansion == null) this.ShBExpansion = new ShBExpansion();
            else this.ShBExpansion = oldCharacter.ShBExpansion;

            if (oldCharacter.SkysteelExpansion == null) this.SkysteelExpansion = new SkysteelExpansion();
            else this.SkysteelExpansion = oldCharacter.SkysteelExpansion;
        }

        public List<AbstractExpansion> GetExpansions()
        {
            return new List<AbstractExpansion>()
            {
                ArrExpansion,
                HWExpansion,
                ShBExpansion,
                SkysteelExpansion
            };
        }
        public ArrExpansion ArrExpansion { get; set; }
        public HWExpansion HWExpansion { get; set; }
        public ShBExpansion ShBExpansion { get; set; }
        public SkysteelExpansion SkysteelExpansion { get; set; }
        public JobName DefaultJob { get; set; }
        public bool AutoAssignCompletion { get; set; }

    }
}
