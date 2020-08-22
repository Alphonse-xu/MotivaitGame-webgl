using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Default state of the game play
/// teaching player the rule
/// </summary>

public class IdleState : GameState
{
    public override void EnterState()
    {
        Time.timeScale = 0;
        
    }

    public override void LeaveState()
    {
        Time.timeScale = 1;
        EventCenter.Broadcast<bool>(EventType.teachingrule, false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void OnUpdate()
    {
        
    }
}
