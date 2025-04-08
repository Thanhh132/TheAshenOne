using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    private Movement movement;
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }

    private CollisionSenses collisionSenses;
    private CollisionSenses CollisionSenses { get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>(); }


    protected float xInput;
    protected bool jumpInput;
    protected bool attackInput;
    protected bool isGrounded;


    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoCheck()
    {
        base.DoCheck();
        if (CollisionSenses)
        {
            isGrounded = CollisionSenses.IfGrounded;
        }
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandle.XInput;
        jumpInput = player.InputHandle.JumpInput;
        attackInput = player.InputHandle.AttackInput;

        if (jumpInput == true && isGrounded && isAbilityDone)
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            stateMachine.ChangeState(player.AirState);
        }
        else if (attackInput && isAbilityDone)
        {
            stateMachine.ChangeState(player.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}
