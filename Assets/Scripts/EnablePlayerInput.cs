using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class EnablePlayerInput : MonoBehaviour
{
    private StandaloneInputModule input;

    void Awake()
    {
        input = GetComponent<StandaloneInputModule>();

        //GameManager.
    }

}
