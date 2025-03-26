using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IStunable
{
    #region State Variables
    public EnemyStateMachine E_StateMachine { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }
    public EnemyDetectedState DetectedState { get; private set; }
    public EnemyChasingState ChasingState { get; private set; }
    public EnemyAttackState EAttackState { get; private set; }
    public EnemyStunedState StunedState { get; private set; }

    [SerializeField] private EnemyData enemyData;
    #endregion


    #region Components
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D Col { get; private set; }
    #endregion

    public void Awake()
    {
        Core = GetComponentInChildren<Core>();
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        E_StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, E_StateMachine, enemyData, AnimStrings.enemyIdle);
        MoveState = new EnemyMoveState(this, E_StateMachine, enemyData, AnimStrings.enemyMove);
        DetectedState = new EnemyDetectedState(this, E_StateMachine, enemyData, "Detected");
        ChasingState = new EnemyChasingState(this, E_StateMachine, enemyData, AnimStrings.enemyChasing);
        EAttackState = new EnemyAttackState(this, E_StateMachine, enemyData, AnimStrings.enemyAttack);
        StunedState = new EnemyStunedState(this, E_StateMachine, enemyData, AnimStrings.enemyStuned);
    }

    private void Start()
    {
        E_StateMachine.Initialize(MoveState);
    }


    private void Update()
    {
        CurrentVelocity = RB.velocity;
        Core.LogicUpdate();
        E_StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        E_StateMachine.CurrentState.PhysicsUpdate();
    }

    public void ApplyStun()
    {
        E_StateMachine.ForceChangeState(StunedState);
    }


    public void AnimationTrigger() => E_StateMachine.CurrentState.AnimationTrigger();

    public void AnimationFinishTrigger() => E_StateMachine.CurrentState.AnimationFinishTrigger();

}
