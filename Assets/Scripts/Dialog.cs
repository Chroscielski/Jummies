using System;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text Message;
    public Button ConfirmButton;

    private Action _onConfirm;
    private Action _onCancel;

    public void Display(string text, Action onConfirm, Action onCancel)
    {
        Message.text = text;
        _onConfirm = onConfirm;
        _onCancel = onCancel;
        gameObject.SetActive(true);
        ConfirmButton.Select();
    }

    public void Confirm()
    {
        _onConfirm();
    }

    public void Cancel()
    {
        _onCancel();
        gameObject.SetActive(false);
    }
}
