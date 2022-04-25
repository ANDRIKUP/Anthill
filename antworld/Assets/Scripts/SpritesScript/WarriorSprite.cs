using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorSprite : MonoBehaviour
{
    moveToAttack mvAtt;
    DeffendPlace dfPl;
    FOVWarrior fov;
    Animator animator;
    AttackWarrior att;
    void Start()
    {
        mvAtt = GetComponent<moveToAttack>();
        dfPl = GetComponent<DeffendPlace>();
        fov = GetComponent<FOVWarrior>();
        animator = GetComponent<Animator>();
        att = GetComponent<AttackWarrior>();
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
                    if (GetComponent<SpriteRenderer>().flipX == false)
                    {
                        att.attackPos.position += new Vector3(.5f, 0, 0);
                    }
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (mvAtt.getThreat().transform.position.x < transform.position.x)
                {
                    if (GetComponent<SpriteRenderer>().flipX == true)
                    {
                        att.attackPos.position -= new Vector3(.5f, 0, 0);
                    }
                    GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
        else if (!animator.GetBool("rest"))
        {
            if (dfPl.deffendPos.x > transform.position.x)
            {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    att.attackPos.position += new Vector3(.5f, 0, 0);
                }
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (dfPl.deffendPos.x < transform.position.x) 
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
