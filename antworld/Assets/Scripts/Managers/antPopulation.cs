using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class antPopulation : MonoBehaviour
{
    private static int countAnt = 0;
    [SerializeField]
    private Text txtCountAnt;


    public static int getCountAnt()
    {
        return countAnt;
    }

    private void FixedUpdate()
    {
        GameObject[] mas = GameObject.FindGameObjectsWithTag("Ant");
        countAnt = mas.Length;
        txtCountAnt.text = countAnt.ToString();
    }
}
