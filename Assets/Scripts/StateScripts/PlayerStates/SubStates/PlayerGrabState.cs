using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;

    public PlayerGrabState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        holdPosition = player.transform.position;
        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        HoldPosition();
        if (yInput == 1 && grabInput)
        {
            stateMachine.ChangeState(player.ClimbState);
        }else if(yInput < 0 || !grabInput)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;
        player.SetVelocityX(0f);
        player.SetVelocityY(0f);
    }

    public override void AnimationTrigger() => base.AnimationTrigger();

    public override void AnimationFinishTrigger() => base.AnimationFinishTrigger();
}
