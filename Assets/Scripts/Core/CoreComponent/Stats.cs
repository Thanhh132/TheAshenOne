using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
    }

    public void DecreseHealth(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Character is dead.");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += math.clamp(currentHealth + amount, 0, maxHealth);
    }
}
