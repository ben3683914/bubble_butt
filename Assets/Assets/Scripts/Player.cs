using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public int maxHealth;
        public int health;

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
        }

        public void TakeHit()
        {
            health--;

            if (health <= 0)
                Die();
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}