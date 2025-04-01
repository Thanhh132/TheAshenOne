using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingSenses : CoreComponent
{
    protected Movement Movement { get => movement ??= core.GetCoreComponent<Movement>(); }
    private Movement movement;
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float detectingRange;
    [SerializeField] private float attackRange;
    [SerializeField] private Collider2D chasingRange;
    [SerializeField] private Transform attackZone;
    [SerializeField] private LayerMask isEnemy;

    public Transform EnemyCheck
    {
        get => GenericNotImplementedError<Transform>.TryGet(enemyCheck, core.transform.parent.name);
        private set => enemyCheck = value;
    }

    public Collider2D ChasingZone
    {
        get => GenericNotImplementedError<Collider2D>.TryGet(chasingRange, core.transform.parent.name);
        private set => chasingRange = value;
    }

    public Transform AttackZone
    {
        get => GenericNotImplementedError<Transform>.TryGet(attackZone, core.transform.parent.name);
        private set => attackZone = value;
    }


    public bool IsEnemy
    {
        get => Physics2D.Raycast(enemyCheck.position, Vector2.right * Movement.FacingDirection, detectingRange, isEnemy);
    }

    public bool IsEnemyInChasingArea
    {
        get => Physics2D.OverlapBox(chasingRange.bounds.center, chasingRange.bounds.size, 0, isEnemy);
    }
    public Transform GetEnemyTarget()
    {
        Collider2D targetCollider = Physics2D.OverlapBox(chasingRange.bounds.center, chasingRange.bounds.size, 0, isEnemy);
        return targetCollider ? targetCollider.transform : null;
    }

    public bool IsEnemyInAttackArea
    {
        get => Physics2D.Raycast(attackZone.position, Vector2.right * Movement.FacingDirection, attackRange, isEnemy);
    }
}
