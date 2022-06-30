using System;
using UnityEngine;
using UnityEngine.AI;

public class AIanimationController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking;
    private NavMeshAgent _agent;


    private void Start()
    {
        animator = GetComponent<Animator>();
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        isWalking = _agent.velocity.magnitude > 0.15f;

        animator.SetBool("isWalking", isWalking);
    }
}