using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAttacked : MonoBehaviour
{
    private List<Collider2D> enemyAnts = new List<Collider2D>();
    private bool attacked = false;

    public bool isAttacked()
    {
        return attacked;
    }

    public void killedAnt()
    {
        enemyAnts.RemoveAt(0);
    }

    public int numberOfEnemy()
    {
        return enemyAnts.Count;
    }

    public void attackedByIt(Collider2D whom)
    {
        if (!enemyAnts.Contains(whom))
        {
            enemyAnts.Add(whom);
        }
    }

    public Collider2D getEnemyAnt()
    {
        if (enemyAnts.Count > 0)
        {
            return enemyAnts[0];
        }
        else return null;
    }

    void FixedUpdate()
    {
        if (enemyAnts.Count > 0)
        {
            attacked = true;
        }
        else
        {
            attacked = false;
        }
    }
}
