using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public ParticleSystem healthFart;
        public SpriteRenderer spriteRenderer;
        public Projectile primaryWeapon;
        public Projectile upgradedWeapon;

        public bool upgraded;
        public int maxHealth;
        public int health;
        public int energyNeeded;

        private float attackTime = 0;
        private Projectile CurrentWeapon;

        private float healthPercent { get { return ((float)health / (float)maxHealth) * 100f; } }

        private void Awake()
        {
            health = maxHealth;
            CurrentWeapon = primaryWeapon;
            spriteRenderer = this.GetComponent<SpriteRenderer>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot(true);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }

            ActivateUpgradeBubbles();

            CurrentWeapon = upgraded ? upgradedWeapon : primaryWeapon;
        }

        public void TakeHit(int damage)
        {
            if(TryGetComponent<FlashColor>(out FlashColor flash))
                flash.Do();

            health -= damage;

            if (health <= 0)
                Die();
        }

        private void ActivateUpgradeBubbles()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, spriteRenderer.bounds.size.x * 2);
            var upgradeBubbles = hitColliders.Select(x => x.GetComponent<UpgradeBubbles>()).Where(x => x != null && !x.seekPlayer);
            
            foreach (UpgradeBubbles upgradeBubble in upgradeBubbles){
                Debug.Log(upgradeBubble.name);
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
        }

        public void DisableHealth()
        {
            healthFart.gameObject.SetActive(false);
        }

        public void TakeEnergy(int energy)
        {
            energyNeeded -= energy;

            if (energyNeeded <= 0)
            {
                upgraded = true;
            }
        }

        public void Shoot(bool shootOnce = false)
        {
            if (attackTime > CurrentWeapon.GetComponent<Projectile>().fireRate || shootOnce)
            {
                Debug.Log("shoot");
                var clone = Instantiate(CurrentWeapon.gameObject, transform.position, Quaternion.identity);
                clone.GetComponent<Projectile>().flipped = transform.localScale.x < 0;
                attackTime = 0;
            }

            attackTime += Time.deltaTime;
        }
    }
}