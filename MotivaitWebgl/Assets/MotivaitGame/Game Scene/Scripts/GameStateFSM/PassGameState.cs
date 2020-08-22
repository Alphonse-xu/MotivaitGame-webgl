using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// player pass the game
/// </summary>

public class PassGameState : GameState
{
    public override void EnterState()
    {
        string s = "You win!\nDo you want to try again?";
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
    