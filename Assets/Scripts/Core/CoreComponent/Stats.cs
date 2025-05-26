using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stats : CoreComponent
{
    public event Action OnHealthZero;
    [SerializeField] public float maxHealth;
    [SerializeField] public float currentHealth;
    public HealthBar healthBar;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnHealthZero?.Invoke();

            Debug.Log("Character is dead.");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += math.clamp(currentHealth + amount, 0, maxHealth);
    }
}
