using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    public float XInput {get; private set;}
    public float YInput {get; private set;}
    public bool JumpInput {get; private set;}
    public bool GrabInput {get; private set;}
    void Update()
    {
        XInput = Input.GetAxisRaw("Horizontal");
        YInput = Input.GetAxisRaw("Vertical");
        JumpInput = Input.GetButtonDown("Jump");
        GrabInput = Input.GetKey(KeyCode.LeftControl);
    }

    public void UseJumpInput() => JumpInput = false;
    
}
