using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._3_HW
{
    public class Stage1HW : StageInfo
    {
        public override int StageIndex => (int)HWStages.Animated;

        private int windCrystal { get; set; }
        private int fireCrystal { get; set; }
        private int lightningCrystal { get; set; }
        private int iceCrystal { get; set; }
        private int earthCrystal { get; set; }
        private int waterCrystal { get; set; }

        public int WindCrystal
        {
            get => windCrystal;
            set
            {
                windCrystal = FilterChange(value, 13);
            }
        }
        public int FireCrystal
        {
            get => fireCrystal;
            set
            {
                fireCrystal = FilterChange(value, 13);
            }
        }
        public int LightningCrystal
        {
            get => lightningCrystal;
            set
            {
                lightningCrystal = FilterChange(value, 13);
            }
        }
        public int IceCrystal
        {
            get => iceCrystal;
            set
            {
                iceCrystal = FilterChange(value, 13);
            }
        }
        public int EarthCrystal
        {
            get => earthCrystal;
            set
            {
                earthCrystal = FilterChange(value, 13);
            }
        }
        public int WaterCrystal
        {
            get => waterCrystal;
            set
            {
                waterCrystal = FilterChange(value, 13);
            }
        }
    }
}
