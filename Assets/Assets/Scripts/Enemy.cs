using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
