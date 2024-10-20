using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLogic : MonoBehaviour
{
    public int health = 1;
    void Start()
    {
        GameManager.instance.BlockModify(this);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ball")
        {
            if (health > 1)
            {
                GameManager.instance.OnBlockHit();
                health--;
            }
            else
            {
                GameManager.instance.OnBlockDestroy();
                Destroy(gameObject);
            }
            switch (health)
            {
                case 1:
                    GetComponent<SpriteRenderer>().color = Color.white;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = Color.grey;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().color = Color.magenta;
                    break;
                case 6:
                    GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;
                case 7:
                    GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case 8:
                    GetComponent<SpriteRenderer>().color = Color.black;
                    break;
            }
            
        }
    }
}
