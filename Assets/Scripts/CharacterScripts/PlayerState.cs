using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;

public class PlayerState
{
    protected PlayerController player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    //thời gian bắt đầy state 
    protected float startTime;
    protected bool isAnimationFinished;
    private string animBoolName;

    public PlayerState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    // đc gọi khi vào một state cụ thể
    public virtual void Enter()
    {
        DoCheck();
        player.Anim.Play(animBoolName);
        startTime = Time.time;
        Debug.Log(animBoolName);
        isAnimationFinished = false;
    }

    // dc gọi khi rời khỏi state
    public virtual void Exit()
    {
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
