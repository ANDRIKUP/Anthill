using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutHealth : Health
{ 
    void Start()
    {
        health = 50;
        setHealth(health);
    }
}
