using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rigidbody;
        SpriteRenderer spriteRenderer;


        public int speed = 15;
        public bool flipped;
        public float lifetime = 2f;
        public float fireRate = 1f;
        void Start()
        {
            rigidbody = this.GetComponent<Rigidbody2D>();
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = flipped;
        }

        void FixedUpdate()
        {
            rigidbody.linearVelocityX = flipped ? -speed : speed;
            lifetime -= Time.deltaTime;

            if ( lifetime < 0)
            {
                Die();
            }

        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.name);
            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}