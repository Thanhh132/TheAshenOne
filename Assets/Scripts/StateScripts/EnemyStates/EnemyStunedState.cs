using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStunedState : EnemyState
{
    private bool isEnemyInChasingArea;
    public EnemyStunedState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName) : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isEnemyInChasingArea = enemy.Core.DetectingSenses.IsEnemyInChasingArea;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.Anim.Play(AnimStrings.enemyStuned);
        enemy.Core.Movement.SetVelocityX(0);
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
                eStateMachine.ChangeState(enemy.IdleState);
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
    
}
