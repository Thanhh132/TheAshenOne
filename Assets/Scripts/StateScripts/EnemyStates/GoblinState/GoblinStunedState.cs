using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinStunedState : EnemyStunedState
{
    Goblin goblin;
    public GoblinStunedState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName,Goblin goblin) : base(enemy, stateMachine, enemyData, animBoolName)
    {
        this.goblin = goblin;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }
    public override void Enter()
    {
        base.Enter();
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
                eStateMachine.ChangeState(goblin.ChasingState);
            }
            else
            {
                eStateMachine.ChangeState(goblin.IdleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
