using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    
    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float number)
    {
        currentHealth -= number;
        healthBar.SetHealth(currentHealth);
    }
}
