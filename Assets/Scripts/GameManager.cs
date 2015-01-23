using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    private bool _jumpEnabled = true;

    public static bool JumpEnabled
    {
        get {return _instance._jumpEnabled;}
        
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

    public static void ToggleJump()
    {
        _instance._toggleJump();
    }

    private void _toggleJump()
    {
        _jumpEnabled = !_jumpEnabled;
    }

}
