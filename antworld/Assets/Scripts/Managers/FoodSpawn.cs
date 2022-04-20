using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public float spawnTime;
    public List<GameObject> FoodList;
    public float maxCoord = 8;
    public float internalBound = 3;
    public Vector3 anthillPosition;
    void Start()
    {
        anthillPosition = HomeReturn.home;
        StartCoroutine("timer");
    }

    IEnumerator timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawn();
        }
    }

    void spawn()
    {
        GameObject food = FoodList[Random.Range(0, FoodList.Count)];
        Instantiate(food);
        food.transform.position = accurating();
    }

    Vector2 accurating()
    {
        float x, y;
        float negX = Random.Range(0f, 1f);
        float negY = Random.Range(0f, 1f);
        float flag = Random.Range(0f, 1f);
        if (flag < 0.33)
        {
            x = Random.Range(internalBound, maxCoord) + anthillPosition.x;
            y = Random.Range(internalBound, maxCoord) + anthillPosition.y;
        }
        else if (flag < 0.66)
        {
            x = Random.Range(internalBound, maxCoord) + anthillPosition.x;
            y = Random.Range(0f, maxCoord) + anthillPosition.y;
        }
        else
        {
            x = Random.Range(0f, maxCoord) + anthillPosition.x;
            y = Random.Range(internalBound, maxCoord) + anthillPosition.y;
        }
        if (negX > 0.5) x *= -1;
        if (negY > 0.5) y *= -1;
        Vector2 resultPos = new Vector2(x, y);
        return resultPos;
    }
}
