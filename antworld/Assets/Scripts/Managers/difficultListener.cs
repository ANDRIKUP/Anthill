using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultListener : MonoBehaviour
{
    private threatSpawn thrSp;
    [SerializeField] private Text diffTxt;
    private void Start()
    {
        thrSp = GetComponent<threatSpawn>();
    }
    private void Update()
    {
        if (thrSp.getPeaceTime() > 0)
        {
            diffTxt.text = "0";
        }
        else
        {
            diffTxt.text = thrSp.getDifficult().ToString();
        }
    }
}
