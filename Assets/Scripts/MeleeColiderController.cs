using UnityEngine;
using System.Collections;

public class MeleeColiderController : MonoBehaviour
{
    public IEnumerator Attack()
    {
        this.gameObject.collider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.collider.enabled = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        ((HeroController)collider.gameObject.GetComponent("HeroController")).TakeDamage();
    }
}
