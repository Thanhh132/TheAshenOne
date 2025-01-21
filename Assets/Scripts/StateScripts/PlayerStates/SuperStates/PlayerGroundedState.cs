using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected float moveInput;
    protected bool jumpInput;
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

        moveInput = player.InputHandle.MovementInput;
        jumpInput = player.InputHandle.JumpInput;

        if(jumpInput == true){
            player.InputHandle.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }else if(!isGrounded){
            stateMachine.ChangeState(player.AirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
