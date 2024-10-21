using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    int blockCount = 0;
    public int score = 0;
    public int lives = 3;
    public static GameManager instance;

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
        blockCount++;
    }

    public void OnBlockDestroy()
    {
        score += 100;
        blockCount--;
        if (blockCount == 0)
        {
            Debug.Log("You Win!");
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
            Debug.Log("Game Over!");
        }
    }
}
