using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool Carrying = false;
    public bool isCarrying()
    {
        return Carrying;
    }

    public void setCarryingOn()
    {
        Carrying = true;
    }
    public void setCarryingOff()
    {
        Carrying = false;
    }
}
