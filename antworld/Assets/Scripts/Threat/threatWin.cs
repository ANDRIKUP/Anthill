using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threatWin : MonoBehaviour
{
    [SerializeField]
    private GameObject manager;
    private gameOver ovr;

    void Start()
    {
        ovr = manager.GetComponent<gameOver>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Anthill"))
        {
            ovr.over();
        }
    }
}
