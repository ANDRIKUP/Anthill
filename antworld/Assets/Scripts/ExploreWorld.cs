using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreWorld : MonoBehaviour
{
    public float speed;
    private float waitTime;           
    public float startWaitTime;
    Vector3 moveTarget;

    //FOV пол€
    public float radius = 2f;
    public float angle = 90f;
    bool foodSeeing = false;
    CircleCollider2D circleCollider;
    Vector2 foodPos;
    //-------------
    public Vector2 curvect;
    //
    public List<Vector2> findingFood = new List<Vector2>();
    //

    void Start()
    {
        waitTime = startWaitTime;
        moveTarget = CardinalDirections.chooseDirection();

        //FOV
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = radius;
        //----------
    }

    void FixedUpdate()
    {
        curvect = transform.position;
        if (isFoodSeeing())
        {
            //¬от здесь доделать
            moveTarget = getFoodPos();
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, moveTarget) < 0.01f)
            {
                findingFood.Remove(moveTarget);
                if (findingFood.Count == 0)
                {
                    notFoodSeeing();
                    waitTime = startWaitTime * Random.Range(1, 5);
                }
                else
                {
                    improveVision();
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

    //—ортирует список найденной еды в пор€дке удалени€ от муравь€
    //(возрастани€ рассто€ни€ от муравь€ до еды)
    public void improveVision()
    {
        Vector2 current = transform.position;
        List<float> differ = new List<float>();
        for (int i = 1; i < findingFood.Count; i++)
        {
            float val = Mathf.Sqrt(Mathf.Pow(findingFood[i].x - current.x, 2) + Mathf.Pow(findingFood[i].y - current.y, 2));
            differ.Add(val);
        }
        //—ортировка вставками
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

    //FOV
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (circleCollider.IsTouching(other))
        {
            if (other.CompareTag("Collectable")/* && !foodSeeing*/)
            {
                foodSeeing = true;
                if (findingFood.IndexOf(other.transform.position) == -1)
                {
                    foodPos = other.transform.position;
                    findingFood.Add(foodPos);
                    improveVision();
                }
                else
                {
                    Debug.Log("I have alredy found this food!");
                }
            }
        }
    }
    //------------
}