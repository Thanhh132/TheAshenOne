using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    public float MovementInput {get; private set;}
    public bool JumpInput {get; private set;}

    void Start()
    {
        
    }


    void Update()
    {
        MovementInput = Input.GetAxisRaw("Horizontal");
        JumpInput = Input.GetButtonDown("Jump");
    }

    public void UseJumpInput() => JumpInput = false;
}
