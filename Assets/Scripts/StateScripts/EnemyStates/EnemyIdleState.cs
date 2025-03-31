using System.Data.Common;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected float idleTime;
    protected bool enemyCheck;

    protected bool isEnemyInAttackArea;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        enemyCheck = enemy.Core.DetectingSenses.IsEnemy;

    }

    public override void Enter()
    {
        base.Enter();
        enemy.Core.Movement.SetVelocityX(0f);
        enemy.Anim.Play(AnimStrings.goblinIdle);
        idleTime = 0f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        idleTime += Time.deltaTime;
        if(idleTime >= enemyData.idleDuration)
        {
            enemy.Core.Movement.Flip();
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
