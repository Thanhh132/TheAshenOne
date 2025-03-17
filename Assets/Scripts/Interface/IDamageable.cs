using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void TakeDamage(float damage);
    void Knockback(Vector2 angle, float strength);
}
