using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChasingState : EnemyChasingState
{
    Goblin goblin;
    public GoblinChasingState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, Goblin goblin) : base(enemy, stateMachine, enemyData, animBoolName)
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
        Transform target = enemy.Core.DetectingSenses.GetEnemyTarget();
        attackTimer -= Time.deltaTime;
        giveUpTimer -= Time.deltaTime;

        if (isEnemyInAttackArea)
        {
            enemy.Core.Movement.SetVelocityX(0);
            enemy.Anim.Play(AnimStrings.goblinIdle);
            if (attackTimer <= 0)
            {
                eStateMachine.ChangeState(goblin.EAttackState);
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
                enemy.Anim.Play(AnimStrings.goblinMove);
                enemy.Core.Movement.SetVelocityX(enemyData.movementVelocity * direction);
            }
            else
            {

                eStateMachine.ChangeState(goblin.IdleState);
            }
        }
        else if (giveUpTimer <= 0)
        {
            eStateMachine.ChangeState(goblin.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
