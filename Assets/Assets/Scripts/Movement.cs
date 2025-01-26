using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    BoxCollider2D collider;

    public int speed = 5;

    public float buttonTime = 0.3f;
    public float jumpAmount = 20f;
    float jumpTime;
    bool jumping;
    public bool isGrounded;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<BoxCollider2D>();

    }

    private void Update()
    {
        Vector3 theScale = transform.localScale;

        //HORIZONTAL MOVEMENT=============
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.linearVelocityX = -speed;
            theScale.x = Math.Abs(transform.localScale.x) * -1;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.linearVelocityX = speed;
            theScale.x = Math.Abs(transform.localScale.x) * 1;
        }
        else
        {
            if (rigidbody.linearVelocityX != 0)
                rigidbody.linearVelocityX = 0;
        }

        transform.localScale = theScale;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !jumping)
        {
            jumping = true;
            jumpTime = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }

    }

    void FixedUpdate()
    {
        var hit = Physics2D.Raycast(new Vector2(transform.position.x, collider.bounds.min.y -.01f), Vector2.down, .1f);
        

        if (jumping)
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }

        
        if (hit)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
