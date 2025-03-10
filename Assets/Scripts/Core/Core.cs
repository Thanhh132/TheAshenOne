using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement { get; private set; }
    public CollisionSenses CollisionSenses { get; private set; }
    public void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        if (Movement == null)
        {
            Debug.LogError("Movement not found!");
        }
    }
    
    public void LogicUpdate()
    {
        Movement.LogicUpdate();
    }
}
