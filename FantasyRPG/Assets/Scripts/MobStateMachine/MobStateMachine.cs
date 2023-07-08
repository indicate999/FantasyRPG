public class MobStateMachine
{
    private MobState _currentState;
    public MobState CurrentState { get { return _currentState; } }

    public void Initialize(MobState startState)
    {
        _currentState = startState;
        _currentState.Enter();
    }

    public void ChangeState(MobState newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
