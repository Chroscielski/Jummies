using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool[] _playersAlive;

    private static LevelManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        _playersAlive = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            _playersAlive[i] = GameManager.IsActivePlayer(i);
        }
    }

    public static bool IsPlayerAlive(int id)
    {
        return _instance._playersAlive[id];
    }

    public static void OnPlayerDeath(int id)
    {
        _instance._onPlayerDeath(id);
    }

    public void _onPlayerDeath(int id)
    {
        _playersAlive[id] = false;
        bool oneFound = false;
        for (int i = 0; i < 4; i++)
        {
            if (_playersAlive[i] && oneFound)
            {
                GameManager.WinGame(i);
            }
            else if (_playersAlive[i])
            {
                oneFound = true;
            }
        }
    }
}
