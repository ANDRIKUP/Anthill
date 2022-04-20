using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warriorHealth : Health
{
    // Start is called before the first frame update
    void Start()
    {
        base.health = 100f;
        setHealth(health);
    }

}
