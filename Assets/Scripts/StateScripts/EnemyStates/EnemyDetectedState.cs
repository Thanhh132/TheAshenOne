using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyDetectedState : EnemyState
{
    private bool isEnemyInChasingArea;
    private bool isEnemyInAttackArea;
    private bool wallCheck;
    private bool ledgeCheck;
    private float charge = 0.5f;
    private float chargeTimer;

    public EnemyDetectedState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName)
        : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        isEnemyInChasingArea = enemy.Core.DetectingSenses.IsEnemyInChasingArea;
        isEnemyInAttackArea = enemy.Core.DetectingSenses.IsEnemyInAttackArea;
        wallCheck = enemy.Core.CollisionSenses.WallCheck;
        ledgeCheck = enemy.Core.CollisionSenses.LedgeCheck;
    }

    public override void Enter()
    {
        base.Enter();
        
        chargeTimer = 0f;
        enemy.Core.Movement.SetVelocityX(0f);
        enemy.Anim.Play(AnimStrings.enemyIdle);
    }

    public override void Exit()
    {
        base.Exit();
        chargeTimer = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isEnemyInChasingArea)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= charge)
            {
                eStateMachine.ChangeState(enemy.ChasingState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
