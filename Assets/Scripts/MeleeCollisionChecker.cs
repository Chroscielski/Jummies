using UnityEngine;
using System.Collections;

public class MeleeCollisionChecker : MonoBehaviour
{
    [SerializeField]
    private HeroController heroController;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && col.GetComponent<HeroController>() != heroController)
        {
            var cont = col.gameObject.GetComponent<HeroController>();
            if (cont != null)
                cont.TakeHit(transform.position, heroController.PowerAttack ? 1.6f : 1);
        }
        else if (col.tag == "SuperBox")
        {
            var cont = col.gameObject.GetComponent<BoxController>();
            if (cont != null)
            {
                cont.DestroySelf();

                int rand = Random.Range(1, 2);

                switch (rand)
                {
                    case 1:
                        heroController.EnablePowerJump(5.0f);
                        break;
                    case 2:
                        heroController.EnableSuperHit(5.0f);
                        break;
                }
            }
        }

        heroController.PlayPunchSound();
    }
}