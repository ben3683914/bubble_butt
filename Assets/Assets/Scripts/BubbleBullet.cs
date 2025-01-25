using UnityEngine;

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
}
