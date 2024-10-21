using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

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
                    GetComponent<SpriteRenderer>().color = Color.gray;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().color = Color.black;
                    break;
            }
            
        }
    }
}
