using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void Damage(float damageAmount, Vector3 attacker);
    void Die();

    float MaxHealth{get; set;}
    float CurrentHealth {get; set;}
}