using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;
    Inventory inventory;
    Animator animator;
    FOVScout fov;
    NotifyAboutThreat notific;
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
        fov = GetComponent<FOVScout>();
        notific = GetComponent<NotifyAboutThreat>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (capsuleCollider.IsTouching(other))
        {
            if (other.CompareTag("Collectable"))
            {
                if (!notific.isThreatSeeing())
                {
                    if (!GetComponent<Inventory>().isCarrying())
                    {
                        Collectable collectable = other.GetComponent<Collectable>();
                        collectable.Collect();
                        pickFood(); // Подбор еды и переключение анимации
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
    }

    private void pickFood()
    {
        inventory.setCarryingOn();
        animator.SetBool("isCarrying", true);
    }
}