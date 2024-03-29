﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared.Helpers
{
    public static class JobsByExpansion
    {
        public static List<JobName> GetJobList(ExpansionName expansion)
        {
            switch (expansion)
            {
                case ExpansionName.Arr:
                    return ArrJobs;
                case ExpansionName.HW:
                    return HWJobs;
                case ExpansionName.SB:
                case ExpansionName.ShB:
                    return ShBJobs;
                case ExpansionName.Skysteel:
                    return SkysteelJobs;
                default:
                    return null;
            }
        }
        public static readonly List<JobName> ArrJobs = new List<JobName>
            {
                JobName.NA,
                JobName.PLD,
                JobName.WAR,
                JobName.WHM,
                JobName.SCH,
                JobName.MNK,
                JobName.DRG,
                JobName.NIN,
                JobName.BRD,
                JobName.BLM,
                JobName.SMN
            };
        public static readonly List<JobName> HWJobs = new List<JobName>
            {
                JobName.NA,
                JobName.PLD,
                JobName.WAR,
                JobName.DRK,
                JobName.WHM,
                JobName.SCH,
                JobName.AST,
                JobName.MNK,
                JobName.DRG,
                JobName.NIN,
                JobName.BRD,
                JobName.MCH,
                JobName.BLM,
                JobName.SMN
            };

        public static readonly List<JobName> ShBJobs = new List<JobName>
            {
                JobName.NA,
                JobName.PLD,
                JobName.WAR,
                JobName.DRK,
                JobName.GNB,
                JobName.WHM,
                JobName.SCH,
                JobName.AST,
                JobName.MNK,
                JobName.DRG,
                JobName.NIN,
                JobName.SAM,
                JobName.BRD,
                JobName.MCH,
                JobName.DNC,
                JobName.BLM,
                JobName.SMN,
                JobName.RDM
            };

        public static readonly List<JobName> SkysteelJobs = new List<JobName>
            {
                JobName.NA,
                JobName.CRP,
                JobName.BSM,
                JobName.ARM,
                JobName.GSM,
                JobName.LTW,
                JobName.WVR,
                JobName.ALC,
                JobName.CUL,
                JobName.MNR,
                JobName.BTN,
                JobName.FSH
            };
    }
}
