using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class threatSpawn : MonoBehaviour
{
    //время для усложнения игры
    [SerializeField] private float timeBtwWavesDifc = 120f;
    private float curTimeBtwWavesDifc;
    //время между спавнами волн
    [SerializeField] private float timeBtwWaveSpawns = 30f;
    private float curTimeBtwWaveSpawns;
    //время между спавнами угроз в волне
    [SerializeField] private float spawningTime = 3f;
    private float curSpawningTime;
    //количество мирного времени в начале
    [SerializeField] private float peaceTime = 120f;
    private float mapMaxX, mapMaxY;
    private int difficult = 1;
    [SerializeField] List<GameObject> threatsType = new List<GameObject>();
    List<GameObject> waveThreats = new List<GameObject>();

    [SerializeField] private Tilemap map;

    public int getDifficult()
    {
        return difficult;
    }
    public float getPeaceTime()
    {
        return peaceTime;
    }

    void Start()
    {
        mapMaxX = map.transform.position.x + map.size.x / 2f - .5f;
        mapMaxY = map.transform.position.y + map.size.y / 2f - .5f;
        curTimeBtwWavesDifc = timeBtwWavesDifc;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (peaceTime > 0)
        {
            peaceTime -= Time.deltaTime;
        }
        else
        {
            if (curTimeBtwWavesDifc > 0) curTimeBtwWavesDifc -= Time.deltaTime;
            if (curTimeBtwWaveSpawns > 0) curTimeBtwWaveSpawns -= Time.deltaTime;
            if (curTimeBtwWavesDifc <= 0)
            {
                difficult++;
                curTimeBtwWavesDifc = timeBtwWavesDifc;
            }
            if (curTimeBtwWaveSpawns <= 0)
            {
                if (waveThreats.Count == 0)
                {
                    for (int i = 0; i < difficult; i++)
                    {
                        waveThreats.Add(randThreat());
                    }
                    curTimeBtwWaveSpawns = timeBtwWaveSpawns;
                }
            }
            if (waveThreats.Count > 0)
            {
                if (curSpawningTime > 0) curSpawningTime -= Time.deltaTime;
                else
                {
                    spawn(waveThreats[0]);
                    waveThreats.RemoveAt(0);
                    curSpawningTime = spawningTime;
                }
            }
        }
    }


    GameObject randThreat()
    {
        GameObject threat;
        //float rand = Random.Range(0f, 1f);
        /*if (rand < .8f) */threat = threatsType[0];
        //else threat = threatsType[1];
        return threat;
    }

    void spawn(GameObject threat)
    {
        Instantiate(threat);
        threat.transform.position = accurating();
    }

    Vector2 accurating()
    {
        float x, y;
        float negative = Random.Range(0f, 1f);
        float flag = Random.Range(0f, 1f);

        if (flag < 0.5f)
        {
            x = mapMaxX;
            y = Random.Range(-mapMaxY, mapMaxY);
            if (negative > .5f)
            {
                x *= -1;
            }
        }
        else
        {
            x = Random.Range(-mapMaxX, mapMaxX);
            y = mapMaxY;
            if (negative > .5f)
            {
                y *= -1;
            }
        }
        return new Vector2(x, y);
    }
}
