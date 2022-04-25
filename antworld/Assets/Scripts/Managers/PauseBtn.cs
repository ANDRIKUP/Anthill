using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject trigerShopPanel;
    [SerializeField]
    private GameObject shopPanel;

    [SerializeField]
    private Text countAntGame, countAntPause, countFoodGame, countFoodPause;

    public void setPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
        countAntPause.text = countAntGame.text;
        countFoodPause.text = countFoodGame.text;
        cam.GetComponent<cameraMovement>().enabled = false;
        trigerShopPanel.SetActive(false);
        if (shopPanel.activeSelf) shopPanel.SetActive(false);
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        cam.GetComponent<cameraMovement>().enabled = true;
        trigerShopPanel.SetActive(true);
        SceneManager.LoadScene(0);
    }

    public void setContinue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        cam.GetComponent<cameraMovement>().enabled = true;
        trigerShopPanel.SetActive(true);
    }
}
