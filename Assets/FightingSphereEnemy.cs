using System;
using System.Collections;
using UnityEngine;

public class FightingSphereEnemy : MonoBehaviour
{
    [SerializeField] private HealthSystem playerHealth;
    private Coroutine coroutineFighting;
    [SerializeField] private AIanimationController AIanimationController;
    private HealthSystem ownHealth;

    private void Start()
    {
        AIanimationController = GetComponentInChildren<AIanimationController>();
        ownHealth = GetComponentInParent<HealthSystem>();
    }

    IEnumerator Attack(float delay)
    {
        while (playerHealth != null)
        {
            if (ownHealth.isDead)
            {
                break;
            }
            
            yield return new WaitForSeconds(delay);

            Debug.Log("Take That");
            playerHealth.TakeDamage(10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<HealthSystem>();
            AIanimationController.canAttack = true;
            coroutineFighting = StartCoroutine(Attack(0.5f));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !ownHealth.isDead)
        {
            playerHealth = null;
            AIanimationController.canAttack = false;
            StopCoroutine(coroutineFighting);
        }
    }
}