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

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask isGrounded;
}
