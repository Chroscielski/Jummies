using UnityEngine;
using System.Collections;

public class MeleeColiderController : MonoBehaviour
{
    public IEnumerator Attack()
    {
        Debug.Log("DZIALA1");
        this.gameObject.collider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        this.gameObject.collider.enabled = false;
        Debug.Log("DZIALA2");
    }

    void OnTriggerEnter(Collider collider)
    {
        ((HeroController) collider.gameObject.GetComponent("HeroController")).TakeDamage();
    }
}
