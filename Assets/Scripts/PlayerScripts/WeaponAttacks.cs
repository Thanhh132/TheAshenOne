using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttacks : MonoBehaviour
{
    [SerializeField] private float attackDamage;
    [SerializeField] private Vector2 knockBackAngle = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponentInParent<IDamageable>();
        Transform attacker = transform.root; 

        if (damageable != null && attacker != null)
        {
            damageable.TakeDamage(attackDamage);

            float attackerFacing = attacker.localScale.x;
            Vector2 finalKnockbackAngle = new Vector2(knockBackAngle.x * attackerFacing, knockBackAngle.y);
            
            damageable.Knockback(finalKnockbackAngle);
        }
    }
}
