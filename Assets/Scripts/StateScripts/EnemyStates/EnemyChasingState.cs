using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyChasingState : EnemyState
{
    protected bool isEnemyInAttackArea;
    protected bool isEnemyInChasingArea;

    protected bool wallCheck;
    protected bool ledgeCheck;

    protected float attackTimer;
    protected float giveUpTimer;

    protected float giveUpDuration = 3f;

    public EnemyChasingState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName)
        : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        wallCheck = enemy.Core.CollisionSenses.IfTouchingWall;
        ledgeCheck = enemy.Core.CollisionSenses.IfTouchingLedge;

        isEnemyInAttackArea = enemy.Core.DetectingSenses.IsEnemyInAttackArea;
        isEnemyInChasingArea = enemy.Core.DetectingSenses.IsEnemyInChasingArea;
    }

    public override void Enter()
    {
        base.Enter();
        attackTimer = enemyData.attackCooldown;
        giveUpTimer = giveUpDuration;
        enemy.Anim.Play(AnimStrings.goblinMove);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Transform target = enemy.Core.DetectingSenses.GetEnemyTarget();
        attackTimer -= Time.deltaTime;
        giveUpTimer -= Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
