using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoveState : StateMachine
{
    private EntityBase _controller;

    public float moveSpeed = 0f;
    private Vector2 movement;

    public float leftTurnAngle = 0f;
    public float rightTurnAngle = 180f;

    public override void EnterState<T>(T controler)
    {
        _controller = controler as EntityBase;
        _controller.EntityAnimator?.SetInteger("State", 1);

        moveSpeed = _controller.EntitySettings.Speed;
    }

    public override void ExitState()
    {

    }

    public override void LocalUpdate()
    {
        HandleInput();
        Move();

        if(movement == Vector2.zero)
        {
            _controller.ChangeState(new PlayerIdleState());
        }
    }

    private void HandleInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        //movement.y = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        _controller.EntityRigidbody.velocity = movement.normalized * moveSpeed;
        Turn();
    }

    private void Turn()
    {
        if (movement.x > 0)
        {
            _controller.transform.rotation = Quaternion.Euler(0, leftTurnAngle, 0);
        }
        else if (movement.x < 0)
        {
            _controller.transform.rotation = Quaternion.Euler(0, rightTurnAngle, 0);
        }

    }
}
