using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInAirState : StateMachine
{
    private PlayerController _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as PlayerController;
    }

    public override void ExitState()
    {

    }

    public override void LocalUpdate()
    {
        if (_controller.IsGrounded())
            _controller.ChangeState(new PlayerIdleState());
    }
}
