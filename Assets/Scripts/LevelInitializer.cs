using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public Light[] lights;
    public float DarknessMultiplier;

    public GameObject ArmageddonPrefab;
    public GameObject PowerUpSpawner;

    public GameObject[] PlayersPrefabs = new GameObject[4];
    public Skybox CameraSkybox;

    void Start()
    {
        if (GameManager.DarknessEnabled)
        {
            foreach (var light in lights)
            {
                light.intensity *= 0.05f;
                CameraSkybox.enabled = false;
            }
        }

        if (GameManager.ArmageddonEnabled)
        {
            Instantiate(ArmageddonPrefab);
        }

        if (GameManager.PowerUpsEnabled)
        {
            Instantiate(PowerUpSpawner);
        }

        for (int i = 0; i < 4; i++)
        {
            if (GameManager.IsActivePlayer(i))
            {
                GameObject newPlayer = (GameObject)Instantiate(PlayersPrefabs[i], LevelManager.GetSpawn(i).position, Quaternion.identity);
                LevelManager.AddPlayer(newPlayer.GetComponent<HeroController>());
            }
        }
    }
}
