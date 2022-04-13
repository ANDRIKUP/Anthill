using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable : MonoBehaviour
{
    BoxCollider2D boxCollider;
    Inventory inventory;
    Animator animator;
    FOV fov;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
        fov = GetComponent<FOV>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (boxCollider.IsTouching(other))
        {
            if (other.CompareTag("Collectable"))
            {
                if (!GetComponent<Inventory>().isCarrying())
                {
                    Collectable collectable = other.GetComponent<Collectable>();
                    collectable.Collect();
                    pickFood(); // ������ ��� � ������������ ��������
                    if (fov.findingFood.Count > 0)
                    {
                        fov.findingFood.RemoveAt(0);
                    }
                    if (fov.findingFood.Count != 0)
                    {
                        fov.improveVision();
                    }
                }
            }
        }
    }

    private void pickFood()
    {
        inventory.setCarryingOn();
        animator.SetBool("isCarrying", true);
    }
}