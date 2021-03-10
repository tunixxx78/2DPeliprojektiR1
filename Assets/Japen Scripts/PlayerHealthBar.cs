﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }*/
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
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
        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
        else if (collision.collider.CompareTag("SpikeTrap"))
        {
            TakeDamage(10);
        }
        else if (collision.collider.CompareTag("Collectible"))
        {
            GainHealth(20);
        }
        else
        {
            return;
        }

       
        
    }
}
