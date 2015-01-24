using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour
{
    [SerializeField]
    private HeroController heroController;

    void OnTriggerEnter(Collider collider)
    {
        heroController.OnLanded();
        if (collider.tag == "DeathZone")
        {
            heroController.OnDeath();
        }
    }
}
