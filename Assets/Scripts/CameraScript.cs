using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPointer;

    [SerializeField]
    private CameraPointerScript cameraPointerScript;

    [SerializeField]
    private float yPossitionOffset;

    void Update()
    {
        transform.position = new Vector3(cameraPointer.transform.position.x, yPossitionOffset, -cameraPointerScript.GetDistance() *0.5f - 25.0f);
    }
}
