using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class PlayerBinds
{
    [SerializeField] 
    public List<KeyCode> button;

    [SerializeField]
    public List<float> axises;

    public PlayerBinds()
    {
        button = new List<KeyCode>();
        axises = new List<float>();
    }
}
