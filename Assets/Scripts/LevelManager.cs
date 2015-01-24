using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private bool[] _playersAlive;

    private static LevelManager _instance;

    public HeroController[] players;

    public int PlayersNumber;

    public static HeroController GetPlayer(int i)
    {
         return _instance.players[i];
    }

    public static void AddPlayer(HeroController hero)
    {
        _instance.players[_instance.PlayersNumber] = hero;
        _instance.PlayersNumber++;
    }

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
        players = new HeroController[4];
        for (int i = 0; i < 4; i++)
        {
            _playersAlive[i] = GameManager.IsActivePlayer(i);
        }
        PlayersNumber = 0;
    }

    public static IEnumerable<HeroController> AlivePlayersEnumertor()
    {
        for (int i = 0; i < 4; i++)
        {
            if (_instance._playersAlive[i])
            {
                yield return GetPlayer(i);
            }
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
        int oneFound = -1;
        for (int i = 0; i < 4; i++)
        {
            if (_playersAlive[i] && oneFound >= 0)
            {
                return;
            }
            if (_playersAlive[i])
            {
                oneFound = i;
            }
        }
        GameManager.WinGame(oneFound);
    }
}
