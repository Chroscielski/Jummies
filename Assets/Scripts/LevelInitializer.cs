using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public Light[] lights;
    public float DarknessMultiplier;

    public GameObject ArmageddonPrefab;

    void Start()
    {
        if (GameManager.DarknessEnabled)
        {
            foreach (var light in lights)
            {
                light.intensity *= 0.1f;
            }
        }

        if (GameManager.ArmageddonEnabled)
        {
            Instantiate(ArmageddonPrefab);
        }
    }
}