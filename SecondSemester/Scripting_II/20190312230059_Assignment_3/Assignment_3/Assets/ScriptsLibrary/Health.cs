using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public bool destroyOnNoHealth = true;

    private void OnDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(destroyOnNoHealth)
            {
                Destroy(gameObject);
            }
        }
    }
}
