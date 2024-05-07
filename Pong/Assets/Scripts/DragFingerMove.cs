using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerMove : MonoBehaviour
{

    private Vector3 touchPosition;
    private Rigidbody2D rB;

    private Vector3 direction;

    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rB.velocity = new Vector2(direction.x,direction.y) * moveSpeed;

            if (touch.phase == TouchPhase.Ended)
             rB.velocity = Vector2.zero;
        }
    }
}
