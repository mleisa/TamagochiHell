using UnityEngine;

public class LightCharge : MonoBehaviour
{
    [SerializeField] private float currentCharge;
    [SerializeField] private float maxCharge = 100;
    [SerializeField] private float decrease = 1;
    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentCharge = maxCharge;
        healthBar.SetMaxHealth(maxCharge);
    }

    void Update()
    {
        if (currentCharge > 0)
        {
            currentCharge -= decrease * Time.deltaTime;
            healthBar.SetHealth(currentCharge);
        }
    }

    public void ChargeUp()
    {
        currentCharge = maxCharge;
        healthBar.SetHealth(currentCharge);
    }
}