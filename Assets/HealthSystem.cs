using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    public bool isDead = false;
    private GameOverScript gameOverScript;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }

    void Start()
    {
        CurrentHealth = maxHealth;
        if (healthBar != null) healthBar.SetMaxHealth(maxHealth);
        gameOverScript = GetComponent<GameOverScript>();
    }

    public void TakeDamage(float number)
    {
        if (currentHealth > 0)
        {
            CurrentHealth -= number;
            if(healthBar != null) healthBar.SetHealth(CurrentHealth);
        }

        if (currentHealth <= 0)
        {
            isDead = true;

            if (gameObject.CompareTag("Player"))
            {
                gameOverScript.YouDied();
            }
        }
    }
}