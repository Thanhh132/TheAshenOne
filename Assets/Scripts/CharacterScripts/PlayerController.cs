using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState {get; private set;}
    public PlayerInAirState AirState {get; private set;}
    public PlayerLandState LandState {get; private set;}
    public PlayerClimbState ClimbState {get; private set;}
    public PlayerGrabState GrabState {get; private set;}
    public PlayerWallSlideState WallSlideState {get; private set;}

    [SerializeField]
    private PlayerData playerData;
    #endregion
   
    #region Components
    public Animator Anim { get; private set; }
    public PlayerInputHandle InputHandle { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion
    
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }


    [SerializeField]
    private Transform groundCheck; 
    [SerializeField]
    private Transform climbableCheck;
    public Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        Anim = GetComponent<Animator>();
        InputHandle = GetComponent<PlayerInputHandle>();
        RB = GetComponent<Rigidbody2D>();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, AnimStrings.playerIdle);
        MoveState = new PlayerMoveState(this, StateMachine, playerData, AnimStrings.playerWalk);
        JumpState = new PlayerJumpState(this, StateMachine, playerData, AnimStrings.playerJump);
        AirState = new PlayerInAirState(this, StateMachine, playerData, AnimStrings.playerInAir);
        LandState = new PlayerLandState(this, StateMachine, playerData, AnimStrings.playerLand);
        ClimbState = new PlayerClimbState(this, StateMachine, playerData, AnimStrings.playerClimb);
        GrabState = new PlayerGrabState(this, StateMachine, playerData, AnimStrings.playerGrab);
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, AnimStrings.playerWallSlide);
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
        FacingDirection = 1;
    }


    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
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

    public void FlipCheck(float input)
    {
        if (input != 0 && input != FacingDirection)
        {
            Flip();
        }
    }

    public bool IfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.isGrounded);
    }

    public bool IfClimbable()
    {
        return Physics2D.OverlapCircle(climbableCheck.position, playerData.climbableCheckDistance, playerData.isClimbable);
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();


}
