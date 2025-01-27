using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected float moveInput;
    protected bool jumpInput;
    private bool grabInput;
    private bool isGrounded;
    private bool isClimbable;

    public PlayerGroundedState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        moveInput = player.InputHandle.XInput;
        jumpInput = player.InputHandle.JumpInput;
        grabInput = player.InputHandle.GrabInput;

        if(player.InputHandle.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }else if(player.InputHandle.AttackInputs[(int)CombatInputs.secondary]){
            stateMachine.ChangeState(player.SecondaryAttackState);
        }

        if (jumpInput == true && isGrounded)
        {
            player.InputHandle.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }else if (!isGrounded)
        {
            stateMachine.ChangeState(player.AirState);
        }else if (grabInput && isClimbable)
        {
            stateMachine.ChangeState(player.GrabState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
