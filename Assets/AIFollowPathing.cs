using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowPathing : MonoBehaviour
{
    [SerializeField] private Pathing path;
    [SerializeField] private NavMeshAgent agent;
    private Transform[] _transform;
    [SerializeField] private int nodeIndex = 0;

    void OnEnable()
    {
        GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");

        foreach (var currentPath in paths)
        {
            var pathComponent = currentPath.GetComponent<Pathing>();
            if (pathComponent.IsOccupied()) continue;
            pathComponent.Narc = gameObject;
            path = pathComponent;
            break;
        }

        _transform = path.transform.GetComponentsInChildren<Transform>();
        _transform = _transform.Skip(1).ToArray();
        
        agent.destination = _transform[nodeIndex].position;
    }

    private void Update()
    {
        if (agent.GetPathRemainingDistance() < 1)
        {
            nodeIndex++;
            if (nodeIndex >= _transform.Length)
            {
                nodeIndex = 0;
            }
            agent.destination = _transform[nodeIndex].position;
        }
    }
}
