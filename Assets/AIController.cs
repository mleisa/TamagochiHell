using System;
using System.Collections;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private AIFollowPathing followPathing;
    [SerializeField] private AIFollow aiFollow;
    private bool isChasing;
    [SerializeField] private FieldOfView fieldOfView;

    private void Start()
    {
        followPathing = GetComponent<AIFollowPathing>();
        aiFollow = GetComponent<AIFollow>();
        fieldOfView = GetComponent<FieldOfView>();

        followPathing.enabled = true;
        isChasing = false;
    }

    private void Update()
    {
        TargetCheckUp();
    }

    public void StartChase()
    {
        if (!isChasing)
        {
            followPathing.enabled = false;
            aiFollow.enabled = true;
            isChasing = true;
        }
    }

    public void StartPatrol()
    {
        if (isChasing)
        {
            aiFollow.enabled = false;
            followPathing.enabled = true;
            isChasing = false;
        }
    }

    private void TargetCheckUp()
    {
        var targets = fieldOfView.visibleTargets;
        bool hasTargets = targets.Count > 0;

        if (hasTargets)
        {
            aiFollow.UpdateTarget(targets[0]);
            StartChase();
        }
        else
        {
            aiFollow.UpdateTarget(null);

            if (isChasing && aiFollow.ReachedDestination())
            {
                StartCoroutine(WaitBeforePatrol());
            }
        }
    }

    IEnumerator WaitBeforePatrol()
    {
        yield return new WaitForSeconds(4);
        StartPatrol();
    }
}
