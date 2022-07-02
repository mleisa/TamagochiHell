﻿using UnityEngine;
using UnityEngine.AI;

public class AIanimationController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking;
    public bool canAttack = false;
    private NavMeshAgent _agent;
    [SerializeField] private FieldOfHearing fieldOfHearing;


    private void Start()
    {
        animator = GetComponent<Animator>();
        _agent = GetComponentInParent<NavMeshAgent>();
        fieldOfHearing = GetComponentInParent<FieldOfHearing>();
    }

    private void Update()
    {
        isWalking = _agent.velocity.magnitude > 0.15f;
        animator.SetBool("isWalking", isWalking);
        
        animator.SetBool("canAttack", canAttack);

    }
}