using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Shared
{
    public abstract class AbstractExpansion
    {
        public abstract ExpansionName Expansion { get; }
        public List<Job> Jobs { get; set; }
        public abstract int StageCount { get; }
        public abstract List<StageInfo> GetStages();
        public bool AdjustCounts { get; set; }


        internal List<Job> GenerateJobs()
        {
            var jobList = JobsByExpansion.GetJobList(Expansion);
            var stageList = StagesByExpansion.GetStageList(Expansion);

            Jobs = new List<Job>();

            foreach(var job in jobList)
            {
                var tempJob = new Job() { JobName = job, Stages = new List<Stage>() };
                foreach (var stage in stageList)
                { 
                    tempJob.Stages.Add(new Stage() { StageName = stage, Progress = Progress.NA, StageIndex=tempJob.Stages.Count});
                }
                Jobs.Add(tempJob);
            }

            AdjustCounts = true;

            return Jobs;
        }
    }
}
