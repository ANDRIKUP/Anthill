using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToAnthill : MonoBehaviour
{
    private Vector3 anthillPosition;
    public float speed = 1f;

    checkAttacked myself;
    void Start()
    {
        anthillPosition = HomeReturn.home;
        myself = GetComponent<checkAttacked>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!myself.isAttacked())
        {
            transform.position = Vector3.MoveTowards(transform.position, anthillPosition, speed * Time.deltaTime);
        }
    }
}
