using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addAnts : MonoBehaviour
{
    public GameObject antScout;
    void Update()
    {
       if (Input.GetKeyUp(KeyCode.Q))
        {
            Vector3 vec = Vector3.zero;
            Instantiate(antScout, vec, Quaternion.Euler(Vector3.zero));
        } 
    }
}
