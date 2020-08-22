/// <summary>
/// FSM abstract class
/// </summary>

public enum EnumState
{
    Idle,
    StartGame,
    PauseGame,
    FailGame,
    PassGame,
}


public abstract class GameState
{
    public EnumState StateID { get; set; }

    public abstract void EnterState();
    public abstract void LeaveState();
    public abstract void OnUpdate();
}
