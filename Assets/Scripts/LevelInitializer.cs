using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public Light[] lights;
    public float DarknessMultiplier;

    public GameObject ArmageddonPrefab;

    public GameObject[] PlayersPrefabs;

    void Awake()
    {
        //Player
    }

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

        for(int i = 0; i < 4;i++)
            if (GameManager.IsActivePlayer(0))
            {
                //Instantiate(PlayersPrefabs[0], Vector3.zero);
            }
    }
}