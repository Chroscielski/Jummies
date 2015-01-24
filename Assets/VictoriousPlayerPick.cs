using UnityEngine;
using UnityEngine.EventSystems;

public class VictoriousPlayerPick : MonoBehaviour 
{
    void Start()
    {
        var module = GetComponent<StandaloneInputModule>();
        module.horizontalAxis = GameManager.GetControllerString(GameManager.VictoriousPlayer) + "Axis X";
        module.verticalAxis = GameManager.GetControllerString(GameManager.VictoriousPlayer) + "Axis Y";
    }
}
