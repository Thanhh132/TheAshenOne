using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0);
        player.Anim.Play(AnimStrings.playerLand);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(xInput != 0){
            stateMachine.ChangeState(player.MoveState);
        }else if(isAnimationFinished){
            stateMachine.ChangeState(player.IdleState);        
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
