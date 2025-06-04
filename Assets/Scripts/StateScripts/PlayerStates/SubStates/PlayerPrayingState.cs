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

        // Lưu vị trí checkpoint khi bắt đầu cầu nguyện
        if (player.InputHandle.CurrentCheckpoint != null)
        {
            player.SetCheckpoint(player.InputHandle.CurrentCheckpoint.position);
            Debug.Log("Checkpoint saved at: " + player.InputHandle.CurrentCheckpoint.position);
        }
        else
        {
            Debug.Log("No checkpoint to save!");
        }

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
