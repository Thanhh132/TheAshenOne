using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerGroundedState
{
    public PlayerRollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        Movement?.SetVelocityX(playerData.rollVelocity * Movement.FacingDirection);
        player.Anim.Play(AnimStrings.playerRoll);
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished){
            isAbilityDone = true;
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTrigger() {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger() {
        base.AnimationFinishTrigger();
    }
}
