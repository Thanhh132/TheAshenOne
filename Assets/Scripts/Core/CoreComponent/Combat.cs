using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IStunable
{
    [SerializeField] private GameObject damageParticles;

    private Stats Stats
    {
        get => stats ??= core.GetCoreComponent<Stats>();
    }

    private ParticleManager ParticleManager
    {
        get => particleManager ??= core.GetCoreComponent<ParticleManager>();
    }
    private Stats stats;
    private ParticleManager particleManager;
    public void TakeDamage(float damage)
    {
        Debug.Log(core.transform.parent.name + " nhận " + damage + " damage");
        Stats.DecreaseHealth(damage);
        ParticleManager.StartParticlesWithRandomRotation(damageParticles);
        IStunable stunnable = core.transform.parent.GetComponent<IStunable>();
        stunnable?.ApplyStun();
    }


    public void Knockback(Vector2 angle)
    {
        Vector2 force = angle;
        Debug.Log(core.transform.parent.name + " bị knockback");

        Rigidbody2D rb = core.transform.parent.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    public void ApplyStun()
    {
        Debug.Log(core.transform.parent.name + " bị stun");
    }
}
