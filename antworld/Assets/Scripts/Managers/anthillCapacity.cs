using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anthillCapacity : MonoBehaviour
{
    private static int antCapacity;
    private static int[] lvl = new int[5];
    private static int currentLvl;
    void Start()
    {
        currentLvl = 1;
        for (int i = 0; i < lvl.Length; i++)
        {
            lvl[i] = 5 * i + 15;
        }
        antCapacity = lvl[0];
    }

    public static int getCurrentLvl()
    {
        return currentLvl;
    }

    public static int getCurrentCapacity()
    {
        return antCapacity;
    }

    public static int getNextCapacity()
    {
        if (currentLvl < lvl.Length) return lvl[currentLvl];
        else return -1;
    }

    public static void lvlUP()
    {
        if (currentLvl < lvl.Length)
        {
            antCapacity = lvl[currentLvl];
            currentLvl++;
        }
    }

}
