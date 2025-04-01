using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;
    private CollisionSenses CollisionSenses
    {
        get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }
    private CollisionSenses collisionSenses;
    private float xInput;
    private bool jumpInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isClimbable;
    private bool grabInput;

    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        if (CollisionSenses)
        {
            isGrounded = CollisionSenses.IfGrounded;
            isTouchingWall = collisionSenses.IfTouchingWall;
        }

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
            if (xInput != 0 && !CollisionSenses.IfTouchingWall)
            {
                Movement?.SetVelocityX(playerData.movementVelocity * xInput);
            }
            else if (isTouchingWall && xInput != 0)
            {
                float wallPushForce = 1f;
                Movement?.SetVelocityX(wallPushForce * Movement.FacingDirection);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
