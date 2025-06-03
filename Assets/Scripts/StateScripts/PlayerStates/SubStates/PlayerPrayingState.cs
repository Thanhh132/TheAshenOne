using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrayingState : PlayerGroundedState
{   
    public PlayerPrayingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    
    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();

        player.Anim.Play(AnimStrings.playerPraying);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(0f);
        Movement?.SetVelocityY(0f);
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
