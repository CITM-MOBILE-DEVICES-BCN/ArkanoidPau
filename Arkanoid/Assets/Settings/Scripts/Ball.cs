using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody2D rigidBody;
    void Start()
    {
        Invoke("ballStart", 2);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            transform.parent = player;
            transform.localPosition = new Vector3(0.0116618071f, 1.4999994f, 0);
            rigidBody.velocity = Vector2.zero;
            GameManager.instance.LoseLive();
            Invoke("ballStart", 2);
        }

        if (collision.gameObject.tag == "Player")
        {
            float hitPoint = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
            Vector2 direction = new Vector2(hitPoint, 1).normalized;
            rigidBody.velocity = direction * 7;
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

        rigidBody.velocity = new Vector2(0, -2);
        transform.SetParent(null);

    }
}
