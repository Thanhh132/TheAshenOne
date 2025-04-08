using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected Movement Movement { get => movement ??= enemy.Core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ??= enemy.Core.GetCoreComponent<CollisionSenses>(); }
    private CollisionSenses collisionSenses;

    private DetectingSenses DetectingSenses { get => detectingSenses ??= enemy.Core.GetCoreComponent<DetectingSenses>(); }
    private DetectingSenses detectingSenses;

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
        if (CollisionSenses)
        {
            ledgeCheck = CollisionSenses.IfTouchingLedge;
            wallCheck = CollisionSenses.IfTouchingWall;
        }

        if (DetectingSenses)
        {
            enemyCheck = DetectingSenses.IsEnemy;
        }
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
        Movement?.SetVelocityX(enemyData.movementVelocity * Movement.FacingDirection);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}

