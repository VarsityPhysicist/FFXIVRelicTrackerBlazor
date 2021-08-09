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
                case ExpansionName.SB:
                case ExpansionName.ShB:
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
    }
}
