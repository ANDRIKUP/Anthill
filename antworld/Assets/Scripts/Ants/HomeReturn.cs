using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeReturn : MonoBehaviour
{
    public static Vector3 home = new Vector3(0, 0, 0);
    Animator animator;
    BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D home)
    {
        if (boxCollider.IsTouching(home))
        {
            if (home.CompareTag("Anthill"))
            {
                if (GetComponent<Inventory>().isCarrying())
                {
                    GetComponent<Inventory>().setCarryingOff();
                    foodStorage.addFood();
                    animator.SetBool("isCarrying", false);
                }
            }
        }
    }
}
