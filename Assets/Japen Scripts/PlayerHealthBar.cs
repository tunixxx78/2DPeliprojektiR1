﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject deathParticle, player;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.gameObject.SetActive(false);
        StartCoroutine(LateCall());
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(3f);

        healthBar.gameObject.SetActive(false);
    }


    void Update()
    {
        if (currentHealth <= 0f)
        {
            deathParticle.SetActive(true);
            player.SetActive(false);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            FindObjectOfType<GameManager>().ZeroHealth();

        }
    }

    void GainHealth(int healing)
    {
        currentHealth += healing;
        healthBar.SetHealth(currentHealth);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TrapAmmo"))
        {
            TakeDamage(10);
            healthBar.gameObject.SetActive(true);
            StartCoroutine(LateCall());

        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(20);

            healthBar.gameObject.SetActive(true);
            StartCoroutine(LateCall());
        }
        else if (collision.collider.CompareTag("SpikeTrap"))
        {
            TakeDamage(10);
            healthBar.gameObject.SetActive(true);
            StartCoroutine(LateCall());
        }
        else if (collision.collider.CompareTag("Collectible"))
        {
            GainHealth(20);
            healthBar.gameObject.SetActive(true);
            StartCoroutine(LateCall());
        }
        else
        {
            return;
        }



    }
}
