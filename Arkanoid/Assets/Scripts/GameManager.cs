using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    int blockCount = 0;
    int score = 0;
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
        block.health = Random.Range(1, 8);
        switch (block.health)
        {
            case 1:
                block.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                block.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 3:
                block.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case 4:
                block.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 5:
                block.GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case 6:
                block.GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            case 7:
                block.GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case 8:
                block.GetComponent<SpriteRenderer>().color = Color.white;
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
}
