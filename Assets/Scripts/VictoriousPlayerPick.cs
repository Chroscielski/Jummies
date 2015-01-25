using UnityEngine;
using UnityEngine.EventSystems;

public class VictoriousPlayerPick : MonoBehaviour 
{
    void Start()
    {
        var module = GetComponent<StandaloneInputModule>();
        var controllerString = GameManager.GetControllerString(GameManager.VictoriousPlayer);
        module.horizontalAxis = controllerString + "Axis X";
        module.verticalAxis = controllerString + "Axis Y";
        module.submitButton = controllerString + "Button A";
    }
}
