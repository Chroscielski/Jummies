using UnityEngine;
using System.Collections;

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

    void Update ()
        {
            Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
            int i = 1;

            foreach (var hero in LevelManager.AlivePlayersEnumertor())
            {
                if (!LevelManager.IsPlayerAlive(i-1)) continue;
                
                pos += hero.transform.position;
                i++;
            }

            transform.position = pos/i;
        }
    }
