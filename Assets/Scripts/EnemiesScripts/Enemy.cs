using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region State Variables
    public EnemyStateMachine E_StateMachine { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }

    [SerializeField]
    private EnemyData enemyData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; } = 1;

    public Vector2 workspace;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;


    public void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        E_StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, E_StateMachine, enemyData, "idle");
        MoveState = new EnemyMoveState(this, E_StateMachine, enemyData, "move");

    }

    public void Start()
    {
        E_StateMachine.Initialize(MoveState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        E_StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        E_StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }


    public void Flip()
    {
        FacingDirection *= -1;
        Vector3 scale = RB.transform.localScale;
        scale.x *= -1;
        RB.transform.localScale = scale;
    }


    public void FlipCheck(float input)
    {
        if (input != 0 && input != FacingDirection)
        {
            Flip();
        }
    }

    public bool WallCheck()
    {
        return Physics2D.OverlapCircle(wallCheck.position, enemyData.wallCheckRadius, enemyData.isWall);
    }

    public bool LedgeCheck()
    {
        return !Physics2D.OverlapCircle(ledgeCheck.position, enemyData.ledgeCheckDistance, enemyData.isGround);
    }

    public void AnimationTrigger() => E_StateMachine.CurrentState.AnimationTrigger();

    public void AnimationFinishTrigger() => E_StateMachine.CurrentState.AnimationFinishTrigger();


}
