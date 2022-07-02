using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    [SerializeField] private HealthSystem gameObject;
    void Start()
    {
        gameObject = GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (gameObject.isDead)
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
