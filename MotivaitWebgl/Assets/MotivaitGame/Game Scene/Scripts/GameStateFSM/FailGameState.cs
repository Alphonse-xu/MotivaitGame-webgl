using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// player fail game state
/// </summary>
public class FailGameState : GameState
{
    public override void EnterState()
    {
        string s = "Time is out, you fail it.";
        EventCenter.Broadcast<string>(EventType.gameover, s);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public override void LeaveState()
    {
        
    }

    public override void OnUpdate()
    {
        
    }
}
