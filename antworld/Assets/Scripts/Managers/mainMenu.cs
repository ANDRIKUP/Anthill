using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void changeScene(int numberOfScene)
    {
        Timer.settimePassed();
        SceneManager.LoadScene(numberOfScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
