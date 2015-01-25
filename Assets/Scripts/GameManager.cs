
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private int _victoriousPlayer = -1;

    public static int VictoriousPlayer
    {
        get { return _instance._victoriousPlayer; }
    }

    private bool _powerJumpEnabled;
    public float JumpForceBase;
    public float PowerJumpModifier;
    public static float JumpForce
    {
        get { return _instance.JumpForceBase * (_instance._powerJumpEnabled ? _instance.PowerJumpModifier : 1); }
    }

    private bool _superHitEnabled = false;

    public static bool SuperHitEnabled
    {
        get { return _instance._superHitEnabled;}
    }

    public float HitForceBase;

    public float _superHitModifier;
    public static float SuperHitModifier
    {
        get { return _instance._superHitModifier; }
    }

    public static void ToggleSuperHit()
    {
        _instance._superHitEnabled = !_instance._superHitEnabled;
    }

    public float _jumpModifier;
    public static float JumpForceModifier
    {
        get { return _instance._jumpModifier; }
    }

    public static float HitForce
    {
        get { return _instance.HitForceBase*(_instance._superHitEnabled ? SuperHitModifier : 1); }
    }

    private bool _darknessEnabled = false;
    private bool _armageddonEnabled = false;

    //TODO: set to all false
    public bool[] _activePlayers = { false, false, false, false };

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

    public static bool PowerJumpEnabled
    {
        get { return _instance._powerJumpEnabled; }
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
        if (controllerStrings == null || controllerStrings.Length == 0)
        {
            controllerStrings = new string[4];
        }
        DontDestroyOnLoad(gameObject);
    }

    public static void StartRound()
    {
        Application.LoadLevel("TestScene_MP");
    }

    public static void ToggleJump()
    {
        _instance._powerJumpEnabled = !_instance._powerJumpEnabled;
    }

    public static void ToggleDarkness()
    {
        _instance._darknessEnabled = !_instance._darknessEnabled;
    }

    public static void ToggleArmageddon()
    {
        _instance._armageddonEnabled = !_instance._armageddonEnabled;
    }



    public static void WinGame(int playerId)
    {
        _instance._victoriousPlayer = playerId;
        Application.LoadLevel("MechanicMenu");
    }
}