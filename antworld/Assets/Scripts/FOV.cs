using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV 
{
    public float radius = 1f;
    public float angle = 90f;

    bool foodSeeing = false;

    CircleCollider2D circleCollider;
    Vector2 foodPos;

    public bool isFoodSeeing()
    {
        return foodSeeing;
    }
    public Vector2 getFoodPos()
    {
        return foodPos;
    }
    public void notFoodSeeing()
    {
        foodSeeing = false;
    }

    private void Start()
    {
        circleCollider.GetComponent<CircleCollider2D>();
        circleCollider.radius = radius;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (circleCollider.IsTouching(other))
        {
            if (other.CompareTag("Collectable") && !foodSeeing)
            {
                Debug.Log("See it!");
                foodSeeing = true;
                foodPos = other.transform.position;
            }
        }
    }
}

