using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light[] lights;
    [SerializeField] private LightCharge chargeLeft;

    void Start()
    {
        lights = GetComponentsInChildren<Light>();
        chargeLeft = GetComponent<LightCharge>();
        Debug.Log(lights);
    }

    public void KillLights()
    {
        if (chargeLeft.currentCharge <= 0)
        {
            foreach (var lighter in lights)
            {
                if (lighter.enabled)
                {
                    lighter.enabled = false;
                }
            }
        }
    }

    public void Relight()
    {
        if (chargeLeft.currentCharge > 0)
        {
            foreach (var lighter in lights)
            {
                if (!lighter.enabled)
                {
                    lighter.enabled = true;
                }
            }
        }
    }
}