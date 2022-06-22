using System;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LightCharge flashlight = other.gameObject.GetComponent<LightCharge>();
        
        if (other.gameObject.name == "Player" && flashlight != null)
        {
            gameObject.SetActive(false);
            flashlight.ChargeUp();
        }
    }
}
