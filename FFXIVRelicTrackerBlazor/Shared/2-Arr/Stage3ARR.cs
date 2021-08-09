using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._2_Arr
{
    public class Stage3ARR : StageInfo
    {
        public override int StageIndex => (int)ArrStages.Atma;

        private int lionCount { get; set; }
        private int waterBearerCount { get; set; }
        private int ramCount { get; set; }
        private int crabCount { get; set; }
        private int fishCount { get; set; }
        private int bullCount { get; set; }
        private int scalesCount { get; set; }
        private int twinsCount { get; set; }
        private int scorpionCount { get; set; }
        private int archerCount { get; set; }
        private int goatCount { get; set; }
        private int maidenCount { get; set; }

        public int LionCount
        {
            get => lionCount;
            set
            {
                if (value >= 0 && value <= 10)
                    lionCount = value;
            }
        }
        public int WaterBearerCount
        {
            get => waterBearerCount;
            set
            {
                if (value >= 0 && value <= 10)
                    waterBearerCount = value;
            }
        }
        public int RamCount
        {
            get => ramCount;
            set
            {
                if (value >= 0 && value <= 10)
                    ramCount = value;
            }
        }
        public int CrabCount
        {
            get => crabCount;
            set
            {
                if (value >= 0 && value <= 10)
                    crabCount = value;
            }
        }
        public int FishCount
        {
            get => fishCount;
            set
            {
                if (value >= 0 && value <= 10)
                    fishCount = value;
            }
        }
        public int BullCount
        {
            get => bullCount;
            set
            {
                if (value >= 0 && value <= 10)
                    bullCount = value;
            }
        }
        public int ScalesCount
        {
            get => scalesCount;
            set
            {
                if (value >= 0 && value <= 10)
                    scalesCount = value;
            }
        }
        public int TwinsCount
        {
            get => twinsCount;
            set
            {
                if (value >= 0 && value <= 10)
                    twinsCount = value;
            }
        }
        public int ScorpionCount
        {
            get => scorpionCount;
            set
            {
                if (value >= 0 && value <= 10)
                    scorpionCount = value;
            }
        }
        public int ArcherCount
        {
            get => archerCount;
            set
            {
                if (value >= 0 && value <= 10)
                    archerCount = value;
            }
        }
        public int GoatCount
        {
            get => goatCount;
            set
            {
                if (value >= 0 && value <= 10)
                    goatCount = value;
            }
        }
        public int MaidenCount
        {
            get => maidenCount;
            set
            {
                if (value >= 0 && value <= 10)
                    maidenCount = value;
            }
        }

    }
}
