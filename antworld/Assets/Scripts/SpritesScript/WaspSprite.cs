using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspSprite : MonoBehaviour
{
    Vector3 anthill;
    Vector3 target;
    checkAttacked check;
    threatsAttack att;

    void Start()
    {
        anthill = HomeReturn.home;
        check = GetComponent<checkAttacked>();
        att = GetComponent<threatsAttack>();
    }

    void FixedUpdate()
    {
        if (!check.isAttacked())
        {
            if (anthill.x > transform.position.x)
            {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    att.attackPos.position += new Vector3(.5f, 0, 0);
                }
                GetComponent<SpriteRenderer>().flipX = true;
                
            }
            else if (anthill.x < transform.position.x)
            {
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    att.attackPos.position -= new Vector3(.5f, 0, 0);
                }
                GetComponent<SpriteRenderer>().flipX = false;
                
            }
        }
        else
        {
            if (check.getEnemyAnt() != null)
            {
                target = check.getEnemyAnt().transform.position;
                if (target.x > transform.position.x)
                {
                    if (GetComponent<SpriteRenderer>().flipX == false)
                    {
                        att.attackPos.position += new Vector3(.5f, 0, 0);
                    }
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (target.x < transform.position.x)
                {
                    if (GetComponent<SpriteRenderer>().flipX == true)
                    {
                        att.attackPos.position -= new Vector3(.5f, 0, 0);
                    }
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }


}
