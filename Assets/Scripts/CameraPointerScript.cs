using UnityEngine;
using System.Collections;

public class CameraPointerScript : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;

    public float GetDistance()
    {
        float maxDist = 0.0f;

        foreach (var i in points)
        {
            foreach (var j in points)
            {
                maxDist = Mathf.Max(maxDist, Vector3.Distance(i.position, j.position));
            }
        }

        return maxDist;
    }

    void Update ()
        {
            Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
            int i = 1;

            foreach (var point in points)
            {
                pos += point.position;
                i++;
            }

            transform.position = pos/i;
        }
    }
