using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.instance.score = 0;
        GameManager.instance.lives = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void Continue()
    {

    }
    public void AutoPlay()
    {
        GameManager.instance.score = 0;
        GameManager.instance.lives = 3;
        GameManager.instance.autoPlay = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
