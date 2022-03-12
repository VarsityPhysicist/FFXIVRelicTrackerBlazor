using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public abstract class AbstractSkysteel : StageInfo
    {
        public abstract int CrafterCount { get; }
        public abstract int GatherCount1 { get; }
        public abstract int GatherCount2 { get; }
        public abstract int FSHCount1 { get; }
        public abstract int FSHCount2 { get; }



        private int cRPMat { get; set; }
        private int bSMMat { get; set; }
        private int aRMMat { get; set; }
        private int gSMMat { get; set; }
        private int lTWMat { get; set; }
        private int wVRMat { get; set; }
        private int aLCMat { get; set; }
        private int cULMat { get; set; }

        private int mNRMat1 { get; set; }
        private int mNRMat2 { get; set; }
        private int bTNMat1 { get; set; }
        private int bTNMat2 { get; set; }
        private int fSHMat1 { get; set; }
        private int fSHMat2 { get; set; }

        public int CRPMat { get => cRPMat; set => cRPMat = FilterChange(value, CrafterCount); }
        public int BSMMat { get => bSMMat; set => bSMMat = FilterChange(value, CrafterCount); }
        public int ARMMat { get => aRMMat; set => aRMMat = FilterChange(value, CrafterCount); }
        public int GSMMat { get => gSMMat; set => gSMMat = FilterChange(value, CrafterCount); }
        public int LTWMat { get => lTWMat; set => lTWMat = FilterChange(value, CrafterCount); }
        public int WVRMat { get => wVRMat; set => wVRMat = FilterChange(value, CrafterCount); }
        public int ALCMat { get => aLCMat; set => aLCMat = FilterChange(value, CrafterCount); }
        public int CULMat { get => cULMat; set => cULMat = FilterChange(value, CrafterCount); }
        public int MNRMat1 { get => mNRMat1; set => mNRMat1 = FilterChange(value, GatherCount1); }
        public int MNRMat2 { get => mNRMat2; set => mNRMat2 = FilterChange(value, GatherCount2); }
        public int BTNMat1 { get => bTNMat1; set => bTNMat1 = FilterChange(value, GatherCount1); }
        public int BTNMat2 { get => bTNMat2; set => bTNMat2 = FilterChange(value, GatherCount2); }
        public int FSHMat1 { get => fSHMat1; set => fSHMat1 = FilterChange(value, FSHCount1); }
        public int FSHMat2 { get => fSHMat2; set => fSHMat2 = FilterChange(value, FSHCount2); }

        public bool DisplayCRP { get; set; }
        public bool DisplayBSM { get; set; }
        public bool DisplayARM { get; set; }
        public bool DisplayGSM { get; set; }
        public bool DisplayLTW { get; set; }
        public bool DisplayWVR { get; set; }
        public bool DisplayALC { get; set; }
        public bool DisplayCUL { get; set; }
        public bool DisplayMNR { get; set; }
        public bool DisplayBTN { get; set; }
        public bool DisplayFSH { get; set; }
    }
}
