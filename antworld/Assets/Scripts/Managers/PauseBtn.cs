using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gamePanel;

    [SerializeField]
    private Text countAntGame, countAntPause, countFoodGame, countFoodPause;

    public void setPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        gamePanel.SetActive(false);
        countAntPause.text = countAntGame.text;
        countFoodPause.text = countFoodGame.text;
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void setContinue()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
