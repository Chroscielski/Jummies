﻿using UnityEngine;
using System.Collections;

public class MeleeCollisionChecker : MonoBehaviour
{
    [SerializeField]
    private HeroController heroController;

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
    }
}