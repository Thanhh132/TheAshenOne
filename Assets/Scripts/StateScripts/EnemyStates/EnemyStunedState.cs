using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunedState : EnemyState
{
    protected Movement Movement { get => movement ??= enemy.Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= enemy.Core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private DetectingSenses DetectingSenses { get => detectingSenses ??= enemy.Core.GetCoreComponent<DetectingSenses>(); }
    private DetectingSenses detectingSenses;

    protected bool isEnemyInChasingArea;
    
    public EnemyStunedState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName) : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        if (DetectingSenses)
        {
            isEnemyInChasingArea = DetectingSenses.IsEnemyInChasingArea;
        }

    }

    public override void Enter()
    {
        base.Enter();
        enemy.Anim.Play(AnimStrings.goblinStuned);
        Movement?.SetVelocityX(0);
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

}
