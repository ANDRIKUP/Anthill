using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waspDamage : Damage
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 17f;
        setDamage(damage);
        timeBtwAttack = 2f;
        setTimeBtwAttack(timeBtwAttack);
    }

}
