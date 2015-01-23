using UnityEngine;
using UnityEngine.UI;

public class MechanicsMenuUI : MonoBehaviour
{
    public Dialog _dialog;
    public Toggle JumpToggle;

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


}
