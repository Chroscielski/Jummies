using UnityEngine;

public class Bomb : MonoBehaviour
{
    private const int playersLayer = 10;
    private const int groundLayer = 8;
    public float explosionRadius;
    public float explosionForce;

    public GameObject ExplosionPrefab;
    public GameObject CrossHairPrefab;
    private GameObject _crossHair;

    public Bomb(GameObject crossHair)
    {
        this._crossHair = crossHair;
    }

    void Start()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(transform.position, Vector3.down, out hitInfo, Mathf.Infinity, 1 << groundLayer);
        if (hit)
        {
            _crossHair = (GameObject) Instantiate(CrossHairPrefab, hitInfo.point, Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        var explosionPos = transform.position;
        var colliders = Physics.OverlapSphere(explosionPos, explosionRadius, 1 << playersLayer);
        foreach (var hit in colliders)
        {
            hit.GetComponent<HeroController>().TakeHit(transform.position);
        }
        GameObject explosion = (GameObject)Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 5);
        Destroy(gameObject);
        Destroy(_crossHair);
    }
}