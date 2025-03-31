using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy, IStunable
{
    #region State Variables
    public GoblinIdleState IdleState { get; private set; }
    public GoblinMoveState MoveState { get; private set; }
    public GoblinDetectedState DetectedState { get; private set; }
    public GoblinChasingState ChasingState { get; private set; }
    public GoblinAttackState EAttackState { get; private set; }
    public GoblinStunedState StunedState { get; private set; }

    public void ApplyStun()
    {
        E_StateMachine.ChangeState(StunedState);
    }
    #endregion

    public override void Awake()
    {
        base.Awake();

        IdleState = new GoblinIdleState(this, E_StateMachine, enemyData, AnimStrings.goblinIdle, this);
        MoveState = new GoblinMoveState(this, E_StateMachine, enemyData, AnimStrings.goblinMove, this);
        DetectedState = new GoblinDetectedState(this, E_StateMachine, enemyData, "detected", this);
        ChasingState = new GoblinChasingState(this, E_StateMachine, enemyData, AnimStrings.goblinChasing,this);
        EAttackState = new GoblinAttackState(this, E_StateMachine, enemyData, AnimStrings.goblinAttack, this);
        StunedState = new GoblinStunedState(this, E_StateMachine, enemyData, AnimStrings.goblinStuned,this);
    }

    public void Start()
    {
        E_StateMachine.Initialize(MoveState);
    }

    

}
