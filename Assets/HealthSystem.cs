using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    
    [SerializeField]
    private float maxHealth = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int number)
    {
        currentHealth -= number;
    }
}
