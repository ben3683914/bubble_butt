﻿using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rigidbody;
        SpriteRenderer spriteRenderer;


        public int speed = 15;
        public bool flipped;
        public float fireRate = 1f;
        public int damage = 1;

        private float lifetime;
        private void Awake()
        {
            lifetime = Random.Range(2f, 3f);
            StartCoroutine(DieOverTime());
        }

        void Start()
        {
            rigidbody = this.GetComponent<Rigidbody2D>();
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = flipped;
        }

        void FixedUpdate()
        {
            rigidbody.linearVelocityX = flipped ? -speed : speed;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.name);

            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeHit(damage);
            }
            else if (collision.gameObject.TryGetComponent<BubbleBullet>(out BubbleBullet bullet))
            {
                bullet.Die();
            }

            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }

        IEnumerator DieOverTime()
        {
            yield return new WaitForSeconds(lifetime);
            Die();
        }
    }
}