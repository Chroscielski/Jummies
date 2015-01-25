using UnityEngine;
using System.Collections;

public class MenuCharacterController : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void playChosenOneAnim()
    {
        anim.SetTrigger("IsChosen");
    }
}
