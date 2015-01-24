using UnityEngine;
using System.Collections;

public class GroundCheckScript : MonoBehaviour
{
    [SerializeField] private HeroController heroController;

    void OnTriggerEnter(Collider collider)
    {
        heroController.canJump = true;
    }
}
