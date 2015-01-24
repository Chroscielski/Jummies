using UnityEngine;

public class Armageddon : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float BombSpawnHeight;

    public float probability;

    private int _probability;

    public GameObject BombPrefab;

    void Awake()
    {
        _probability = (int)(int.MaxValue * probability);
    }

    void Update()
    {
        var rng = new System.Random();
        if (rng.Next() < _probability)
        {
            float x = Random.Range(MinX, MaxX);
            float z = Random.Range(MinZ, MaxZ);

            Instantiate(BombPrefab, new Vector3(x, BombSpawnHeight, z), Quaternion.identity);
        }
    }
}
