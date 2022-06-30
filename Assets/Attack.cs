using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] FightingSphere fightingSphere;
    [SerializeField] private float force = 1000;

    private void Awake()
    {
        fightingSphere = gameObject.GetComponentInChildren<FightingSphere>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (GameObject narc in fightingSphere.Narcs)
            {
                HealthSystem enemyHealth = narc.GetComponent<HealthSystem>();
                enemyHealth.TakeDamage(100);
                if (enemyHealth.CurrentHealth <= 5)
                {
                    //fightingSphere.removeNarc(narc);

                    narc.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));
                    Debug.Log(narc + ": deaaaad");
                }
            }
        }
    }
}
