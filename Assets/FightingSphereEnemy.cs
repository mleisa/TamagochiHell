using System;
using System.Collections;
using UnityEngine;

public class FightingSphereEnemy : MonoBehaviour
{
    [SerializeField] private HealthSystem playerHealth;
    private Coroutine coroutineFighting;
    [SerializeField] private AIanimationController AIanimationController;

    private void Start()
    {
        AIanimationController = GetComponentInChildren<AIanimationController>();
    }

    IEnumerator Attack(float delay)
    {
        while (playerHealth != null)
        {
            yield return new WaitForSeconds(delay);
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
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = null;
            AIanimationController.canAttack = false;
            StopCoroutine(coroutineFighting);
        }
    }
}