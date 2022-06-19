using System;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    private bool canHitAgain = true;
    private void OnCollisionEnter(Collision collision)
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
    }
}
