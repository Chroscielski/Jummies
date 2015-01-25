using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathZone")
        {
            DestroySelf();
        }
    }

    public void DestroySelf()
    {
        GameObject explosion = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 5);
        Destroy(gameObject);
    }
}