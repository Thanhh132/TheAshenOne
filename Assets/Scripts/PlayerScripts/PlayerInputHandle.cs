using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    public float XInput {get; private set;}
    public float YInput {get; private set;}
    public bool AttackInput {get; private set;}
    public bool JumpInput {get; private set;}
    public bool GrabInput {get; private set;}
    public bool SlideInput {get; private set;}
    public bool RollInput {get; private set;}

    [SerializeField]

    void Start()
    {

    }
    void Update()
    {
        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");
        JumpInput = Input.GetButtonDown("Jump");
        GrabInput = Input.GetKey(KeyCode.LeftControl);
        SlideInput = Input.GetKeyDown(KeyCode.LeftShift);
        RollInput = Input.GetKeyDown(KeyCode.Mouse1);
        AttackInput = Input.GetKeyDown(KeyCode.Mouse0);
    }
    public void UseJumpInput() => JumpInput = false;  
}

