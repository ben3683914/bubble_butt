using UnityEngine;
using Assets.Assets.Scripts;
using System.Collections;

public class BubbleBullet : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float lifetime;
    public int damage;
    public AudioClip dieSound;
    public AudioClip wakeSound;
    private AudioSource audioSource;

    private void Awake()
    {
        player = GameObject.Find("Player");
        lifetime = Random.Range(lifetime - (lifetime/3), lifetime+(lifetime/3));
        StartCoroutine(DieOverTime());
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(wakeSound);
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player)) {
            player.TakeHit(damage);
            Die();
        }
    }
    
    public void Die()
    {
        audioSource.PlayOneShot(dieSound);
        Destroy(gameObject);
    }

    IEnumerator DieOverTime()
    {
        yield return new WaitForSeconds(lifetime);
        Die();
    }
}
