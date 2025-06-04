using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class Player : MonoBehaviour, IStunable
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerStunedState StunedState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState AirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerClimbState ClimbState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerRollState RollState { get; private set; }
    public PlayerPrayingState PrayingState { get; private set; }

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

    public Vector2 workspace;
    public Vector3 LastCheckpointPosition { get; private set; }

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
        StunedState = new PlayerStunedState(this, StateMachine, playerData, AnimStrings.playerStuned);
        JumpState = new PlayerJumpState(this, StateMachine, playerData, AnimStrings.playerJump);
        AirState = new PlayerInAirState(this, StateMachine, playerData, AnimStrings.playerInAir);
        LandState = new PlayerLandState(this, StateMachine, playerData, AnimStrings.playerLand);
        ClimbState = new PlayerClimbState(this, StateMachine, playerData, AnimStrings.playerClimb);
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, AnimStrings.playerWallSlide);
        RollState = new PlayerRollState(this, StateMachine, playerData, AnimStrings.playerRoll);
        PrayingState = new PlayerPrayingState(this, StateMachine, playerData, AnimStrings.playerPraying);
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

    public void ApplyStun()
    {
        StateMachine.ChangeState(StunedState);
    }

    public void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    public void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        LastCheckpointPosition = checkpointPosition;
    }
}
