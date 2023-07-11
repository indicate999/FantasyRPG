
public abstract class MobBaseState
{
    protected readonly IMobStateSwitcher _stateSwitcher;

    protected MobBaseState(IMobStateSwitcher stateSwitcher)
    {
        _stateSwitcher = stateSwitcher;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }
}
