using FFXIVRelicTrackerBlazor.Shared;
using FFXIVRelicTrackerBlazor.Shared._5_ShB;
using FFXIVRelicTrackerBlazor.Shared.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFXIVRelicTrackerBlazor.Client.Pages._5_ShBStages
{
    public class Stage6BladesBase : AbstractStagePageBase
    {
        public override AbstractExpansion TargetExpansion => character.ShBExpansion;

        public override StageInfo TargetStage => character.ShBExpansion.Stage6ShB;

        public Stage6ShB ThisStage => character.ShBExpansion.Stage6ShB;


        public int GetCompactAxle => ThisStage.CompactAxle;
        public async Task SetCompactAxle(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.CompactAxle = value; await OnCharacterUpdate(); } }
        public int GetCompactSpring => ThisStage.CompactSpring;
        public async Task SetCompactSpring(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.CompactSpring = value; await OnCharacterUpdate(); } }

        public int GetBattlesRealm => ThisStage.BattlesRealm;
        public async Task SetBattlesRealm(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.BattlesRealm = value; await OnCharacterUpdate(); } }
        public int GetBattlesRift => ThisStage.BattlesRift;
        public async Task SetBattlesRift(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.BattlesRift = value; await OnCharacterUpdate(); } }

        public int GetBleakMemory => ThisStage.BleakMemory;
        public async Task SetBleakMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.BleakMemory = value; await OnCharacterUpdate(); } }
        public int GetLuridMemory => ThisStage.LuridMemory;
        public async Task SetLuridMemory(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.LuridMemory = value; await OnCharacterUpdate(); } }

        public int GetRawEmotion => ThisStage.RawEmotion;
        public async Task SetRawEmotion(ChangeEventArgs e) { if (int.TryParse(e.Value.ToString(), out int value)) { ThisStage.RawEmotion = value; await OnCharacterUpdate(); } }

        public int RemainingCompactAxle() => FilterLow(30 - GetCompactAxle);
        public int RemainingCompactSpring() => FilterLow(30 - GetCompactSpring);
        public int RemainingBattlesRealm() => FilterLow(30 - GetBattlesRealm);
        public int RemainingBattlesRift() => FilterLow(30 - GetBattlesRift);
        public int RemainingBleakMemory() => FilterLow(30 - GetBleakMemory);
        public int RemainingLuridMemory() => FilterLow(30 - GetLuridMemory);
        public int RemainingRawEmotion() => FilterLow(RemainingJobs * 15 - GetRawEmotion);

        public bool DisplayRequirements() => RemainingCompactAxle() + RemainingCompactSpring() + RemainingBattlesRealm() + RemainingBattlesRift() + RemainingBleakMemory() + RemainingLuridMemory() != 0;
        public async Task ResetRequirements()
        {
            ThisStage.CompactAxle = 0;
            ThisStage.CompactSpring = 0;
            ThisStage.BattlesRealm = 0;
            ThisStage.BattlesRift = 0;
            ThisStage.BleakMemory = 0;
            ThisStage.LuridMemory = 0;

            await OnCharacterUpdate();
        }
    }
}
