using JetBrains.Annotations;
using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    private int attackCount = 1;
    private int maxAttackCount = 4;
    private bool canCombo = false;
    [SerializeField] private float attackDamage;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        canCombo = false;
        player.Anim.Play("Player_Attack_" + attackCount);
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
        canCombo = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(0f);

        AnimatorStateInfo stateInfo = player.Anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.5f && stateInfo.normalizedTime < 1.0f)
        {
            canCombo = true;
        }

        if (attackInput && canCombo)
        {
            attackCount++;
            if (attackCount > maxAttackCount)
            {
                attackCount = 1;
            }
            player.Anim.Play("Player_Attack_" + attackCount);
            canCombo = false;
        }

        if (stateInfo.normalizedTime >= 1.0f || isAnimationFinished)
        {
            isAbilityDone = true;
            attackCount = 1;
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        
    }


}
