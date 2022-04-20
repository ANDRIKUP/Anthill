using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    public float timeBtwAttack;

    public float getDamage()
    {
        return damage;
    }

    public float getTimeReload()
    {
        return timeBtwAttack;
    }

    protected void setDamage(float dmg)
    {
        damage = dmg;
    }

    protected void setTimeBtwAttack(float time)
    {
        timeBtwAttack = time;
    }
}
