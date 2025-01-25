using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //COMPONENT REFERENCES===========
    Animator animator;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    //MOVEMENT VARIABLES=============
    public int speed = 5;

    public float buttonTime = 0.3f;
    public float jumpAmount = 20f;
    float jumpTime;
    bool jumping;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        var velocity = 0;
        //HORIZONTAL MOVEMENT=============
        if (Input.GetKey(KeyCode.A))
        {
            velocity = -speed;
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity = speed;
            spriteRenderer.flipX = false;
        }
        else
        {
            if (velocity != 0)
                velocity = 0;
        }

        rigidbody.linearVelocityX = velocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(jumpAmount);
            rigidbody.AddForce(Vector2.up * jumpAmount);
        }

    }

}
