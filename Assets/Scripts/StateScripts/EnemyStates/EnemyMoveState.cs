using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private bool ledgeCheck;
    private bool wallCheck;

    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        ledgeCheck = enemy.LedgeCheck();
        wallCheck = enemy.WallCheck();
    }
    public override void Enter()
    {
        base.Enter();
        enemy.Anim.Play(AnimStrings.enemyMove);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemy.SetVelocityX(enemyData.movementVelocity * enemy.FacingDirection);

        if(wallCheck || ledgeCheck){
            eStateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}

