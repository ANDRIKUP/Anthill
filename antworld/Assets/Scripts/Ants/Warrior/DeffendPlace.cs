using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffendPlace : MonoBehaviour
{
    public Vector3 deffendPos = new Vector3(1, 1, 0);
    moveToAttack mvAtt;
    FOVWarrior fov;
    Animator animator;
    void Start()
    {
        fov = GetComponent<FOVWarrior>();
        animator = GetComponent<Animator>();
        mvAtt = GetComponent<moveToAttack>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == deffendPos)
        {
            animator.SetFloat("speed", 0);
        }
        else if(!fov.isThreatSeeing() && !animator.GetBool("rest"))
        {
            animator.SetFloat("speed", 1);
            transform.position = Vector3.MoveTowards(transform.position, deffendPos, mvAtt.speed * Time.deltaTime);
        }
    }
}
