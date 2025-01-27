using UnityEngine;

public class PlayerIdleState : StateMachine
{
    private EntityBase _controller;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityBase;
        _controller.EntityAnimator?.SetInteger("State", 0);
    }

    public override void ExitState()
    {

    }

    Vector2 movement = Vector2.zero;

    public override void LocalUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            _controller.ChangeState(new PlayerMoveState());
        }
    }
}
