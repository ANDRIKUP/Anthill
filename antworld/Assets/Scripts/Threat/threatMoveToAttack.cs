using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threatMoveToAttack : MonoBehaviour
{
    public float speed = 1f;
    checkAttacked check;
    Collider2D target;
    bool reached = false;

    void Start()
    {
        check = GetComponent<checkAttacked>();
    }

    public bool isReached()
    {
        return reached;
    }

    void FixedUpdate()
    {
        if (check.isAttacked())
        {
            if (target == null)
            {
                if ((target = check.getEnemyAnt()) == null)
                {
                    check.killedAnt();
                }
                
            }
            else
            {
                if (!reached)
                {
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, target.transform.position) < .5f)
                    {
                        reached = true;
                    }
                }
                else
                {
                    if (Vector3.Distance(transform.position, target.transform.position) > .6f)
                    {
                        reached = false;
                    }
                }
            }
        }
        else
        {
            reached = false;
        }
    }
}
