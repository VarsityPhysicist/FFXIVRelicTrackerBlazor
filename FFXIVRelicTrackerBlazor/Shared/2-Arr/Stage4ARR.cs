using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage4ARR : StageInfo
    {
        public Stage4ARR(Stage4ARR stage4ARR)
        {
            this.bookBools = stage4ARR.bookBools;
            this.ActiveJob = stage4ARR.ActiveJob;
            beastMen = new List<bool>()
            {
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false
            };
            fates = new List<bool>()
            {
                false,
                false,
                false
            };
            leves = new List<bool>()
            {
                false,
                false,
                false
            };
            dungeons = new List<bool>()
            {
                false,
                false,
                false
            };
        }
        public Stage4ARR()
        {
            bookBools = new List<bool>()
            {
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false
            };
            beastMen = new List<bool>()
            {
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false,
                false
            };
            fates = new List<bool>()
            {
                false,
                false,
                false
            };
            leves = new List<bool>()
            {
                false,
                false,
                false
            };
            dungeons = new List<bool>()
            {
                false,
                false,
                false
            };
        }
        public override int StageIndex => (int)ArrStages.Animus;

        private List<bool> bookBools;
        public List<bool> BookBools
        {
            get => bookBools;
            set { bookBools = value; }
        }
        public AnimnusBookNames ActiveBook { get; set; }

        #region Beastmen
        private List<bool> beastMen;
        public List<bool> BeastMen
        {
            get => beastMen;
            set { beastMen = value; }
        }


        public bool Beastmen01 { get; set; }
        public bool Beastmen02 { get; set; }
        public bool Beastmen03 { get; set; }
        public bool Beastmen04 { get; set; }
        public bool Beastmen05 { get; set; }
        public bool Beastmen06 { get; set; }
        public bool Beastmen07 { get; set; }
        public bool Beastmen08 { get; set; }
        public bool Beastmen09 { get; set; }
        public bool Beastmen10 { get; set; }
        #endregion
        #region FATEs
        private List<bool> fates;
        public List<bool> Fates
        {
            get => fates;
            set { fates = value; }
        }
        public bool FATE1 { get; set; }
        public bool FATE2 { get; set; }
        public bool FATE3 { get; set; }
        #endregion
        #region Leves
        private List<bool> leves;
        public List<bool> Leves
        {
            get => leves;
            set { leves = value; }
        }
        public bool Leve1 { get; set; }
        public bool Leve2 { get; set; }
        public bool Leve3 { get; set; }
        #endregion
        #region Dungeons
        private List<bool> dungeons;
        public List<bool> Dungeons
        {
            get => dungeons;
            set { dungeons = value; }
        }
        public bool Dungeon1 { get; set; }
        public bool Dungeon2 { get; set; }
        public bool Dungeon3 { get; set; }
        #endregion
        public ArrMapNames ActiveMap { get; set; }
        public bool DisplayInterface { get; set; }
        public bool MapVisible { get; set; }
    }
}
