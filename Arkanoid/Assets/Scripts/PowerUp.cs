using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<PlayerController>().ball.parent.name == "GamePlay" && collision.gameObject.GetComponent<PlayerController>().ball.localScale.x < 70)
            {
                collision.gameObject.GetComponent<PlayerController>().ball.localScale *= 1.3f;
            }
           
            Destroy(gameObject);
        }
    }
    
}
