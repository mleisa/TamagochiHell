using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Movement player;
    [SerializeField]
    private float offsetX, offsetY, offsetZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);
    }
}
