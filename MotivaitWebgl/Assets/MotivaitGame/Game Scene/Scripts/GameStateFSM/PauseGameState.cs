using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// player pause the game 
/// </summary>
public class PauseGameState : GameState
{
    public override void EnterState()
    {
        EventCenter.Broadcast(EventType.pausegame);
    }

    public override void LeaveState()
    {
        
    }

    public override void OnUpdate()
    {
       
    }
}
