using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine E_StateMachine;
    public Vector2 CurrentVelocity { get; private set; }
    public EnemyData enemyData;

    public Core Core { get; private set; }
    public Animator Anim { get; private set; }

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();
        Anim = GetComponent<Animator>();
        E_StateMachine = new EnemyStateMachine();
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        E_StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        E_StateMachine.CurrentState.PhysicsUpdate();
    }


    public void AnimationTrigger() => E_StateMachine.CurrentState.AnimationTrigger();

    public void AnimationFinishTrigger() => E_StateMachine.CurrentState.AnimationFinishTrigger();

}
