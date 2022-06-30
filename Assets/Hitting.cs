using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    private bool canHitAgain = true;
    [SerializeField] FightingSphere fightingSphere;
    private List<GameObject> deadNarcs;
    [SerializeField]  private float force = 1000;

    private void Awake()
    {
        fightingSphere = gameObject.GetComponentInChildren<FightingSphere>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && canHitAgain)
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

    /*    private void OnCollisionEnter(Collision collision)
        {
            HealthSystem thing = collision.gameObject.GetComponent<HealthSystem>();

            if (thing != null && canHitAgain)
            {
                thing.TakeDamage(10);
                canHitAgain = false;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            HealthSystem thing = other.gameObject.GetComponent<HealthSystem>();
            if (thing != null)
            {
                canHitAgain = true;
            }
        }*/
}
