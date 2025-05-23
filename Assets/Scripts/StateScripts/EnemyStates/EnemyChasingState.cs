using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyChasingState : EnemyState
{
    protected Movement Movement { get => movement ??= enemy.Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= enemy.Core.GetCoreComponent<CollisionSenses>();}
    private CollisionSenses collisionSenses;

    private DetectingSenses DetectingSenses { get => detectingSenses ??= enemy.Core.GetCoreComponent<DetectingSenses>();}
    private DetectingSenses detectingSenses;

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
        if (CollisionSenses)
        {
            wallCheck = CollisionSenses.IfTouchingWall;
            ledgeCheck = CollisionSenses.IfTouchingLedge;
        }

        if (DetectingSenses)
        {
            isEnemyInAttackArea =DetectingSenses.IsEnemyInAttackArea;
            isEnemyInChasingArea = DetectingSenses.IsEnemyInChasingArea;
        }
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
        Transform target = DetectingSenses.GetEnemyTarget();
        attackTimer -= Time.deltaTime;
        giveUpTimer -= Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
