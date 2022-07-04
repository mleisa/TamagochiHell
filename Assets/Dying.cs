using UnityEngine;

public class Dying : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (healthSystem.isDead)
        {
            MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
            foreach (var component in comps)
            {
                if (component.enabled) 
                {
                    component.enabled = false;
                }
            }
        }
    }
}
