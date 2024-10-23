using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad
{
    public void Save(string level)
    {
        PlayerPrefs.SetInt("score", GameManager.instance.score);
        PlayerPrefs.SetInt("lives", GameManager.instance.lives);
        PlayerPrefs.SetString("scene", level);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        GameManager.instance.score = PlayerPrefs.GetInt("score");
        GameManager.instance.lives = PlayerPrefs.GetInt("lives");
        SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
    }
    public void Reload()
    {
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("lives");
        PlayerPrefs.DeleteKey("scene");
    }
    public void HighScore()
    {
        PlayerPrefs.SetFloat("highScore", GameManager.instance.highScore);
    }
}
