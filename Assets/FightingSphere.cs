using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingSphere : MonoBehaviour
{
    [SerializeField] private List<Enemy> narcs;
    [SerializeField] private HashSet<Enemy> narcSet;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.GetComponent<Enemy>());

    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            narcSet.Add(enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            narcSet.Remove(enemy);
        }
    }


}
