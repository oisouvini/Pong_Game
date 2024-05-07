using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    Rigidbody2D rb2d;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Invoke("GoBall", 2);
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(30, -20));
        }
        else
        {
            rb2d.AddForce(new Vector2(-30, -20));
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            audioSource.Play();
            Vector2 vel;
            vel.x = rb2d.velocity.x * 1.4f;
            vel.y = (rb2d.velocity.y - 1) + (coll.collider.attachedRigidbody.velocity.y - 1);
            rb2d.velocity = vel;
        }




    }


}




