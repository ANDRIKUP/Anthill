using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUpgradePanel : MonoBehaviour
{
    private GameObject shopFrame;
    void Awake()
    {
        shopFrame = GameObject.Find("shopFrame");
        shopFrame.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (!shopFrame.activeSelf)
        {
            shopFrame.SetActive(true);
        }
        else
        {
            shopFrame.SetActive(false);
        }
    }
}
