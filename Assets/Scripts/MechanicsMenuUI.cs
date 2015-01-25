using UnityEngine;
using UnityEngine.UI;

public class MechanicsMenuUI : MonoBehaviour
{
    public Dialog _dialog;
    public Toggle JumpToggle;
    public Toggle DarknessToggle;
    public Toggle ArmageddonToggle;

    void Awake()
    {
        
        
    }

    public void ToggleJump()
    {
        _dialog.Display(string.Format("Jumping will be " + (GameManager.PowerJumpEnabled ? "Disabled" : "Enabled")), ConfirmToggleJump, CancelToggleJump);
    }

    public void ConfirmToggleJump()
    {
        Debug.Log("AAA");
        GameManager.ToggleJump();
        GameManager.StartRound();
    }

    public void CancelToggleJump()
    {
        Debug.Log("BBB");
        JumpToggle.isOn = !JumpToggle.isOn;
        JumpToggle.Select();
    }

    public void ToggleDarkness()
    {
        _dialog.Display(string.Format("Darkness will be " + (GameManager.DarknessEnabled ? "Disabled" : "Enabled")), ConfirmToggleDarkness, CancelToggleDarkness);
    }

    public void ConfirmToggleDarkness()
    {
        GameManager.ToggleDarkness();
        GameManager.StartRound();
    }

    public void CancelToggleDarkness()
    {
        DarknessToggle.isOn = !DarknessToggle.isOn;
        DarknessToggle.Select();
    }

    public void ToggleArmageddon()
    {
        _dialog.Display(string.Format("Armageddon will be " + (GameManager.ArmageddonEnabled ? "Disabled" : "Enabled" )), ConfirmToggleArmageddon, CancelToggleArmageddon);
    }

    public void ConfirmToggleArmageddon()
    {
        GameManager.ToggleArmageddon();
        GameManager.StartRound();
    }

    public void CancelToggleArmageddon()
    {
        ArmageddonToggle.isOn = !ArmageddonToggle.isOn;
        ArmageddonToggle.Select();
    }
}
