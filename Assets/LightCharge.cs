using UnityEngine;

public class LightCharge : MonoBehaviour
{
    [SerializeField] private float currentCharge;
    [SerializeField] private float maxCharge = 100;
    [SerializeField] private float decrease = 0.5f;
    void Start()
    {
        currentCharge = maxCharge;
    }

    void Update()
    {
        currentCharge -= decrease*Time.deltaTime;
    }

    public void ChargeUp()
    {
        currentCharge = maxCharge;
    }
}
