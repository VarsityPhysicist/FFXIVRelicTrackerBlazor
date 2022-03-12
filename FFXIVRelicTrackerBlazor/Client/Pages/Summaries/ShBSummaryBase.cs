using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages.Summaries
{
    public class ShBSummaryBase : AbstractSummaryBase
    {
        public override AbstractExpansion TargetExpansion => character.ShBExpansion;
    }
}
