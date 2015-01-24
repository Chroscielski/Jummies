using UnityEngine;

public class HeavenSpawn : MonoBehaviour
{
    public float MinX;
    public float MaxX;
    public float MinZ;
    public float MaxZ;

    public float spawnHeight;

    public float probability;

    private int _probability;

    public GameObject objectPrefab;

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

            Instantiate(objectPrefab, new Vector3(x, spawnHeight, z), Quaternion.identity);
        }
    }
}
