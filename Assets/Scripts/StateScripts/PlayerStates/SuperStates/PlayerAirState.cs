using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;

    private CollisionSenses CollisionSenses
    {
        get => collisionSenses ??= core.GetCoreComponent<CollisionSenses>();
    }
    private CollisionSenses collisionSenses;

    protected bool attackInput;
    protected bool isGrounded;

    public PlayerAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if (isGrounded && player.CurrentVelocity.y > 0.01f)
        {
            stateMachine.ChangeState(player.AirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
