using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private GameObject explosionSoundPrefab;

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
        GameObject explosionSound = (GameObject)Instantiate(explosionSoundPrefab, transform.position, Quaternion.identity);
        Destroy(explosionSound, 3);
        Destroy(explosion, 5);
        Destroy(gameObject);
    }
}