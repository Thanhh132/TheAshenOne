using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private bool isEnemyInChasingArea;
    private bool enemyCheck;
    private bool ledgeCheck;
    private bool wallCheck;

    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        ledgeCheck = enemy.Core.CollisionSenses.IfTouchingLedge;
        wallCheck = enemy.Core.CollisionSenses.IfTouchingWall;
        enemyCheck = enemy.Core.DetectingSenses.IsEnemy;
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
        enemy.Core.Movement.SetVelocityX(enemyData.movementVelocity * enemy.Core.Movement.FacingDirection);

        if (enemyCheck)
        {
            eStateMachine.ChangeState(enemy.DetectedState);
        }
        else if (wallCheck || ledgeCheck)
        {
            eStateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}

