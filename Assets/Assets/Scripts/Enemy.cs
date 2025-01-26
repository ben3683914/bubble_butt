using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject tinyBubble;
    public GameObject bubbleBullet;
    public int Health;

    public void TakeHit(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        var ran = Random.Range(2, 5);
        Debug.Log("im dead, jim");
        for(int i = 0; i < ran; i++)
        {
            Vector2 randomVariance = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            var position = randomVariance + (Vector2)transform.position;

            Instantiate(tinyBubble, position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
