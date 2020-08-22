using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player start to play game state
/// </summary>

public class StartGameState : GameState
{
    

    public override void EnterState()
    {

    }

    public override void LeaveState()
    {

    }

    public override void OnUpdate()
    {
        TimerUtil.Update();
        EventCenter.Broadcast<int>(EventType.coutdown, TimerUtil.Timer);
    }
}
