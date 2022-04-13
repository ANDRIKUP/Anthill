using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardinalDirections : MonoBehaviour
{
    public enum cardinalDir
    {
        N,
        NNE,
        NE,
        NEE,
        E,
        SEE,
        SE,
        SSE,
        S,
        SSW,
        SW,
        SWW,
        W,
        NWW,
        NW,
        NNW,
        waiting1,
        waiting2,
        waiting3
    }

    public static Vector2 chooseDirection()
    {
        System.Random random = new System.Random();
        cardinalDir carDir = (cardinalDir)random.Next(Enum.GetNames(typeof(cardinalDir)).Length);
        Vector2 dir = Vector2.zero;
        switch (carDir)
        {
            case cardinalDir.N:
                dir= Vector2.up;
                break;
            case cardinalDir.NNE:
                dir = 2 * Vector2.up + Vector2.right;
                break;
            case cardinalDir.NE:
                dir = Vector2.up + Vector2.right;
                break;
            case cardinalDir.NEE:
                dir = Vector2.up + 2 * Vector2.right;
                break;
            case cardinalDir.E:
                dir = Vector2.right;
                break;
            case cardinalDir.SEE:
                dir = Vector2.down + 2 * Vector2.right;
                break;
            case cardinalDir.SE:
                dir = Vector2.down + Vector2.right;
                break;
            case cardinalDir.SSE:
                dir = 2 * Vector2.down + Vector2.right;
                break;
            case cardinalDir.S:
                dir = Vector2.down;
                break;
            case cardinalDir.SSW:
                dir = 2 * Vector2.down + Vector2.left;
                break;
            case cardinalDir.SW:
                dir = Vector2.down + Vector2.left;
                break;
            case cardinalDir.SWW:
                dir = Vector2.down + 2 * Vector2.left;
                break;
            case cardinalDir.W:
                dir = Vector2.left;
                break;
            case cardinalDir.NWW:
                dir = Vector2.up + 2 * Vector2.left;
                break;
            case cardinalDir.NW:
                dir = Vector2.up + Vector2.left;
                break;
            case cardinalDir.NNW:
                dir = 2 * Vector2.up + Vector2.left;
                break;
            case cardinalDir.waiting1:
                dir = Vector2.zero;
                break;
            case cardinalDir.waiting2:
                dir = Vector2.zero;
                break;
            case cardinalDir.waiting3:
                dir = Vector2.zero;
                break;
            default:
                Debug.Log("Incorrect direction!!!");
                break;
        }
        return dir;
    }
}
