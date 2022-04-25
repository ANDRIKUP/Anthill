using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToAttack : MonoBehaviour
{
    public float speed = .75f;
    FOVWarrior fov;
    bool reached = false;
    AttackWarrior att;
    Collider2D threat;
    Animator animator;
    void Start()
    {
        fov = GetComponent<FOVWarrior>();
        att = GetComponent<AttackWarrior>();
        animator = GetComponent<Animator>();
    }
    public bool isReached()
    {
        return reached;
    }
    public Collider2D getThreat()
    {
        return threat;
    }
    
    public void FixedUpdate()
    {
        if (fov.isThreatSeeing())
        {
            if (!reached)
            {
                animator.SetFloat("speed", 1);
                threat = fov.getThreat();
                if (threat == null)
                {
                    reached = true;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, threat.transform.position, speed * Time.deltaTime);
                    if (Vector3.Distance(transform.position, threat.transform.position) < .5f)
                    {
                        reached = true;
                    }
                }
            }
            else
            {
                if (threat == null)
                {
                    animator.SetFloat("speed", 0);
                    fov.removeThreatFromList();
                    reached = false;
                    if (fov.getThreat() == null)
                    {
                        fov.notThreatSeeing();
                    }
                    else
                    {
                        threat = fov.getThreat();
                    }
                }
                else if (Vector3.Distance(transform.position, threat.transform.position) > 1f)
                {
                    reached = false;
                }
            }
        }
    }
    
}
