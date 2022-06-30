using System.Collections;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private AIFollowPathing followPathing;
    [SerializeField] private AIFollow aiFollow;
    private bool isChasing;
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private FieldOfHearing fieldOfHearing;

    private void Start()
    {
        followPathing = GetComponent<AIFollowPathing>();
        aiFollow = GetComponent<AIFollow>();
        fieldOfView = GetComponent<FieldOfView>();
        fieldOfHearing = GetComponent<FieldOfHearing>();

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
        var targetsInSight = fieldOfView.visibleTargets;
        var targetsInHearing = fieldOfHearing.noisyTargets;
        bool seeTargets = targetsInSight.Count > 0;
        bool hearTargets = targetsInHearing.Count > 0;

        if (seeTargets)
        {
            aiFollow.UpdateTarget(targetsInSight[0]);
            StartChase();
        }
        else if (hearTargets)
        {
            aiFollow.UpdateTarget(targetsInHearing[0]);
            StartChase();

        } else
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
