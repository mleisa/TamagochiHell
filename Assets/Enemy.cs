using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.y > 10) Destroy(gameObject);
    }
}
