using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerTouchingWallState
{
    public PlayerClimbState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
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
        player.SetVelocityY(playerData.climbVelocity);

        if(yInput != 1){
            stateMachine.ChangeState(player.GrabState);
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

    public override void AnimationTrigger() => base.AnimationTrigger();

    public override void AnimationFinishTrigger() => base.AnimationFinishTrigger();
}
