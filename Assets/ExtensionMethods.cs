using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public static class ExtensionMethods
    {
        public static float GetPathRemainingDistance(this NavMeshAgent navMeshAgent)
        {
            if (navMeshAgent.pathPending ||
                navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
                navMeshAgent.path.corners.Length == 0)
                return -1f;

            float distance = 0.0f;
            for (int i = 0; i < navMeshAgent.path.corners.Length - 1; ++i)
            {
                distance += Vector3.Distance(navMeshAgent.path.corners[i], navMeshAgent.path.corners[i + 1]);
            }

            return distance;
        }
    }
}

// https://stackoverflow.com/questions/61421172/why-does-navmeshagent-remainingdistance-return-values-of-infinity-and-then-a-flo