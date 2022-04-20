using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public float getHealth()
    {
        return health;
    }

    protected void setHealth(float hp)
    {
        health = hp;
    }

    public void setDamage(float damage)
    {
        health -= damage;
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
