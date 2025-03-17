using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable
{
    public void TakeDamage(float damage)
    {
        Debug.Log(core.transform.parent.name + " nhận " + damage + " damage");
    }

    public void Knockback(Vector2 angle, float strength)
    {
        Vector2 force = angle * strength;
        Debug.Log(core.transform.parent.name + " bị knockback: force=" + force);
        
        Rigidbody2D rb = core.transform.parent.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
