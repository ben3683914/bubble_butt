using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public ParticleSystem healthFart;
        public GameObject primaryWeapon;
        public GameObject upgradedWeapon;

        public bool upgraded;
        public int maxHealth;
        public int health;

        private float attackTime = 0;
        private GameObject CurrentWeapon;

        private float healthPercent { get { return ((float)health / (float)maxHealth) * 100f; } }

        private void Awake()
        {
            health = maxHealth;
            CurrentWeapon = primaryWeapon;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                TakeHit();

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

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Shoot(true);
            }
            else if (Input.GetKey(KeyCode.Return))
            {
                Shoot();
            }
        }

        public void TakeHit()
        {
            health--;

            if (health <= 0)
                Die();
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

        public void DisableHealth()
        {
            healthFart.gameObject.SetActive(false);
        }

        public void Shoot(bool shootOnce = false)
        {
            if (attackTime > CurrentWeapon.GetComponent<Projectile>().fireRate || shootOnce)
            {
                Debug.Log("shoot");
                var clone = Instantiate(CurrentWeapon, transform.position, Quaternion.identity);
                clone.GetComponent<Projectile>().flipped = transform.localScale.x < 0;
                attackTime = 0;
            }

            attackTime += Time.deltaTime;
        }
    }
}