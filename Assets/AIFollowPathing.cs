using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIFollowPathing : MonoBehaviour
{
    [SerializeField] private Pathing path;
    [SerializeField] private NavMeshAgent agent;
    private Transform[] _transform;
    [SerializeField] private int nodeIndex = 0;

    void Start()
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
        Debug.Log(_transform[nodeIndex].gameObject.name);
    }

    private void Update()
    {
        if (TargetReached())
        {
            nodeIndex++;
            if (nodeIndex >= _transform.Length)
            {
                nodeIndex = 0;
            }
            agent.destination = _transform[nodeIndex].position;
            // Debug.Log(_transform[nodeIndex].gameObject.name);
        }
    }

    public bool TargetReached()
    {
        Debug.Log(Vector3.Distance(transform.position, _transform[nodeIndex].position));
        // return agent.destination.x == _transform[nodeIndex].position.x;
        return Vector3.Distance(transform.position, _transform[nodeIndex].position) < 1;
    }
}
