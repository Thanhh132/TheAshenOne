using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDetectedState : EnemyDetectedState
{
    Goblin goblin;
    public GoblinDetectedState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName,Goblin goblin) : base(enemy, stateMachine, enemyData, animBoolName)
    {
        this.goblin = goblin;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isEnemyInChasingArea)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= charge)
            {
                eStateMachine.ChangeState(goblin.ChasingState);
            }
        }
    }
}
