using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody.velocity = new Vector2(0, -2f);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
}
