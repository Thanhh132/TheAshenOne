using System.Data.Common;
using UnityEngine;

public class EnemyIdleState : EnemyState
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
    protected float idleTime;
    protected bool enemyCheck;

    protected bool isEnemyInAttackArea;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        if (DetectingSenses)
        {
            enemyCheck = DetectingSenses.IsEnemy;
        }
    }

    public override void Enter()
    {
        base.Enter();
        Movement?.SetVelocityX(0f);
        enemy.Anim.Play(AnimStrings.goblinIdle);
        idleTime = 0f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        idleTime += Time.deltaTime;
        if (idleTime >= enemyData.idleDuration)
        {
            Movement?.Flip();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
