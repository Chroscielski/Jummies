using UnityEngine;
using System.Collections;

public class MeleeCollisionChecker : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            var cont = col.gameObject.GetComponent<HeroController>();
            if (cont != null)
                cont.TakeHit(transform.position);
        }
        else if (col.tag == "SuperBox")
        {
            var cont = col.gameObject.GetComponent<BoxController>();
            if (cont != null)
                cont.DestroySelf();
        }
    }
}