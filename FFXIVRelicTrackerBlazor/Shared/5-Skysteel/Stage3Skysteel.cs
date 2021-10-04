using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared._5_Skysteel
{
    public class Stage3Skysteel : StageInfo
    {
        public override int StageIndex => (int)SkySteelStages.Dragonsung;

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
        private int fSHMat { get; set; }

        public int CRPMat { get => cRPMat; set => cRPMat = FilterChange(value, 30); }
        public int BSMMat { get => bSMMat; set => bSMMat = FilterChange(value, 30); }
        public int ARMMat { get => aRMMat; set => aRMMat = FilterChange(value, 30); }
        public int GSMMat { get => gSMMat; set => gSMMat = FilterChange(value, 30); }
        public int LTWMat { get => lTWMat; set => lTWMat = FilterChange(value, 30); }
        public int WVRMat { get => wVRMat; set => wVRMat = FilterChange(value, 30); }
        public int ALCMat { get => aLCMat; set => aLCMat = FilterChange(value, 30); }
        public int CULMat { get => cULMat; set => cULMat = FilterChange(value, 30); }

        public int MNRMat1 { get => mNRMat1; set => mNRMat1 = FilterChange(value, 510); }
        public int MNRMat2 { get => mNRMat2; set => mNRMat2 = FilterChange(value, 180); }
        public int BTNMat1 { get => bTNMat1; set => bTNMat1 = FilterChange(value, 510); }
        public int BTNMat2 { get => bTNMat2; set => bTNMat2 = FilterChange(value, 180); }
        public int FSHMat { get => fSHMat; set => fSHMat = FilterChange(value, 60); }
    }
}
