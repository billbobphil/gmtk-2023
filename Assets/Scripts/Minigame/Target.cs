using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Minigame
{
    public class Target : MonoBehaviour
    {

        public int health = 1;
        private int currentHealth;
        [SerializeField] private HealthBar healthBar;
        public AudioSource audioSource;

        private void Awake()
        {
            currentHealth = health;
            healthBar.UpdateHealthBar(health, currentHealth);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Wave"))
            {
                Fireable wave = other.GetComponent<Fireable>();
                int damage = wave.damage.GetDamage();
                currentHealth -= damage;
                audioSource.Play();
                wave.ResetObject();
                healthBar.UpdateHealthBar(health, currentHealth);
                if (currentHealth <= 0)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
