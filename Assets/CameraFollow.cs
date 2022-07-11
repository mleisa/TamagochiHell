using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Movement player;
    [SerializeField]
    private float offsetX, offsetY, offsetZ;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    
    void Update()
    {
        transform.position = player.transform.position + new Vector3(offsetX, offsetY, offsetZ);
    }
}
