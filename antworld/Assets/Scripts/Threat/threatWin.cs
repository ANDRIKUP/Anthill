using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threatWin : MonoBehaviour
{
    public GameObject manager;

    void Awake()
    {
        manager = GameObject.Find("manager");
    }

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Anthill"))
        {
            manager.GetComponent<gameOver>().over();
        }
    }
}
