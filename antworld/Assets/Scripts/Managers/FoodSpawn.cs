using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoodSpawn : MonoBehaviour
{
    [SerializeField] private float spawnTime;
    public List<GameObject> FoodList;
    private float mapMaxX, mapMaxY;
    [SerializeField] private float curMaxX, curMaxY;
    private static float statCurMaxX, statCurMaxY;
    [SerializeField] private float internalBound;
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
        statCurMaxX = curMaxX;
        statCurMaxY = curMaxY;
        StartCoroutine("timer");
    }

    public static Vector2 getStatMaxCoord()
    {
        return new Vector2(statCurMaxX, statCurMaxY);
    }

    IEnumerator timer()
    {
        int k = 0;
        float stepX = (mapMaxX - curMaxX) / 10;
        float stepY = (mapMaxY - curMaxY) / 10;
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            if (k <= 200)
            {
                k++;
                if (k % 20 == 0)
                {
                    if (curMaxX < mapMaxX && curMaxY < mapMaxY)
                    {
                        curMaxX += stepX;
                        curMaxY += stepY;
                        statCurMaxX = curMaxX;
                        statCurMaxY = curMaxY;
                    }
                }
            }
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
            x = Random.Range(internalBound, curMaxX) + anthillPosition.x;
            y = Random.Range(internalBound, curMaxY) + anthillPosition.y;
        }
        else if (flag < 0.66)
        {
            x = Random.Range(internalBound, curMaxX) + anthillPosition.x;
            y = Random.Range(0f, curMaxY) + anthillPosition.y;
        }
        else
        {
            x = Random.Range(0f, curMaxX) + anthillPosition.x;
            y = Random.Range(internalBound, curMaxY) + anthillPosition.y;
        }
        if (negX > 0.5) x *= -1;
        if (negY > 0.5) y *= -1;
        Vector2 resultPos = new Vector2(x, y);
        return resultPos;
    }
}
