using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSprite : MonoBehaviour
{
    moveToAttack mvAtt;
    DeffendPlace dfPl;
    FOVWarrior fov;
    Animator animator;
    void Start()
    {
        mvAtt = GetComponent<moveToAttack>();
        dfPl = GetComponent<DeffendPlace>();
        fov = GetComponent<FOVWarrior>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fov.isThreatSeeing())
        {
            if (mvAtt.getThreat() != null)
            {
                if (mvAtt.getThreat().transform.position.x > transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (mvAtt.getThreat().transform.position.x < transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        else if (!animator.GetBool("rest"))
        {
            if (dfPl.deffendPos.x > transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (dfPl.deffendPos.x < transform.position.x) 
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
