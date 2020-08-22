using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// control the state of game flow
/// instance the FSM
/// </summary>

public class GameManager : MonoBehaviour
{
    StateMachine stateMachine;

    const float gameTime = 100f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock Cursor

        stateMachine = new StateMachine();
        stateMachine.SetCurrentState(EnumState.Idle);

        TimerUtil.SetTimerUtil(gameTime);

        EventCenter.AddListener(EventType.passgame, PassGame);
    }


    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();

        if (TimerUtil.Timer <= 0)
        {
            stateMachine.SetCurrentState(EnumState.FailGame);
        }

        if (Input.GetKeyDown(KeyCode.Space) && stateMachine.CurrentState != EnumState.Idle)
        {
            if (stateMachine.CurrentState != EnumState.PauseGame)
            {
                stateMachine.SetCurrentState(EnumState.PauseGame);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                stateMachine.SetCurrentState(EnumState.StartGame);
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }

    public void StartGame()
    {
        stateMachine.SetCurrentState(EnumState.StartGame);
        EventCenter.Broadcast(EventType.startgame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueGame()
    {
        stateMachine.SetCurrentState(EnumState.StartGame);
    }

    private void PassGame()
    {
        stateMachine.SetCurrentState(EnumState.PassGame);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventType.passgame, PassGame);
    }
}
