using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : EnemyIdleState
{
    private Goblin goblin;

    public GoblinIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName,Goblin goblin) : base(enemy, stateMachine, enemyData, animBoolName)
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
        if (enemyCheck)
        {
            eStateMachine.ChangeState(goblin.MoveState);
        }
        else if (idleTime >= goblin.enemyData.idleDuration)
        {
            eStateMachine.ChangeState(goblin.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
