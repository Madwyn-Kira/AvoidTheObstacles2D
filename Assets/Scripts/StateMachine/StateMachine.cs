public abstract class StateMachine
{
    public abstract void EnterState<T>(T controller);

    public abstract void LocalUpdate();

    public abstract void ExitState();
}
