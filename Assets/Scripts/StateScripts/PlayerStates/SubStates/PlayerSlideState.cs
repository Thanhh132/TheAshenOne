using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlideState : PlayerAbilityState
{
    private bool dashInput;
    private float xInput;
    protected bool isTouchingWall;
    public PlayerSlideState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
        isTouchingWall = player.IfTouchingWall();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(playerData.slideVelocity * player.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandle.XInput;

        dashInput = player.InputHandle.SlideInput;
        if(isAnimationFinished || isTouchingWall){
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
