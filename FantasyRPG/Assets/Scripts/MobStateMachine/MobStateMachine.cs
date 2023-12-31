using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobStateMachine : IMobStateSwitcher
{
    private List<MobBaseState> _allStates;
    private MobBaseState _currentState;
    public MobBaseState CurrentState { get { return _currentState; } }

    public MobStateMachine(IWalkable walkBehavior, IMoveable moveBehavior,IAttackable attackBehavior, Transform playerTransform, Transform mobTransform, float startMoveToTargetDistance, float attackDistance)
    {
        _allStates = new List<MobBaseState>()
        {
            new WalkingState(walkBehavior, this, playerTransform, mobTransform, startMoveToTargetDistance),
            new MovingState(moveBehavior, this, attackDistance),
            new AttackingState(attackBehavior, moveBehavior, this, attackDistance)
        };
        _currentState = _allStates[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : MobBaseState
    {
        var newState = _allStates.FirstOrDefault(s => s is T);
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
