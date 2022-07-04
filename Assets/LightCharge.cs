using UnityEngine;

public class LightCharge : MonoBehaviour
{
    public float currentCharge;
    [SerializeField] private float maxCharge = 100;
    [SerializeField] private float decrease = 1;
    [SerializeField] private HealthBar healthBar;
    private LightController lightController;

    void Start()
    {
        currentCharge = maxCharge;
        healthBar.SetMaxHealth(maxCharge);
        lightController = GetComponent<LightController>();
    }

    void Update()
    {
        if (currentCharge > 0)
        {
            currentCharge -= decrease * Time.deltaTime;
            healthBar.SetHealth(currentCharge);
        }

        if (currentCharge <= 0)
        {
            lightController.KillLights();
        }
    }

    public void ChargeUp()
    {
        currentCharge = maxCharge;
        healthBar.SetHealth(currentCharge);
        lightController.Relight();
    }

    public void DecreaseFromHit()
    {
        currentCharge = 0;
        healthBar.SetHealth(currentCharge);
        lightController.KillLights();
    }
}