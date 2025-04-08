using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Movement Movement { get => movement ??= enemy.Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= enemy.Core.GetCoreComponent<CollisionSenses>();}
    private CollisionSenses collisionSenses;

    private DetectingSenses DetectingSenses { get => detectingSenses ??= enemy.Core.GetCoreComponent<DetectingSenses>();}
    private DetectingSenses detectingSenses;
    
    protected bool isEnemyInChasingArea;
    protected bool isEnemyInAttackArea;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName) : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        if (DetectingSenses)
        {
            isEnemyInChasingArea = DetectingSenses.IsEnemyInChasingArea;
            isEnemyInAttackArea = DetectingSenses.IsEnemyInAttackArea;
        }
    }

    public override void Enter()
    {
        base.Enter();
        Movement?.SetVelocityX(0);
        enemy.Anim.Play(AnimStrings.goblinAttack);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}
