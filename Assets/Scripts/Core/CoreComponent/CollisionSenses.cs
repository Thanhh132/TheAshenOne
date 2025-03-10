using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheck {get => groundCheck; private set => groundCheck = value;}
    public Transform WallCheck {get => wallCheck; private set => wallCheck = value;}

    [SerializeField]private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private float wallCheckDistance;
    
    [SerializeField] private LayerMask isGrounded;
    [SerializeField] private LayerMask isTouchingWall;

    public bool IfGrounded
    {
        get => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGrounded);

    }


    public bool IfTouchingWall
    {
        get => Physics2D.Raycast(wallCheck.position, Vector2.right * core.Movement.FacingDirection, wallCheckDistance, isTouchingWall);
    }
}
