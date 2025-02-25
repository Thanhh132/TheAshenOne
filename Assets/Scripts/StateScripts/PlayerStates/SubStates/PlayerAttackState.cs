using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    private int attackCount = 1;
    private int maxAttackCount = 4;
    private bool canCombo = false;

    public PlayerAttackState(PlayerController player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        canCombo = false;
        player.Anim.SetInteger("AttackCount", attackCount);
        player.Anim.Play("Player_Attack_" + attackCount);
    }

    public override void Exit()
    {
        base.Exit();
        canCombo = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityX(0f);

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

            player.Anim.SetInteger("AttackCount", attackCount);
            player.Anim.Play("Player_Attack_" + attackCount);
            canCombo = false; 
        }

        if (stateInfo.normalizedTime >= 1.0f || isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
