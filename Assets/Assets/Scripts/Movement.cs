using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //COMPONENT REFERENCES===========
    Animator animator;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    BoxCollider2D collider;

    //MOVEMENT VARIABLES=============
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !jumping)
        {
            jumping = true;
            jumpTime = 0;
        }

        if (jumping)
        {
            rigidbody.AddForce(Vector2.up * jumpAmount);
            jumpTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
        var hit = Physics2D.Raycast(new Vector2(transform.position.x, collider.bounds.min.y -.01f), Vector2.down, .1f);
        if (hit)
        {
            Debug.Log($"{hit.collider.gameObject.name}:{collider.bounds.ToString()}:{collider.bounds.min.ToString()}");
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
