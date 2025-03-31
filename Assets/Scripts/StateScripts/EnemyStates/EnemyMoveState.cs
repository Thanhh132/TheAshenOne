using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected bool isEnemyInChasingArea;
    protected bool enemyCheck;
    protected bool ledgeCheck;
    protected bool wallCheck;

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
        enemy.Anim.Play(AnimStrings.goblinMove);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemy.Core.Movement.SetVelocityX(enemyData.movementVelocity * enemy.Core.Movement.FacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}

