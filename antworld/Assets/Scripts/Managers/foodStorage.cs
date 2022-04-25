using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class foodStorage : MonoBehaviour
{
    private static int foodCount;
    [SerializeField] private int startCount;
    [SerializeField]
    private Text txtFoodCount;
    void Start()
    {
        foodCount = startCount;
    }
    public static void addFood()
    {
        foodCount++;
    }

    public static void buyUpgr(int cost)
    {
        if (foodCount >= cost)
        {
            foodCount -= cost;
        }
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
