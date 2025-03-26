using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyChasingState : EnemyState
{
    private bool isEnemyInAttackArea;
    private bool isEnemyInChasingArea;

    private bool wallCheck;
    private bool ledgeCheck;
    private bool IsEnemy;
    private bool isGrounded;

    private float attackTimer;
    private float giveUpTimer;

    private float giveUpDuration = 3f;

    public EnemyChasingState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName)
        : base(enemy, eStateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        wallCheck = enemy.Core.CollisionSenses.IfTouchingWall;
        ledgeCheck = enemy.Core.CollisionSenses.IfTouchingLedge;

        isEnemyInAttackArea = enemy.Core.DetectingSenses.IsEnemyInAttackArea;
        isEnemyInChasingArea = enemy.Core.DetectingSenses.IsEnemyInChasingArea;
    }

    public override void Enter()
    {
        base.Enter();
        attackTimer = enemyData.attackCooldown;
        giveUpTimer = giveUpDuration;
        enemy.Anim.Play(AnimStrings.enemyMove);

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Transform target = enemy.Core.DetectingSenses.GetEnemyTarget();
        attackTimer -= Time.deltaTime;
        giveUpTimer -= Time.deltaTime;

        // Dừng lại nếu ở khu vực tấn công
        if (isEnemyInAttackArea)
        {
            enemy.Core.Movement.SetVelocityX(0);
            enemy.Anim.Play(AnimStrings.enemyIdle);
            if (attackTimer <= 0)
            {
                eStateMachine.ChangeState(enemy.EAttackState);
            }
            return;
        }

        if (target != null)
        {
            float direction = Mathf.Sign(target.position.x - enemy.transform.position.x);

            if (direction != enemy.Core.Movement.FacingDirection)
            {
                enemy.Core.Movement.Flip();
            }
            if (!wallCheck && !ledgeCheck)
            {
                enemy.Anim.Play(AnimStrings.enemyMove);
                enemy.Core.Movement.SetVelocityX(enemyData.movementVelocity * direction);
            }
            else
            {

                eStateMachine.ChangeState(enemy.IdleState); 
            }
        }
        else if (giveUpTimer <= 0)
        {
            eStateMachine.ChangeState(enemy.IdleState); 
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
