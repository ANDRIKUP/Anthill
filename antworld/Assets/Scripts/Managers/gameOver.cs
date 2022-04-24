using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    [SerializeField]
    private float speedCam;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private GameObject overPanel;

    [SerializeField]
    private Text countAntGame, countAntOver, countFoodGame, countFoodOver;

    public void over()
    {
        Time.timeScale = 0;
        gamePanel.SetActive(false);
        overPanel.SetActive(true); 
        countAntOver.text = countAntGame.text;
        countFoodOver.text = countFoodGame.text;
        cam.GetComponent<cameraMovement>().enabled = false;
        cam.transform.position = new Vector3(0, 0, -10);
    }

    public void tryAgain()
    {
        Time.timeScale = 1;
        cam.GetComponent<cameraMovement>().enabled = true;
        SceneManager.LoadScene(1);
    }

}
