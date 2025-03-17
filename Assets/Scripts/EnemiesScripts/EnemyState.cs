using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine eStateMachine;
    protected EnemyData enemyData;

    protected float startTime;
    protected bool isAnimationFinished;
    protected bool isAbilityDone;
    private string animBoolName;

    public EnemyState(Enemy enemy, EnemyStateMachine eStateMachine, EnemyData enemyData, string animBoolName)
    {
        this.enemy = enemy;
        this.eStateMachine = eStateMachine;
        this.enemyData = enemyData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoCheck();
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
    }

        // dc gọi khi rời khỏi state
    public virtual void Exit()
    {
        isAnimationFinished = true;
    }

    //Gọi theo mỗi frameframe
    public virtual void LogicUpdate()
    {

    }

    //đc gọi theo fixeupdate 
    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }


    public virtual void DoCheck()
    {

    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
