using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warriorHealth : Health
{
    private Animator animator;
    //время между регенерацией
    [SerializeField] private float timeBtwRegen;
    private float curTimeBtwRegen = 0;
    [SerializeField] private float countHPRegen;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        base.health = 100f;
        setHealth(health);
    }

    void Update()
    {
        if (health < 100)
        {
            if (animator.GetFloat("speed") == 0)
            {
                if (curTimeBtwRegen <= 0)
                {
                    regeneration();
                    curTimeBtwRegen = timeBtwRegen;
                }
                else
                {
                    curTimeBtwRegen -= Time.deltaTime;
                }
            }
            else if (curTimeBtwRegen > 0)
            {
                curTimeBtwRegen -= Time.deltaTime;
            }
        }
        else if (health > 100)
        {
            health = 100;
        }
    }

    private void regeneration()
    {
        setHealth(health + countHPRegen);
    }

}
