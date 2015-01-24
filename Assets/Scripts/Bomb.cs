using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius;
    public float explosionForce;

    public GameObject ExplosionPrefab;

    private void OnCollisionEnter(Collision col)
    {
        var explosionPos = transform.position;
        var colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach (var hit in colliders)
        {
            if (hit && hit.rigidbody && hit.rigidbody != rigidbody)
            {
                hit.rigidbody.AddExplosionForce(explosionForce, explosionPos, explosionRadius, 3.0F);
            }
        }
        GameObject explosion = (GameObject)Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 5);
        Destroy(gameObject);
    }
}