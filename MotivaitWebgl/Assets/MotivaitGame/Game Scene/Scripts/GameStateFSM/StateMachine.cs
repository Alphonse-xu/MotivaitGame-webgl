using System.Collections.Generic;

/// <summary>
/// FSM
/// </summary>

public class StateMachine
{
    private readonly Dictionary<EnumState, GameState> m_stateMap;
    private GameState m_currentState;

    public EnumState CurrentState 
    {
        get
        {
            foreach (KeyValuePair<EnumState, GameState> kvp in m_stateMap)
            {
                if (kvp.Value.Equals(m_currentState))
                {
                    return kvp.Key;
                }
            }
            throw new System.NotImplementedException();
        }
    }
    public StateMachine()
    {
        m_currentState = null;
        m_stateMap = new Dictionary<EnumState, GameState>();

        RegisterState<IdleState>(EnumState.Idle);
        RegisterState<StartGameState>(EnumState.StartGame);
        RegisterState<PassGameState>(EnumState.PassGame);
        RegisterState<FailGameState>(EnumState.FailGame);
        RegisterState<PauseGameState>(EnumState.PauseGame);
    }

    public void RegisterState<T>(EnumState stateId) where T : GameState, new()
    {
        if (m_stateMap == null) return;
        T gameState = new T
        {
            StateID = stateId
        };
        m_stateMap.Add(stateId, gameState);
    }

    public bool SetCurrentState(EnumState stateId,object param = null)
    {
        if (m_currentState != null && m_currentState.StateID == stateId) return false;

        GameState nextState = null;

        if (!m_stateMap.TryGetValue(stateId,out nextState)) return false;

        if (m_currentState != null) m_currentState.LeaveState();

        m_currentState = nextState;
        m_currentState.EnterState();
        return true;
    }

    public void Update()
    {
        if (m_currentState != null)
        {
            m_currentState.OnUpdate();
        }
    }
}
