using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection.Emit;

public class GetInput : MonoBehaviour
{
    public int numberOfPlayers = 2;

    public HeroController[] heroes;

    /* 
     * Z nieznanych mi przyczyn Windows wykrywa kontroler 1 jako 2 a kontroler 2 jako 1
     * W Inpucie jest dlatego ustawione odwrotnie
     * Jeśli są jakieś problemy z numerem kontrolera szukać rozwiązania tam.
     */

    private enum PlayerNumber
    {
        Player1 = 1,
        Player2,
        Player3,
        Player4
    }

    void Awake()
    {
        heroes = new HeroController[4];
    }

    private void Start()
    {
        //GameManager.ToggleJump();

        if (GameManager.IsActivePlayer((int)PlayerNumber.Player1 - 1))
            heroes[0] = GameObject.Find("P1").GetComponent<HeroController>();
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player2 - 1)) 
            heroes[1] = GameObject.Find("P2").GetComponent<HeroController>();
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player3 - 1)) 
            heroes[2] = GameObject.Find("P3").GetComponent<HeroController>();
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player4 - 1))
            heroes[3] = GameObject.Find("P4").GetComponent<HeroController>();
    }


    private void Update()
    {
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player1 - 1)) 
            GetPlayerInput(PlayerNumber.Player1);
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player2 - 1)) 
            GetPlayerInput(PlayerNumber.Player2);
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player3 - 1)) 
            GetPlayerInput(PlayerNumber.Player3);
        if (GameManager.IsActivePlayer((int)PlayerNumber.Player4 - 1)) 
            GetPlayerInput(PlayerNumber.Player4);
    }

    void GetPlayerInput(PlayerNumber playerNumber)
    {
        if (Input.GetAxis(String.Format("Joy {0} Trigger Left", (int)playerNumber)) == 1.0f && GameManager.JumpEnabled)
        {
            heroes[(int)playerNumber - 1].Jump();
            Debug.Log(String.Format("{0} Skacze", (int)playerNumber));
        }
        if (Input.GetAxis("Joy 1 Trigger Right") == 1.0f)
        {
            //Attack
            Debug.Log(String.Format("{0} Atakuje", (int)playerNumber));
        }
        float axis_X = Input.GetAxis(String.Format("Joy {0} Axis X", (int)playerNumber));
        float axis_Y = Input.GetAxis(String.Format("Joy {0} Axis Y", (int)playerNumber));
        float axis_3 = Input.GetAxis(String.Format("Joy {0} Axis 3", (int)playerNumber));
        float axis_4 = Input.GetAxis(String.Format("Joy {0} Axis 4", (int)playerNumber));

        heroes[(int)playerNumber - 1].Move(axis_X, -axis_Y);
        if (axis_3 != 0.0f && axis_4 != 0.0f)
            heroes[(int)playerNumber - 1].Rotate(axis_3, -axis_4);
    }
}

