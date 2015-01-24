using UnityEngine;

public class ControllerChoice : MonoBehaviour 
{
    public void Start()
    {
        GameManager.SetControllerString(0, "Keyboard ");
        GameManager.SetControllerString(1, "Joy 1 ");
        GameManager.SetControllerString(2, "Joy 2 ");
        GameManager.SetControllerString(3, "Joy 3 ");
    }
}
