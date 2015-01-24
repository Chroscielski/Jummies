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

    public float GetCameraYRotation()
    {
        return transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        transform.LookAt(cameraPointer.position, Vector3.up);

        transform.position = Vector3.forward * -cameraPointerScript.GetDistance();
        transform.position += Vector3.up*yPossitionOffset;
    }
}
