using UnityEngine;

public class WalkingState : MobBaseState
{
    private IWalkable _walkBehavior;
    private Transform _playerTransform;
    private Transform _mobTransform;
    private float _startMoveToTargetDistance;

    public WalkingState(IWalkable walkBehavior, IMobStateSwitcher stateSwitcher, Transform playerTransform, Transform mobTransform, float startMoveToTargetDistance) : base(stateSwitcher)
    {
        _walkBehavior = walkBehavior;
        _playerTransform = playerTransform;
        _mobTransform = mobTransform;
        _startMoveToTargetDistance = startMoveToTargetDistance;
    }

    public override void Enter()
    {
        _walkBehavior.StartWalk();
    }

    public override void Update()
    {
        _walkBehavior.Walk();

        var distance = Vector3.Distance(_playerTransform.position, _mobTransform.position);

        if (distance < _startMoveToTargetDistance)
            _stateSwitcher.SwitchState<MovingState>();
    }
}
