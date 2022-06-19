using UnityEngine;

public class LookToMouse : MonoBehaviour
{
    private Camera _camera;

    // Update is called once per frame
    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector2 position = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mousePosition = (Vector2)_camera.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(position, mousePosition);
        
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
    }
    
    
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
