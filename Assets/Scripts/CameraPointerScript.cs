using UnityEngine;
using System.Collections.Generic;

public class CameraPointerScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;

    public float GetDistance()
    {
        float maxDist = 0.0f;

        foreach (var player in LevelManager.AlivePlayersEnumertor())
        {
            foreach (var player2 in LevelManager.AlivePlayersEnumertor())
            {
                maxDist = Mathf.Max(maxDist, Vector3.Distance(player.transform.position, player2.transform.position));
            }
        }

        return maxDist;
    }

    void Update()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (var player in LevelManager.AlivePlayersEnumertor())
        {
            positions.Add(player.transform.position);
        }
        Vector3 avgPosition = Vector3.zero;
        foreach (var position in positions)
        {
            avgPosition += position/positions.Count;
        }
        transform.position = avgPosition;
        //float maxDist = 0.0f;
        //Vector3 minVector3 = new Vector3();
        //foreach (var player in LevelManager.AlivePlayersEnumertor())
        //{
        //    foreach (var player2 in LevelManager.AlivePlayersEnumertor())
        //    {
        //        float tmp = Vector3.Distance(player.transform.position, player2.transform.position);
        //        if (maxDist < tmp)
        //        {
        //            maxDist = tmp;
        //            minVector3 = Vector3.Min(player.transform.position, player2.transform.position);
        //        }
        //    }
        //}

        //transform.position = new Vector3(minVector3.x + maxDist / 2, minVector3.y, minVector3.z);
    }
}