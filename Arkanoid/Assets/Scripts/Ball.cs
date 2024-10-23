using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D rigidBody;
    Vector3 originalSize;
    [SerializeField] Transform canvas;
    void Start()
    {
        originalSize = transform.lossyScale;
        Invoke("ballStart", 2);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            //transform.localScale = originalSize;
            transform.SetParent(player);
            transform.localPosition = new Vector3(0.00563721033f, 1.92999995f, -68.4346924f);
            rigidBody.velocity = Vector2.zero;
            GameManager.instance.LoseLive();
            Invoke("ballStart", 2);
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
        rigidBody.velocity *= 1.05f;
        //limit rigidBody velocity
        if (rigidBody.velocity.magnitude > 17)
        {
            rigidBody.velocity = rigidBody.velocity.normalized * 17;
        }
    }
    void ballStart()
    {

        rigidBody.velocity = new Vector2(1, 4);
        transform.SetParent(canvas);

    }
}
