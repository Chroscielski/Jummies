using UnityEngine;
using System.Collections;

public class TestControllerInput : MonoBehaviour
{
	void Start()
    {
        GameManager.SetControllerString(0, "Joy 1 ");
        GameManager.SetControllerString(1, "Joy 2 ");
        GameManager.SetControllerString(2, "Joy 3 ");
        GameManager.SetControllerString(3, "Joy 4 ");
    }
}
