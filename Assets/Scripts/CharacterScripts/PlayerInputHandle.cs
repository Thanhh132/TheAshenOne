using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandle : MonoBehaviour
{
    public float MovementInput {get; private set;}

    void Start()
    {
        
    }


    void Update()
    {
        MovementInput = Input.GetAxisRaw("Horizontal");
    }
}
