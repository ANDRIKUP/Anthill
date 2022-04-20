using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool Carrying = false;
    ExploreWorld exploreWorld;

    void Start()
    {
        exploreWorld = GetComponent<ExploreWorld>();
    }

    public bool isCarrying()
    {
        return Carrying;
    }

    public void setCarryingOn()
    {
        Carrying = true;
        exploreWorld.speed = .7f;
    }
    public void setCarryingOff()
    {
        Carrying = false;
        exploreWorld.speed = 1f;
    }
}
