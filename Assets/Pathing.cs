using UnityEngine;

public class Pathing : MonoBehaviour
{
    private GameObject narc;

    public bool IsOccupied()
    {
        return narc != null;
    }

    public GameObject Narc
    {
        get => narc;
        set => narc = value;
    }
}
