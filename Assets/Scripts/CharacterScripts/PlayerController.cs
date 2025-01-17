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



    public Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        Anim = GetComponent<Animator>();
        InputHandle = GetComponent<PlayerInputHandle>();
        RB = GetComponent<Rigidbody2D>();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, AnimStrings.playerIdle);
        MoveState = new PlayerMoveState(this, StateMachine, playerData, AnimStrings.playerWalk);
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

    public void FlipCheck(float input)
    {
        if (input != 0 && input != FacingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }
}
