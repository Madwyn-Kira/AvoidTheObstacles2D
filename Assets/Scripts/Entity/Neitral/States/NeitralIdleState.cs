public class NeitralIdleState : StateMachine
{
    private EntityBase _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityBase;
        //_controller.EntityAnimator?.SetInteger("State", 0);
    }

    public override void ExitState()
    {

    }

    public override void LocalUpdate()
    {

    }
}
