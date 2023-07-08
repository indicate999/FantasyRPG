
public class WalkingState : MobState
{
    private IWalkable _walkBehavior;

    public WalkingState(IWalkable walkBehavior)
    {
        _walkBehavior = walkBehavior;
    }

    public override void Enter()
    {
        _walkBehavior.StartWalk();
    }

    public override void Update()
    {
        _walkBehavior.Walk();
    }
}
