using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BallController : MonoBehaviour

{
  Rigidbody2D myRb;
  bool setspeed;

  [SerializeField] float speedup;

  float yspeed;

  float xspeed;

  private AudioSource audioSource;






  // Start is called before the first frame update
  void Start()
  {
    myRb = GetComponent<Rigidbody2D>();
    audioSource = GetComponent<AudioSource>();
  }



  // Update is called once per frame
  void Update()
  {


    //   if(GameController.instance.inPlay == true)
    //   {
    if (!setspeed)
    {
      setspeed = true;

      xspeed = Random.Range(4f, 5f) * (Random.Range(1, 2) * 2 - 1);
      yspeed = Random.Range(4f, 5f) * (Random.Range(1, 2) * 2 - 1);
    }


    MoveBall();


    // }

  }

  void MoveBall()
  {
    myRb.velocity = new Vector2(xspeed, yspeed);
  }


  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.transform.tag == "Wall")
    {
      yspeed = yspeed * -1.13f;

    }

    if (other.transform.tag == "Paddle")
    {
      audioSource.Play();
      xspeed = xspeed * -1.22f;

      if (yspeed > 0)
      {
        xspeed += speedup;
      }

      else
      {
        xspeed -= speedup;
      }


      if (yspeed > 0)
      {
        yspeed += speedup;
      }
      else
      {
        yspeed -= speedup;
      }
    }
  }





  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "EndOne")
    {
      GameController.instance.scoreOne++;
      GameController.instance.textOne.text = GameController.instance.scoreOne.ToString();
      GameController.instance.inPlay = false;
      myRb.velocity = Vector2.zero;
      setspeed = false;
      this.transform.position = Vector2.zero;


    }
    else if (other.tag == "EndTwo")
    {
      GameController.instance.scoreTwo++;
      GameController.instance.textTwo.text = GameController.instance.scoreTwo.ToString();
      GameController.instance.inPlay = false;
      myRb.velocity = Vector2.zero;
      setspeed = false;
      this.transform.position = Vector2.zero;
    }



  }



}
