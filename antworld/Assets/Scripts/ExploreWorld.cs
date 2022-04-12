using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreWorld : MonoBehaviour
{
    public float speed;
    private float waitTime;           
    public float startWaitTime;
    public Vector3 moveTarget;

    FOV ownFOV;

    void Start()
    {
        waitTime = startWaitTime;
        moveTarget = CardinalDirections.chooseDirection();
        ownFOV = GetComponent<FOV>();
    }

    void FixedUpdate()
    {
        if (ownFOV.isFoodSeeing())
        {
            moveTarget = ownFOV.getFoodPos();
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveTarget) < 0.01f)
            {
                ownFOV.findingFood.Remove(moveTarget);
                if (ownFOV.findingFood.Count == 0)
                {
                    ownFOV.notFoodSeeing();
                    waitTime = startWaitTime * Random.Range(1, 5);
                }
                else
                {
                    ownFOV.improveVision();
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            }
            else
            {
                float koef = Random.Range(1, 5);
                moveTarget = CardinalDirections.chooseDirection() * koef;
                waitTime = startWaitTime * koef;
            }
        }
    }

    public Vector2 getMoveTarget()
    {
        return moveTarget;
    }
}