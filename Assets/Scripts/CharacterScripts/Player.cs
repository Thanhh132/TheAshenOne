using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState AirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerClimbState ClimbState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerSlideState SlideState { get; private set; }
    public PlayerRollState RollState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandle InputHandle { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    public Vector2 CurrentVelocity { get; private set; }
    // public int FacingDirection { get; private set; }


    // [SerializeField]
    // private Transform groundCheck;

    // [SerializeField]
    // private Transform wallCheck;
    public Vector2 workspace;

    private void Awake()
    {
        
        Core = GetComponentInChildren<Core>();
        StateMachine = new PlayerStateMachine();
        Anim = GetComponent<Animator>();
        InputHandle = GetComponent<PlayerInputHandle>();
        RB = GetComponent<Rigidbody2D>();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, AnimStrings.playerIdle);
        MoveState = new PlayerMoveState(this, StateMachine, playerData, AnimStrings.playerWalk);
        AttackState = new PlayerAttackState(this, StateMachine, playerData, AnimStrings.playerAttack);
        JumpState = new PlayerJumpState(this, StateMachine, playerData, AnimStrings.playerJump);
        AirState = new PlayerInAirState(this, StateMachine, playerData, AnimStrings.playerInAir);
        LandState = new PlayerLandState(this, StateMachine, playerData, AnimStrings.playerLand);
        ClimbState = new PlayerClimbState(this, StateMachine, playerData, AnimStrings.playerClimb);
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, AnimStrings.playerWallSlide);
        SlideState = new PlayerSlideState(this, StateMachine, playerData, AnimStrings.playerSlide);
        RollState = new PlayerRollState(this, StateMachine, playerData, AnimStrings.playerRoll);

    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
        // FacingDirection = 1;
    }


    private void Update()
    {
        CurrentVelocity = RB.velocity;
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    // public void SetVelocityX(float velocity)
    // {
    //     workspace.Set(velocity, CurrentVelocity.y);
    //     RB.velocity = workspace;
    //     CurrentVelocity = workspace;
    // }

    // public void SetVelocityY(float velocity)
    // {
    //     workspace.Set(CurrentVelocity.x, velocity);
    //     RB.velocity = workspace;
    //     CurrentVelocity = workspace;
    // }

    // public void FlipCheck(float input)
    // {
    //     if (input != 0 && input != FacingDirection)
    //     {
    //         Flip();
    //     }
    // }
    
    // private void Flip()
    // {
    //     FacingDirection *= -1;
    //     transform.Rotate(0, 180, 0);
    // }
    

    // public bool IfGrounded()
    // {
    //     bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.isGrounded);
    //     Debug.Log("Is Touching Ground");
    //     return isGrounded;
    // }


    // public bool IfTouchingWall()
    // {
    //     bool isTouchingWall = Physics2D.Raycast(wallCheck.position, Vector2.right * Core.Movement.FacingDirection, playerData.wallCheckDistance, playerData.isTouchingWall);
    //     Debug.Log("Is Touching Wall");
    //     return isTouchingWall;
    // }

    public void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

}
