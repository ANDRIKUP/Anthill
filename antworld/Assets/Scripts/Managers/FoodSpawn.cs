using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoodSpawn : MonoBehaviour
{
    public float spawnTime;
    public List<GameObject> FoodList;
    private float mapMaxX, mapMaxY;
    public float internalBound = 3;
    public Vector3 anthillPosition;

    [SerializeField]
    private Tilemap map;
    private void Awake()
    {
        mapMaxX = map.transform.position.x + map.size.x / 2f;

        mapMaxY = map.transform.position.y + map.size.y / 2f;
    }
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
            x = Random.Range(internalBound, mapMaxX) + anthillPosition.x;
            y = Random.Range(internalBound, mapMaxY) + anthillPosition.y;
        }
        else if (flag < 0.66)
        {
            x = Random.Range(internalBound, mapMaxX) + anthillPosition.x;
            y = Random.Range(0f, mapMaxY) + anthillPosition.y;
        }
        else
        {
            x = Random.Range(0f, mapMaxX) + anthillPosition.x;
            y = Random.Range(internalBound, mapMaxY) + anthillPosition.y;
        }
        if (negX > 0.5) x *= -1;
        if (negY > 0.5) y *= -1;
        Vector2 resultPos = new Vector2(x, y);
        return resultPos;
    }
}
