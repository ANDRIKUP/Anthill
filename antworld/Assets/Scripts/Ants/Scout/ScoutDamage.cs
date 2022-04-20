using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutDamage : Damage
{
    void Start()
    {
        damage = 3f;
        setDamage(damage);
        timeBtwAttack = 2f;
        setTimeBtwAttack(timeBtwAttack);
    }
}
