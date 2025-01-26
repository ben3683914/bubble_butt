using Assets.Assets.Scripts.Helpers;
using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        
        public float fireRate = 1f;
        public bool flipped;
        public Projectile projectile;

        private float attackTime = 0;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Shoot(bool shootOnce = false)
        {
            if (attackTime > fireRate || shootOnce)
            {
                var playerDirection = GameManager.Instance.PlayerManager.direction;
                var clone = Instantiate(projectile, transform.position, Quaternion.identity);
                clone.direction = flipped ? reverseDirection(playerDirection) : playerDirection;
                attackTime = 0;
            }

            attackTime += Time.deltaTime;
        }

        private Direction reverseDirection(Direction direction)
        {
            if (direction == Direction.Right)
            {
                return Direction.Left;
            }
            else
            {
                return Direction.Right;
            }
        }
    }
}