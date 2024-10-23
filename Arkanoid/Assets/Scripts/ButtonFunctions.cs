using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.score = 0;
        GameManager.instance.lives = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void StartGameAutoplay()
    {
        GameManager.instance.score = 0;
        GameManager.instance.lives = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        GameManager.instance.autoPlay = true;
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("Level1");
        }
    }
    public void AutoPlay()
    {
        GameManager.instance.score = 0;
        GameManager.instance.lives = 3;
        GameManager.instance.autoPlay = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void SaveAndExit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
