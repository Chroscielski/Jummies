﻿using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class MechanicsMenuUI : MonoBehaviour
{
    public Dialog _dialog;
    public Toggle JumpToggle;
    public Toggle SuperHitToggle;
    public Toggle DarknessToggle;
    public Toggle ArmageddonToggle;
    public Toggle PowerUpToggle;

    void Awake()
    {
        JumpToggle.isOn = GameManager.PowerJumpEnabled;
        SuperHitToggle.isOn = GameManager.SuperHitEnabled;
        DarknessToggle.isOn = GameManager.DarknessEnabled;
        ArmageddonToggle.isOn = GameManager.ArmageddonEnabled;
        PowerUpToggle.isOn = GameManager.PowerUpsEnabled;
    }

    public void TogglePowerUp()
    {
        _dialog.Display(string.Format("Power-up will be " + (GameManager.PowerUpsEnabled ? "Disabled" : "Enabled")), ConfirmTogglePowerUps, CancelTogglePowerUps);
    }

    public void ConfirmTogglePowerUps()
    {
        GameManager.TogglePowerUps();
        GameManager.StartRound();
    }

    public void CancelTogglePowerUps()
    {
        PowerUpToggle.isOn = !PowerUpToggle.isOn;
        JumpToggle.Select();
    }

    public void ToggleJump()
    {
        _dialog.Display(string.Format("Jumping will be " + (GameManager.PowerJumpEnabled ? "Disabled" : "Enabled")), ConfirmToggleJump, CancelToggleJump);
    }

    public void ConfirmToggleJump()
    {
        GameManager.ToggleJump();
        GameManager.StartRound();
    }

    public void CancelToggleJump()
    {
        JumpToggle.isOn = !JumpToggle.isOn;
        JumpToggle.Select();
    }


    public void ToggleSuperHit()
    {
        _dialog.Display(string.Format("Super hit will be " + (GameManager.SuperHitEnabled ? "Disabled" : "Enabled")), ConfirmToggleSuperHit, CancelToggleSuperHit);
    }

    public void ConfirmToggleSuperHit()
    {
        GameManager.ToggleSuperHit();
        GameManager.StartRound();
    }

    public void CancelToggleSuperHit()
    {
        SuperHitToggle.isOn = !SuperHitToggle.isOn;
        SuperHitToggle.Select();
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
