using UnityEngine;

public class Bomb : MonoBehaviour
{
    private const int playersLayer = 10;
    public float explosionRadius;
    public float explosionForce;

    public GameObject ExplosionPrefab;

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
    }
}