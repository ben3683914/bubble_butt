using UnityEngine;

public class Boss : MonoBehaviour
{
    public ParticleSystem healthFart;
    public int maxHealth;
    public int health;
    public AudioClip hitSound;
    public AudioClip dieSound;
    private AudioSource audioSource;

    private float healthPercent { get { return ((float)health / (float)maxHealth) * 100f; } }

    private void Awake()
    {
        health = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (healthPercent < 10)
        {
            Debug.Log($"50: {healthPercent}");
            SetHealthColor(Color.black);
        }
        else if (healthPercent < 25f)
        {
            Debug.Log($"25: {healthPercent}");
            SetHealthColor(Color.red);
        }
        else if (healthPercent < 50f)
        {
            Debug.Log($"10: {healthPercent}");
            SetHealthColor(Color.yellow);
        }
    }

    public void TakeHit(int damage)
    {
        if (TryGetComponent<FlashColor>(out FlashColor flash))
            flash.Do();

        health -= damage;
        audioSource.PlayOneShot(hitSound);

        if (health <= 0)
        {
            Die();
            audioSource.PlayOneShot(dieSound);
        }
    }

    void SetHealthColor(Color color)
    {
        var main = healthFart.main;
        main.startColor = color;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
