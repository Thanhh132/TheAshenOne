using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private bool isEnemyInChasingArea;
    private bool isEnemyInAttackArea;
    private float attackCooldown = 2f;
    private float attackTimer;

    public EnemyAttackState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName) : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isEnemyInChasingArea = enemy.Core.DetectingSenses.IsEnemyInChasingArea;
        isEnemyInAttackArea = enemy.Core.DetectingSenses.IsEnemyInAttackArea;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.Core.Movement.SetVelocityX(0);
        enemy.Anim.Play(AnimStrings.enemyAttack);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (isEnemyInChasingArea)
            {
                eStateMachine.ChangeState(enemy.ChasingState);
            }
            else
            {
                eStateMachine.ChangeState(enemy.MoveState);
            }
        }

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
