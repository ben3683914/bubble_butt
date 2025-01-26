using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public ParticleSystem healthFart;
        public SpriteRenderer spriteRenderer;
        public Weapon primaryWeapon;
        public Weapon upgradedWeapon;
        public AudioClip hitSound;
        private AudioSource audioSource;

        public bool upgraded;
        public int maxHealth;
        public int health;
        public int energyNeeded;


        private float healthPercent { get { return ((float)health / (float)maxHealth) * 100f; } }

        private void Awake()
        {
            health = maxHealth;
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            audioSource = this.GetComponent<AudioSource>();
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

            if (Input.GetKeyDown(KeyCode.E))
            {
                primaryWeapon.Shoot(true);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                primaryWeapon.Shoot();
            }

            if (upgraded)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    upgradedWeapon.Shoot(true);
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    upgradedWeapon.Shoot();
                }
            }

            ActivateUpgradeBubbles();

        }

        public void TakeHit(int damage)
        {
            if(TryGetComponent<FlashColor>(out FlashColor flash))
            {
                flash.Do();
                audioSource.PlayOneShot(hitSound);
            }

            health -= damage;

            if (health <= 0)
                Die();
        }

        private void ActivateUpgradeBubbles()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, spriteRenderer.bounds.size.x * 2);
            var upgradeBubbles = hitColliders.Select(x => x.GetComponent<UpgradeBubbles>()).Where(x => x != null && !x.seekPlayer);

            foreach (UpgradeBubbles upgradeBubble in upgradeBubbles)
            {
                upgradeBubble.Activate();
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
            GameManager.Instance.MenuManager.GameOver();
        }

        public void DisableHealth()
        {
            healthFart.gameObject.SetActive(false);
        }

        public void TakeEnergy(int energy)
        {
            energyNeeded -= energy;

            if (energyNeeded <= 0 && !upgraded)
            {
                Debug.Log("upgrade");
                upgraded = true;
                GameManager.Instance.UIManager.Upgrade();
            }
        }


    }
}