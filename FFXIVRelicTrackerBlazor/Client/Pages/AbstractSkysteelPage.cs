using FFXIVRelicTrackerBlazor.Shared._5_Skysteel;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages
{
    public abstract class AbstractSkysteelPage : AbstractStagePageBase
    {
        public string GetStageTurnInMats(JobName job, int matIndex = 1)
        {
            return SkysteelMisc.GetStageTurnInMats(job, StageIndex, matIndex);
        }
        public string GetStageCraftMats(JobName job, int matIndex = 1)
        {
            return SkysteelMisc.GetStageCraftMats(job, StageIndex, matIndex);
        }
        public string GetStageRawMats(JobName job, int matIndex = 1)
        {
            return SkysteelMisc.GetStageRawMats(job, StageIndex, matIndex);
        }

        public abstract AbstractSkysteel SkysteelClass { get; }

        public int GetMatCount(JobName job, int matIndex = 1)
        {
            switch (job)
            {
                case JobName.CRP:
                    return SkysteelClass.CRPMat;
                case JobName.BSM:
                    return SkysteelClass.BSMMat;
                case JobName.ARM:
                    return SkysteelClass.ARMMat;
                case JobName.GSM:
                    return SkysteelClass.GSMMat;
                case JobName.LTW:
                    return SkysteelClass.LTWMat;
                case JobName.WVR:
                    return SkysteelClass.WVRMat;
                case JobName.ALC:
                    return SkysteelClass.ALCMat;
                case JobName.CUL:
                    return SkysteelClass.CULMat;
                case JobName.MNR:
                    switch (matIndex)
                    {
                        default:
                            return SkysteelClass.MNRMat1;
                        case 2:
                            return SkysteelClass.MNRMat2;
                    }
                case JobName.BTN:
                    switch (matIndex)
                    {
                        default:
                            return SkysteelClass.BTNMat1;
                        case 2:
                            return SkysteelClass.BTNMat2;
                    }
                case JobName.FSH:
                    switch (matIndex)
                    {
                        default:
                            return SkysteelClass.FSHMat1;
                        case 2:
                            return SkysteelClass.FSHMat2;
                    }
                default:
                    return -1;
            }
        }
        public async Task SetMatCount(ChangeEventArgs e, JobName job, int matIndex = 1)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                switch (job)
                {
                    case JobName.CRP:
                        SkysteelClass.CRPMat = value;
                        break;
                    case JobName.BSM:
                        SkysteelClass.BSMMat = value;
                        break;
                    case JobName.ARM:
                        SkysteelClass.ARMMat = value;
                        break;
                    case JobName.GSM:
                        SkysteelClass.GSMMat = value;
                        break;
                    case JobName.LTW:
                        SkysteelClass.LTWMat = value;
                        break;
                    case JobName.WVR:
                        SkysteelClass.WVRMat = value;
                        break;
                    case JobName.ALC:
                        SkysteelClass.ALCMat = value;
                        break;
                    case JobName.CUL:
                        SkysteelClass.CULMat = value;
                        break;
                    case JobName.MNR:
                        switch (matIndex)
                        {
                            default:
                                SkysteelClass.MNRMat1 = value;
                                break;
                            case 2:
                                SkysteelClass.MNRMat2 = value;
                                break;
                        }
                        break;
                    case JobName.BTN:
                        switch (matIndex)
                        {
                            default:
                                SkysteelClass.BTNMat1 = value;
                                break;
                            case 2:
                                SkysteelClass.BTNMat2 = value;
                                break;
                        }
                        break;
                    case JobName.FSH:
                        switch (matIndex)
                        {
                            default:
                                SkysteelClass.FSHMat1 = value;
                                break;
                            case 2:
                                SkysteelClass.FSHMat2 = value;
                                break;
                        }
                        break;
                    default:
                        break;
                }
                await OnCharacterUpdate();
            }
        }

        public bool ShowJob(JobName job)
        {
            switch (job)
            {
                case JobName.CRP:
                    return SkysteelClass.DisplayCRP;
                case JobName.BSM:
                    return SkysteelClass.DisplayBSM;
                case JobName.ARM:
                    return SkysteelClass.DisplayARM;
                case JobName.GSM:
                    return SkysteelClass.DisplayGSM;
                case JobName.LTW:
                    return SkysteelClass.DisplayLTW;
                case JobName.WVR:
                    return SkysteelClass.DisplayWVR;
                case JobName.ALC:
                    return SkysteelClass.DisplayALC;
                case JobName.CUL:
                    return SkysteelClass.DisplayCUL;
                case JobName.MNR:
                    return SkysteelClass.DisplayMNR;
                case JobName.BTN:
                    return SkysteelClass.DisplayBTN;
                case JobName.FSH:
                    return SkysteelClass.DisplayFSH;
                default:
                    return false;
            }
        }
        public async Task SetShowJob(JobName job, bool value)
        {
            switch (job)
            {
                case JobName.CRP:
                    SkysteelClass.DisplayCRP = value;
                    break;
                case JobName.BSM:
                    SkysteelClass.DisplayBSM = value;
                    break;
                case JobName.ARM:
                    SkysteelClass.DisplayARM = value;
                    break;
                case JobName.GSM:
                    SkysteelClass.DisplayGSM = value;
                    break;
                case JobName.LTW:
                    SkysteelClass.DisplayLTW = value;
                    break;
                case JobName.WVR:
                    SkysteelClass.DisplayWVR = value;
                    break;
                case JobName.ALC:
                    SkysteelClass.DisplayALC = value;
                    break;
                case JobName.CUL:
                    SkysteelClass.DisplayCUL = value;
                    break;
                case JobName.MNR:
                    SkysteelClass.DisplayMNR = value;
                    break;
                case JobName.BTN:
                    SkysteelClass.DisplayBTN = value;
                    break;
                case JobName.FSH:
                    SkysteelClass.DisplayFSH = value;
                    break;
                default:
                    break;
            }
            await OnCharacterUpdate();
        }
        public static bool IsGatherer(JobName job) => DoLJobs.Contains(job) | job==JobName.FSH;
        public static List<JobName> DoLJobs = new List<JobName>() { JobName.MNR, JobName.BTN};
        public static List<JobName> DoHJobs = new List<JobName>() { JobName.CRP,JobName.BSM,JobName.ARM,JobName.GSM,JobName.LTW,JobName.WVR,JobName.ALC,JobName.CUL };

    }
}
