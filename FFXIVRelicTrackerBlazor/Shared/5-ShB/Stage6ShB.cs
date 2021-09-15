using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_ShB
{
    public class Stage6ShB : StageInfo
    {
        public override int StageIndex => (int)ShBStages.Blades;
        private int rawEmotion { get; set; }

        public int RawEmotion
        {
            get => rawEmotion;
            set { rawEmotion = FilterChange(value, 15 * 17); }
        }
        private int compactAxle { get; set; }

        public int CompactAxle
        {
            get => compactAxle;
            set { compactAxle = FilterChange(value, 30); }
        }
        private int compactSpring { get; set; }

        public int CompactSpring
        {
            get => compactSpring;
            set { compactSpring = FilterChange(value, 30); }
        }
        private int battlesRealm { get; set; }

        public int BattlesRealm
        {
            get => battlesRealm;
            set { battlesRealm = FilterChange(value, 30); }
        }
        private int battlesRift { get; set; }

        public int BattlesRift
        {
            get => battlesRift;
            set { battlesRift = FilterChange(value, 30); }
        }
        private int bleakMemory { get; set; }

        public int BleakMemory
        {
            get => bleakMemory;
            set { bleakMemory = FilterChange(value, 30); }
        }
        private int luridMemory { get; set; }

        public int LuridMemory
        {
            get => luridMemory;
            set { luridMemory = FilterChange(value, 30); }
        }
    }
}
