using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideState : PlayerGroundedState
{
    private bool slideInput;
    protected bool isTouchingWall;

    private CollisionSenses CollisionSenses
    {
        get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }
    private CollisionSenses collisionSenses;

    public PlayerSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
        isTouchingWall = CollisionSenses.IfTouchingWall;
    }

    public override void Enter()
    {
        base.Enter();
        Movement.SetVelocityX(playerData.slideVelocity * Movement.FacingDirection);
        player.Anim.Play(AnimStrings.playerSlide);
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
        slideInput = player.InputHandle.SlideInput;

        if (isAnimationFinished || isTouchingWall)
        {
            isAbilityDone = true;
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
