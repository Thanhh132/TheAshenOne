using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemyData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 5f;

    [Header("Idle State")]
    public float idleDuration = 3f;

    [Header("Attack State")]
    public float attackCooldown = 2f;

    [Header("Sense Component")]
    public float wallCheckRadius = 0.5f;
    public float ledgeCheckDistance = 0.05f;
    public float detectingRange = 5f; 
    public float attackRange = 2.5f;
    public LayerMask isWall; 
    public LayerMask isGround;
    public LayerMask isLedge;
    public LayerMask isEnemy;  
    public LayerMask attackZone;

}
