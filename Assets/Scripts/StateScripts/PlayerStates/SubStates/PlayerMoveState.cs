using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private bool slideInput;
    private bool rollInput;
    private bool isTouchingWall;
    private bool isClimbable;

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.Core.CollisionSenses.IfGrounded;
        isTouchingWall = player.Core.CollisionSenses.IfTouchingWall;
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
        core.Movement.FlipCheck(xInput);
        slideInput = player.InputHandle.SlideInput;
        rollInput = player.InputHandle.RollInput;

        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
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
