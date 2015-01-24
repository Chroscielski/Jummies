using UnityEngine;
using System.Collections;

public class BoxController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    public void DestroySelf()
    {
        GameObject explosion = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 5);
        Destroy(gameObject);
    }
}
