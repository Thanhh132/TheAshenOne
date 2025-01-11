using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private TouchingDirection touchingDirection;

    public float walkSpeed;
    public float runSpeed;
    public float airWalkSpeed;
    public float jumpForce;
    private float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirection = GetComponent<TouchingDirection>();
    }

    // Update is called once per frame
    private void Update()
    {
        HandleMovement();
    }

    void FixedUpdate()
    {
        
        FlipDirection();

    }

    private void HandleMovement()
    {
        IsMoving = horizontal != 0;
        IsRunning = Input.GetKey(KeyCode.LeftShift) && touchingDirection.IsOnGround 
        && IsMoving;

        //di chuyển 
        horizontal = Input.GetAxisRaw("Horizontal");
        if (IsMoving)
        {
            rb.velocity = new Vector2(horizontal * CurrentSpeed, rb.velocity.y);
        }

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && touchingDirection.IsOnGround)
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        animator.SetFloat(AnimationStrings.velocityY, rb.velocity.y);

        //Tấn công
        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger(AnimationStrings.attack);
        }
    }


    private float CurrentSpeed
    {
        get
        {
            if (IsMoving && !touchingDirection.IsOnWall)
            {
                if (touchingDirection.IsOnGround)
                {
                    if (IsRunning)
                    {
                        return runSpeed;
                    }
                    else
                    {
                        return walkSpeed;
                    }
                }
                else
                {
                    return airWalkSpeed;
                }
            }
            return 0;
        }
    }

    private bool _isMoving;
    public bool IsMoving
    {
        get { return _isMoving; }
        set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    private bool _isRunning;
    public bool IsRunning
    {
        get { return _isRunning; }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    // Kiểm tra hướng quay
    private bool _isFacingRight = true;
    private bool IsFacingRight
    {
        get { return _isFacingRight; }
        set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    private void FlipDirection()
    {
        if (horizontal > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (horizontal < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }


}
