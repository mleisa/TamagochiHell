using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] FightingSphere fightingSphere;
    [SerializeField] private LightCharge lightCharge;

    private void Awake()
    {
        fightingSphere = gameObject.GetComponentInChildren<FightingSphere>();
        lightCharge = GetComponent<LightCharge>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject narc in fightingSphere.Narcs)
            {
                HealthSystem enemyHealth = narc.GetComponent<HealthSystem>();
                enemyHealth.TakeDamage(100);
                lightCharge.DecreaseFromHit();
            }
        }
    }
}
