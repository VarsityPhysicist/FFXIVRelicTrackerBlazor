using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._3_HW;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using FFXIVRelicTrackerBlazor.Shared.Helpers.Misc;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._3_HWStages
{
    public class Stage1AnimatedBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.HWExpansion;

        public override StageInfo TargetStage => character.HWExpansion.Stage1HW;

        public Stage1HW ThisStage => character.HWExpansion.Stage1HW;


        public int WindCrystal => ThisStage.WindCrystal;

        public async Task SetWindCrystal(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.WindCrystal = value;
                await OnCharacterUpdate();
            }
        }
        public int FireCrystal => ThisStage.FireCrystal;

        public async Task SetFireCrystal(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.FireCrystal = value;
                await OnCharacterUpdate();
            }
        }
        public int LightningCrystal => ThisStage.LightningCrystal;

        public async Task SetLightningCrystal(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.LightningCrystal = value;
                await OnCharacterUpdate();
            }
        }
        public int IceCrystal => ThisStage.IceCrystal;

        public async Task SetIceCrystal(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.IceCrystal = value;
                await OnCharacterUpdate();
            }
        }
        public int EarthCrystal => ThisStage.EarthCrystal;

        public async Task SetEarthCrystal(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.EarthCrystal = value;
                await OnCharacterUpdate();
            }
        }
        public int WaterCrystal => ThisStage.WaterCrystal;

        public async Task SetWaterCrystal(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                ThisStage.WaterCrystal = value;
                await OnCharacterUpdate();
            }
        }
        public int RemainingWind => FilterLow(RemainingJobs - WindCrystal);
        public int RemainingFire => FilterLow(RemainingJobs - FireCrystal);
        public int RemainingLightning => FilterLow(RemainingJobs - LightningCrystal);
        public int RemainingIce => FilterLow(RemainingJobs - IceCrystal);
        public int RemainingEarth => FilterLow(RemainingJobs - EarthCrystal);
        public int RemainingWater => FilterLow(RemainingJobs - WaterCrystal);
    }
}
