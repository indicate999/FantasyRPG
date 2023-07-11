public interface IMobStateSwitcher
{
    public void SwitchState<T>() where T : MobBaseState;
}
