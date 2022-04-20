using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToAnthill : MonoBehaviour
{
    private Vector3 anthillPosition;
    public float speed = 1f;
    void Start()
    {
        anthillPosition = HomeReturn.home;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, anthillPosition, speed * Time.deltaTime);
    }
}
