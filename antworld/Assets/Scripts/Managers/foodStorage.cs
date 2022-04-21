using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodStorage : MonoBehaviour
{
    public static int foodCount = 0;
    [SerializeField]
    private Text txtFoodCount;

    public static void addFood()
    {
        foodCount++;
    }

    public static int getFoodCount()
    {
        return foodCount;
    }

    private void Update()
    { 
        txtFoodCount.text = foodCount.ToString();
    }
}
