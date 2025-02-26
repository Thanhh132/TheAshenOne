using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private bool slideInput;
    private bool rollInput;
    private bool isTouchingWall;
    private bool isClimbable;

    public PlayerMoveState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.IfGrounded();
        isTouchingWall = player.IfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
        player.Anim.Play(AnimStrings.playerWalk);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.FlipCheck(xInput);

        slideInput = player.InputHandle.SlideInput;
        rollInput = player.InputHandle.RollInput;

        player.SetVelocityX(playerData.movementVelocity * xInput);
        if (xInput == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (xInput != 0 && slideInput && !isTouchingWall)
        {
            stateMachine.ChangeState(player.SlideState);
        }else if (xInput != 0 && rollInput)
        {
            stateMachine.ChangeState(player.RollState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
