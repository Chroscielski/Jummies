using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private bool _darknessEnabled = false;
    private bool _jumpEnabled = true;
    private bool _armageddonEnabled = false;

    public bool[] ActivePlayers = {true, true, false};

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
        }
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
}