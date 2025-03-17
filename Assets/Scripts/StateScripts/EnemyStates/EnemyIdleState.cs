using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float idleTime = 0f;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(enemy, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.Anim.Play(AnimStrings.enemyIdle);
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

        if (idleTime >= enemyData.idleDuration)
        {
            enemy.Flip(); 
            eStateMachine.ChangeState(enemy.MoveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
