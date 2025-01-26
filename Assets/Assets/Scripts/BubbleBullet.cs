using UnityEngine;
using Assets.Assets.Scripts;
using System.Collections;

public class BubbleBullet : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private float lifetime;

    private void Awake()
    {
        player = GameObject.Find("Player");
        lifetime = Random.Range(5f, 10f);
        StartCoroutine(DieOverTime());
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().TakeHit();
        Die();
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator DieOverTime()
    {
        yield return new WaitForSeconds(lifetime);
        Die();
    }
}
