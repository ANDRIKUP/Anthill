using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopOptions : MonoBehaviour
{
    [SerializeField] private GameObject scout, warrior;
    private int costScout = 6;
    private int costWarrior = 8;
    private int[] costLvlUp = new int[4];

    private bool isWarriorBought = false;

    [SerializeField] private Text txtCostLvlUP, txtTitleCostLvlUP, txtInfoCapacity;
    [SerializeField] private Text txtInfoFood;

    void Awake()
    {
        costLvlUp[0] = 20;
        costLvlUp[1] = 35;
        costLvlUp[2] = 55;
        costLvlUp[3] = 80;
    }
    public void spawnScout()
    {
        if (foodStorage.getFoodCount() >= costScout)
        {
            if (anthillCapacity.getCurrentCapacity() > antPopulation.getCountAnt())
            {
                Vector3 vec = HomeReturn.home;
                Instantiate(scout, vec, Quaternion.Euler(Vector3.zero));
                foodStorage.buyUpgr(costScout);
            }
        }
    }

    public void buyWarrior()
    {
        if (foodStorage.getFoodCount() >= costWarrior)
        {
            if (anthillCapacity.getCurrentCapacity() > antPopulation.getCountAnt())
            {
                if (!isWarriorBought)
                {
                    isWarriorBought = true; //Ждёт клика мыши
                    foodStorage.buyUpgr(costWarrior);
                }
            }
        }
    }

    //По клику мыши спавнит воина и он защищает позицию клика
    private void spawnWarrior()
    {
        Vector3 mouseClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseClickPos.z = 0;
        GameObject spwWarrior = Instantiate(warrior, mouseClickPos, Quaternion.Euler(Vector3.zero));
        spwWarrior.GetComponent<DeffendPlace>().setDeffendPos(mouseClickPos);
    }

    public void upgradeAnthill()
    {
        if (foodStorage.getFoodCount() >= costLvlUp[anthillCapacity.getCurrentLvl() - 1])
        {
            foodStorage.buyUpgr(costLvlUp[anthillCapacity.getCurrentLvl() - 1]);
            anthillCapacity.lvlUP();
            txtTitleCostLvlUP.text = anthillCapacity.getCurrentCapacity().ToString() + " -> " + anthillCapacity.getNextCapacity().ToString();
            txtCostLvlUP.text = "x" + costLvlUp[anthillCapacity.getCurrentLvl() - 1].ToString();
            txtInfoCapacity.text = "/ " + anthillCapacity.getCurrentCapacity().ToString();
        }
        else
        {
            txtInfoFood.GetComponent<Animator>().SetBool("lack", true);
            txtInfoFood.GetComponent<Animator>().SetBool("lack", false);
        }
    }

    void FixedUpdate()
    {
        if (isWarriorBought && Input.GetKey(KeyCode.Mouse1))
        {
            spawnWarrior();
            isWarriorBought = false;
        }
    }
}
