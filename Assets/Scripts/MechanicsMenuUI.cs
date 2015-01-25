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
        _dialog.Display(string.Format("Jumping will be " + (GameManager.JumpEnabled ? "Disabled" : "Enabled")), ConfirmToggleJump, CancelToggleJump);
    }

    public void ConfirmToggleJump()
    {
        GameManager.ToggleJump();
        GameManager.StartRound();
    }

    public void CancelToggleJump()
    {
        JumpToggle.isOn = !JumpToggle.isOn;
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
    }
}
