using UnityEngine;
using Assets.Assets.Scripts;

public class BubbleBullet : MonoBehaviour
{
    private GameObject player;
    public float speed;

    private void Awake()
    {
        player = GameObject.Find("Player");
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
    
    void Die()
    {
        Destroy(gameObject);
    }
}
