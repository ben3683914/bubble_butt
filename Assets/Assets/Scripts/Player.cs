using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public ParticleSystem healthFart;
        public int maxHealth;
        public int health;
        private float healthPercent { get {  return ((float)health/(float)maxHealth)*100f; } }

        private void Awake()
        {
            health = maxHealth;
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

            if(healthPercent < 10)
            {
                Debug.Log($"50: {healthPercent}");
                SetHealthColor(Color.black);
            }
            else if(healthPercent < 25f)
            {
                Debug.Log($"25: {healthPercent}");
                SetHealthColor(Color.red);
            }
            else if(healthPercent < 50f)
            {
                Debug.Log($"10: {healthPercent}");
                SetHealthColor(Color.yellow);
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
    }
}