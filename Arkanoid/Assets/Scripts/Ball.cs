using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform ballSpawnPos;
    [SerializeField] Rigidbody2D rigidBody;
    Vector3 originalSize;
    [SerializeField] Transform canvas;
    bool followPlayer;
    void Start()
    {
        originalSize = transform.lossyScale;
        followPlayer = true;
        Invoke("ballStart", 2);
    }

    private void Update()
    {
        if (followPlayer)
        {
            transform.position = ballSpawnPos.position;
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            transform.localScale = new Vector3(40,40,40);
            //transform.SetParent(player);
            transform.localPosition = ballSpawnPos.position;
            rigidBody.velocity = Vector2.zero;
            GameManager.instance.LoseLive();
            followPlayer = true;
            Invoke("ballStart", 2);
        }else
        {
            SoundManager.instance.PlaySound(SoundManager.instance.bounceSound);
        }

        if (collision.gameObject.tag == "Player")
        {
            float velocity = rigidBody.velocity.magnitude;
            float hitPoint = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
            Vector2 direction = new Vector2(hitPoint, 1).normalized;
            if (GameManager.instance.autoPlay)
            {
                direction.x = Random.Range(-1f,1f);
            }
            rigidBody.velocity = direction * velocity;
        }
        rigidBody.velocity *= 1.03f;
      
        //limit rigidBody velocity
        if (rigidBody.velocity.magnitude > 8)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * 8;
        }
    }
    void ballStart()
    {

        rigidBody.velocity = new Vector2(1, 4);
        //transform.SetParent(canvas);
        followPlayer = false;
    }
}
