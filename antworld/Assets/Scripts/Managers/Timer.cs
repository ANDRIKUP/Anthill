using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text clockTxt;
    private static float timePassed = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        translateTime();
    }

    public static void settimePassed()
    {
        timePassed = Time.time;
    }

    private void translateTime()
    {
        int min = (int)(Time.time - timePassed) / 60;
        int sec = (int)(Time.time - timePassed) % 60;
        string time = "";
        if (min < 10)
        {
            time += "0";
        }
        time += min.ToString() + " : ";
        if (sec < 10)
        {
            time += "0";
        }
        time += sec.ToString();
        clockTxt.text = time;
    }
}
