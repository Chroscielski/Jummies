using UnityEngine;
using System.Collections;

public class MeleeCollisionChecker : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            var comp = col.gameObject.GetComponent<HeroController>();
            if (comp != null)
                comp.TakeHit(this.transform.position);
        }
    }
}