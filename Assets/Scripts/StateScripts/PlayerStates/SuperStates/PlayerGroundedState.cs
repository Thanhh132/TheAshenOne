using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected float xInput;
    protected bool jumpInput;
    protected bool attackInput;
    private bool isGrounded;

    public PlayerGroundedState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.IfGrounded();
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
        attackInput = player.InputHandle.AttackInput;

        if (jumpInput == true && isGrounded)
        {
            player.InputHandle.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            stateMachine.ChangeState(player.AirState);
        }
        else if (attackInput && isGrounded)
        {
            stateMachine.ChangeState(player.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
