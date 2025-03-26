using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float idleTime = 0f;
    private bool enemyCheck;

    private bool isEnemyInAttackArea;

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
        enemy.Anim.Play(AnimStrings.enemyIdle);
        enemy.Core.Movement.SetVelocityX(0f);
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
        

        if (enemyCheck)
        {
            eStateMachine.ChangeState(enemy.DetectedState);
        }
        else if (idleTime >= enemyData.idleDuration)
        {
            enemy.Core.Movement.Flip();
            eStateMachine.ChangeState(enemy.MoveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
