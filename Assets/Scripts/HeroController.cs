using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    MeleeColiderController meleeColiderController;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(meleeColiderController.Attack());
        }

    }

    public void TakeDamage()
    {
        this.gameObject.rigidbody.AddForce(Vector3.forward * 400.0f);
    }
}
