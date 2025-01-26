using Assets.Assets.Scripts.Helpers;
using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        Rigidbody2D rigidbody;
        SpriteRenderer spriteRenderer;


        public int speed = 15;
        public Direction direction;
        public int damage = 1;
        public AudioClip wakeSound;
        private AudioSource audioSource;

        private float lifetime;
        private void Awake()
        {
            lifetime = Random.Range(2f, 3f);
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(wakeSound);
            StartCoroutine(DieOverTime());
            
        }

        void Start()
        {
            rigidbody = this.GetComponent<Rigidbody2D>();
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = direction == Direction.Left;
        }

        void FixedUpdate()
        {
            rigidbody.linearVelocityX = direction == Direction.Left ? -speed : speed;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeHit(damage);
            }
            else if (collision.gameObject.TryGetComponent<BubbleBullet>(out BubbleBullet bullet))
            {
                bullet.Die();
            }
            else if (collision.gameObject.TryGetComponent<Boss>(out Boss boss))
            {
                boss.TakeHit(damage);
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