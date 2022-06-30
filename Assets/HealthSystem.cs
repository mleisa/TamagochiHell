using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    
    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private HealthBar healthBar;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    void Start()
    {
        CurrentHealth = maxHealth;
        if (healthBar != null) healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float number)
    {
        CurrentHealth -= number;
        if(healthBar != null) healthBar.SetHealth(CurrentHealth);
    }
}
