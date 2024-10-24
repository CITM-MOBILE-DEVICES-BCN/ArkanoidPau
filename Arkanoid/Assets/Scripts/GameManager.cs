using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    int blockCount = 0;
    public int score = 0;
    public int lives = 3;
    public static GameManager instance;
    public bool autoPlay = false;
    public bool isPaused = false;
    public GameObject winScreen;
    public GameObject loseScreen;

    public SaveLoad saveLoad;
    public float highScore;

    void Awake()
    {
        saveLoad = new SaveLoad();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void BlockModify(BlockLogic block)
    {
        block.health = Random.Range(1, 4);
        switch (block.health)
        {
            case 1:
                block.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case 2:
                block.GetComponent<SpriteRenderer>().color = Color.gray;
                break;
            case 3:
                block.GetComponent<SpriteRenderer>().color = Color.black;
                break;
        }
        
        if (Random.Range(0, 100) < 20)
        {
            block.powerUpBlock = true;
        }
        else
        {
            block.powerUpBlock = false;
        }

        blockCount++;
    }

    public void OnBlockDestroy()
    {
        score += 100;
        blockCount--;
        if (blockCount == 0)
        {

            Time.timeScale = 0;
            winScreen.SetActive(true);
            SoundManager.instance.PlaySound(SoundManager.instance.levelComplete);
            GameManager.instance.isPaused = true;
        }
    }
    public void OnBlockHit()
    {
        score += 50;
        if (score > highScore)
        {
            highScore = score;
        }
    }
    public void LoseLive()
    {
        lives--;
        SoundManager.instance.PlaySound(SoundManager.instance.loseLife);
        if (lives == 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            GameManager.instance.isPaused = true;
            GameManager.instance.saveLoad.Reload();
            SoundManager.instance.PlaySound(SoundManager.instance.gameOver);
        }
    }
 
}
