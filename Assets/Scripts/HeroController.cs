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
        Debug.Log("TOOK DAMAGE BIJACZ");
    }
}
