using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreWorld : MonoBehaviour
{
    public float speed;
    private float waitTime;           
    public float startWaitTime;
    public Vector3 moveTarget;
    private Vector3 foodPos;
    private Inventory inventory;

    FOVScout ownFOV;
    public Animator animator;

    void Start()
    {
        waitTime = startWaitTime;
        moveTarget = Vector3.zero;
        ownFOV = GetComponent<FOVScout>();
        inventory = GetComponent<Inventory>();
    }

    void FixedUpdate()
    {
        if (inventory.isCarrying())
        {
            moveTarget = HomeReturn.home - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, HomeReturn.home, speed * Time.deltaTime);
        }
        else if (ownFOV.isFoodSeeing())
        {
            if (ownFOV.findingFood.Count == 0)
            {
                ownFOV.notFoodSeeing();
            }
            else
            {
                waitTime = 0;
                foodPos = ownFOV.getFoodPos();
                moveTarget = foodPos - transform.position;
                transform.position = Vector3.MoveTowards(transform.position, foodPos, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, foodPos) < 0.1f)
                {
                    ownFOV.findingFood.Remove(foodPos);
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveTarget, speed * Time.deltaTime);
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                float koef = Random.Range(1, 3);
                moveTarget = CardinalDirections.chooseDirection();
                checkStaying();
                waitTime = startWaitTime * koef;
            }
        }
    }

    public Vector2 getMoveTarget()
    {
        return moveTarget;
    }

    private void checkStaying()
    {
        if (moveTarget != Vector3.zero)
        {
            animator.SetFloat("speed", 1);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
    }
}