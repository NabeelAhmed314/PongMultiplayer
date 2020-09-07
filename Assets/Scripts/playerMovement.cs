using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10f;
    float movement = 0f;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > 200)
            {
                movement = Input.touchCount;
            }
            else
            {
                movement = -Input.touchCount;
            }
        }
        else
        {
            movement = 0;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, movement * speed);
    }
}
