﻿using System.Collections;
using UnityEngine;

namespace Assets.Assets.Scripts
{
    public class UpgradeBubbles : MonoBehaviour
    {
        private GameObject player;
        public float speed;

        public bool seekPlayer;
        public AudioClip wakeSound;
        public AudioClip slurpSound;
        private AudioSource audioSource;

        private void Awake()
        {
            player = GameObject.Find("Player");
            audioSource = player.GetComponent<AudioSource>();
            audioSource.PlayOneShot(wakeSound);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.TryGetComponent<Player>(out Player player))
            {
                player.TakeEnergy(1);
                Die();
            }

        }

        void FixedUpdate()
        {
            if (seekPlayer)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
            }
        }

        // Update is called once per frame
        void Die()
        {
            Destroy(gameObject);
        }

        public void Activate()
        {
            audioSource.PlayOneShot(slurpSound);
            seekPlayer = true;
        }
    }
}