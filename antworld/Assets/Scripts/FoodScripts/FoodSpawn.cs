using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public float spawnTime;
    public List<GameObject> FoodList;
    public float minCoord = -5;
    public float maxCoord = 5;
    void Start()
    {
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
        food.transform.position = new Vector2(Random.Range((float)minCoord, (float)maxCoord), Random.Range((float)minCoord, (float)maxCoord));
    }

}
