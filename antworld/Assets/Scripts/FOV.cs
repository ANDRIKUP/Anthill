using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour 
{
    public float radius = 1f;
    public float angle = 90f;

    bool foodSeeing = false;

    CircleCollider2D circleCollider;
    Vector2 foodPos;

    public List<Vector2> findingFood = new List<Vector2>();

    public bool isFoodSeeing()
    {
        return foodSeeing;
    }
    public Vector2 getFoodPos()
    {
        return findingFood[0];
    }
    public void notFoodSeeing()
    {
        foodSeeing = false;
    }

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = radius;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (circleCollider.IsTouching(other))
        {
            if (other.CompareTag("Collectable"))
            {
                foodSeeing = true;
                if (findingFood.IndexOf(other.transform.position) == -1)
                {
                    foodPos = other.transform.position;
                    findingFood.Add(foodPos);
                    improveVision();
                }
            }
        }
    }

    public void improveVision()
    {
        Vector2 current = transform.position;
        List<float> differ = new List<float>();
        for (int i = 1; i < findingFood.Count; i++)
        {
            float val = Mathf.Sqrt(Mathf.Pow(findingFood[i].x - current.x, 2) + Mathf.Pow(findingFood[i].y - current.y, 2));
            differ.Add(val);
        }
        //Сортировка вставками
        for (int i = 1; i < differ.Count; i++)
        {
            for (int j = i; j > 0; j--)
            {
                if (differ[j] < differ[j - 1])
                {
                    float temp = differ[j];
                    differ[j] = differ[j - 1];
                    differ[j - 1] = temp;

                    Vector2 tempV = findingFood[j + 1];
                    findingFood[j + 1] = findingFood[j];
                    findingFood[j] = tempV;
                }
            }
        }
    }
}

