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


    [SerializeField] GameObject soundManager;
    void Awake()
    {
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
        block.health = Random.Range(1, 1);
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
        
        if (Random.Range(0, 100) < 70)
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
            GameManager.instance.isPaused = true;
        }
    }
    public void OnBlockHit()
    {
        score += 10;
    }
    public void LoseLive()
    {
        lives--;
        if (lives == 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            GameManager.instance.isPaused = true;
        }
    }
 
}
