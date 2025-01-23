using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private float xInput;
    private bool jumpInput;
    private bool isGrounded;
    private bool isClimbable;
    private bool grabInput;

    public PlayerInAirState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.IfGrounded();
        isClimbable = player.IfClimbable();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandle.XInput;
        jumpInput = player.InputHandle.JumpInput;
        grabInput = player.InputHandle.GrabInput;

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }else if (jumpInput)
        {
            player.FlipCheck(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);
            player.Anim.SetFloat("YVelocity", player.CurrentVelocity.y);
        }else if (isClimbable && grabInput)
        {
            stateMachine.ChangeState(player.GrabState);
        }else if (isClimbable && xInput == player.FacingDirection && player.CurrentVelocity.y <= 0.01f)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
