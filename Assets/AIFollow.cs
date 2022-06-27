using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void UpdateTarget(Transform newTarget)
    {
        if (newTarget == null)
        {
            return;
        }
        
        target = newTarget;
        agent.destination = target.position;
    }

    public bool ReachedDestination()
    {
        return agent.GetPathRemainingDistance() < 1;
    }



}