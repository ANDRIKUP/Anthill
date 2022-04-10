using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectable : MonoBehaviour
{
    BoxCollider2D boxCollider;
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (boxCollider.IsTouching(other))
        {
            if (other.CompareTag("Collectable"))
            {
                Collectable collectable = other.GetComponent<Collectable>();
                collectable.Collect();
            }
        }
    }
}