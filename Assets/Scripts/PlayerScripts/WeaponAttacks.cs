using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttacks : MonoBehaviour
{
    [SerializeField] private float attackDamage;
    [SerializeField] private Vector2 knockBackAngle = Vector2.zero;
    [SerializeField] private float knockBackStrength = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponentInParent<IDamageable>();
        Player player = GetComponentInParent<Player>();

        if (damageable != null && player != null)
        {
            damageable.TakeDamage(attackDamage);

            float attackerFacing = Mathf.Sign(player.transform.localScale.x);
            Vector2 finalKnockbackAngle = new Vector2(knockBackAngle.x * attackerFacing, knockBackAngle.y);
            
            damageable.Knockback(finalKnockbackAngle, knockBackStrength);
        }
    }
}