using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int number)
    {
        currentHealth -= number;
        healthBar.SetHealth(currentHealth);
    }
}
