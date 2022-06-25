using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = target.position;
    }
}