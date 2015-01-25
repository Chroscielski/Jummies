using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform cameraPointer;
    [SerializeField] private CameraPointerScript cameraPointerScript;
    [SerializeField] private float yPossitionOffset;

    private void Update()
    {
        var centerDist = Vector3.Distance(cameraPointer.position, transform.position);
        float playerDist = 0;
        foreach (var heroController in LevelManager.AlivePlayersEnumertor())
        {
            foreach (var controller in LevelManager.AlivePlayersEnumertor())
            {
                var dist = Vector3.Distance(heroController.transform.position, controller.transform.position);
                if (dist > playerDist)
                {
                    playerDist = dist;
                }
            }
        }
        transform.LookAt(cameraPointer);
        var fieldOfView = Mathf.Atan(playerDist/centerDist) * Mathf.Rad2Deg * 1.5f;
        Camera.main.fieldOfView = fieldOfView > 40 ? fieldOfView : 40;
        //transform.position = new Vector3(cameraPointer.transform.position.x, yPossitionOffset, -cameraPointerScript.GetDistance() * 0.5f - 25.0f);
    }
}