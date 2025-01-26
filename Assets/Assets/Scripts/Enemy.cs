using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject tinyBubble;
    public GameObject bubbleBullet;

    public int Health = 10;
    private float shootInterval = 0f;
    private float shootTimer = 0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootInterval = Random.Range(3f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer > shootInterval)
        {
            Instantiate(bubbleBullet, transform.position, Quaternion.identity);
            Debug.Log("shot fired");
            shootInterval = Random.Range(3f, 3f);
            shootTimer = 0f;
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
