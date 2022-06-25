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

    public void TakeDamage(int number)
    {
        currentHealth -= number;
        healthBar.SetHealth(currentHealth);
    }
}
