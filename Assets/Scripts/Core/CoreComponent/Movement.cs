using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    public Rigidbody2D RB { get; private set; }

    public int FacingDirection { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;

    protected override void Awake()
    {
        base.Awake();
        RB = GetComponentInParent<Rigidbody2D>();
        FacingDirection = 1;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    private void Flip()
    {
        FacingDirection *= -1;
        Vector3 scale = RB.transform.localScale;
        scale.x *= -1; 
        RB.transform.localScale = scale;
    }


    public void FlipCheck(float input)
    {
        if (input != 0 && input != FacingDirection)
        {
            Flip();
        }
    }

}