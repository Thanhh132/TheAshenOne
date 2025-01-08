using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    private float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        IsMoving = horizontal != 0; 
        IsRunning = Input.GetKey(KeyCode.LeftShift);  
    }

    void FixedUpdate()
    {
        HandleMovement();
        FlipDirection();
    }

    private void HandleMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(IsMoving){
            rb.velocity = new Vector2(horizontal * CurrentSpeed, rb.velocity.y);
        }
        animator.SetBool("IsMoving", IsMoving);
        animator.SetBool("IsRunning", IsRunning);

        // Nhảy
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce) ; 
        }

    }

    private float CurrentSpeed
    {
        get{
            if(IsMoving){
                if(IsRunning){
                    return runSpeed;
                }else{
                    return walkSpeed;
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
