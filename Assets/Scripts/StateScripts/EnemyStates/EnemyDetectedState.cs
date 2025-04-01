using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyDetectedState : EnemyState
{
    protected Movement Movement { get => movement ??= enemy.Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses
    {
        get => collisionSenses ??= enemy.Core.GetCoreComponent<CollisionSenses>();
    }
    private CollisionSenses collisionSenses;

    private DetectingSenses DetectingSenses
    {
        get => detectingSenses ??= enemy.Core.GetCoreComponent<DetectingSenses>();
    }
    private DetectingSenses detectingSenses;
    protected bool isEnemyInChasingArea;
    protected bool isEnemyInAttackArea;

    protected bool wallCheck;
    protected bool ledgeCheck;

    protected float charge = 0.5f;
    protected float chargeTimer;

    public EnemyDetectedState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName)
        : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        if (CollisionSenses)
        {
            wallCheck = CollisionSenses.WallCheck;
            ledgeCheck = CollisionSenses.LedgeCheck;
        }

        if (DetectingSenses)
        {
            isEnemyInChasingArea = DetectingSenses.IsEnemyInChasingArea;
            isEnemyInAttackArea = DetectingSenses.IsEnemyInAttackArea;
        }
    }

    public override void Enter()
    {
        base.Enter();

        chargeTimer = 0f;
        Movement?.SetVelocityX(0f);
        enemy.Anim.Play(AnimStrings.goblinIdle);
    }

    public override void Exit()
    {
        base.Exit();
        chargeTimer = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
