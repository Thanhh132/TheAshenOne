using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    private CapsuleCollider2D touchingCol;
    public ContactFilter2D castFiller;
    private Animator animator;

    public RaycastHit2D[] groundDetect = new RaycastHit2D[5];
    public RaycastHit2D[] wallDetect = new RaycastHit2D[5];
    public RaycastHit2D[] ceilingDetect = new RaycastHit2D[5];

    public float groundDistance;
    public float wallDistance;
    public float ceilingDistance;

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ColiderChecking();
    }

    private void ColiderChecking()
    {
        IsOnGround = touchingCol.Cast(Vector2.down, castFiller, groundDetect, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFiller, wallDetect, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFiller, ceilingDetect, ceilingDistance) > 0;
    }

    private bool _isOnGround = true;
    public bool IsOnGround
    {
        get { return _isOnGround; }
        set
        {
            _isOnGround = value;
            animator.SetBool(AnimationStrings.isOnGround, value);
        }
    }

    private bool _isOnWall = false;
    public bool IsOnWall
    {
        get { return _isOnWall; }
        set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    private bool _isOnCeiling = false;
    public bool IsOnCeiling
    {
        get { return _isOnCeiling; }
        set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }
}

