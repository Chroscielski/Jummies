using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour
{
    [SerializeField] private HeroController heroController;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Ground")
            heroController.OnLanded();
        if (collider.tag == "DeathZone")
        {
            heroController.OnDeath();
        }
    }
}
