using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingSphere : MonoBehaviour
{
    [SerializeField] private List<GameObject> narcs;
    [SerializeField] private HashSet<Enemy> narcSet;

    public List<GameObject> Narcs { get => narcs; set => narcs = value; }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Narcs.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            removeNarc(other.gameObject);
        }
    }

    public void removeNarc(GameObject narc)
    {
        Narcs.Remove(narc);
    }

}
