
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private int _victoriousPlayer = -1;

    public static int VictoriousPlayer
    {
        get { return _instance._victoriousPlayer; }
    }

    private bool _darknessEnabled = false;
    private bool _jumpEnabled = true;
    private bool _armageddonEnabled = false;

    //TODO: set to all false
    private bool[] _activePlayers = { false, false, false, false };

    public string[] controllerStrings;

    public static void SetControllerString(int playerId, string controller)
    {
        _instance.controllerStrings[playerId] = controller;
    }

    public static string GetControllerString(int playerId)
    {
        return _instance.controllerStrings[playerId];
    }

    public static bool IsActivePlayer(int i)
    {
        return _instance._activePlayers[i];
    }

    public static void SetPlayerActive(int i)
    {
        _instance._activePlayers[i] = true;
    }

    public static bool JumpEnabled
    {
        get { return _instance._jumpEnabled; }
    }

    public static bool DarknessEnabled
    {
        get { return _instance._darknessEnabled; }
    }

    public static bool ArmageddonEnabled
    {
        get { return _instance._armageddonEnabled; }
    }

    private void Awake()
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
        controllerStrings = new string[4];
        DontDestroyOnLoad(gameObject);
    }

    public void _startRound()
    {
        DontDestroyOnLoad(gameObject);
        Application.LoadLevel("Main");
    }

    public static void StartRound()
    {
        _instance._startRound();
    }

    public static void ToggleJump()
    {
        _instance._toggleJump();
    }

    private void _toggleJump()
    {
        _jumpEnabled = !_jumpEnabled;
    }

    private void _toggleDarkness()
    {
        _darknessEnabled = !_darknessEnabled;
    }

    public static void ToggleDarkness()
    {
        _instance._toggleDarkness();
    }

    private void _toggleArmageddon()
    {
        _armageddonEnabled = !_armageddonEnabled;
    }

    public static void ToggleArmageddon()
    {
        _instance._toggleArmageddon();
    }

    public static void WinGame(int playerId)
    {
        _instance._victoriousPlayer = playerId;
        Application.LoadLevel("MechanicMenu");
    }
}