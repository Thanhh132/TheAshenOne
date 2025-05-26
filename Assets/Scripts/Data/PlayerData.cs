using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 5f;

    [Header("Jump State")]
    public float jumpVelocity = 5f;

    [Header("Climb State")]
    public float climbVelocity = 3f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;

    [Header("Roll State")]
    public float rollVelocity = 10f;

    [Header("Stats")]
    public float damage;
    public float maxHealth = 100f;
    public float maxMana = 50f;

}
