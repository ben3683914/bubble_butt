using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public GameObject tinyBubble;
    public GameObject bubbleBullet;
    public int Health;
    public AudioClip wakeSound;
    public AudioClip hitSound;
    public AudioClip dieSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(wakeSound);
    }

    public void TakeHit(int damage)
    {
        Health -= damage;
        audioSource.PlayOneShot(hitSound);

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("im dead, jim");
        StartCoroutine(DropBubbles());
    }

    IEnumerator DropBubbles()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocityX = 0;
        gameObject.GetComponent<Rigidbody2D>().linearVelocityY = 0;

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        var ran = Random.Range(2, 5);
        for (int i = 0; i < ran; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.25f));
            Vector2 randomVariance = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            var position = randomVariance + (Vector2)transform.position;
            Instantiate(tinyBubble, position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
