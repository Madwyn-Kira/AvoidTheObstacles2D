public class VerticalFallMoveState : StateMachine
{
    private EntityBase _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityBase;
    }

    public override void ExitState()
    {

    }

    public override void LocalUpdate()
    {

    }
}
