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

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isGrounded = player.Core.CollisionSenses.IfGrounded;
    }

    public override void Enter()
    {
        base.Enter();
        player.Anim.Play(AnimStrings.playerInAir);
        isAbilityDone = false;
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
        }
        else
        {
            if (xInput != 0 && !player.Core.CollisionSenses.IfTouchingWall)
            {
                core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
            }
            else if (player.Core.CollisionSenses.IfTouchingWall && xInput != 0)
            {
                float wallPushForce = 1f; 
                core.Movement.SetVelocityX(wallPushForce * core.Movement.FacingDirection);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
