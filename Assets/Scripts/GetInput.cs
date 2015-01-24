using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection.Emit;

public class GetInput : MonoBehaviour
{
    public int numberOfPlayers = 2;

    

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

    private void Start()
    {
        //GameManager.ToggleJump();
    }


    private void Update()
    {
        GetPlayerInput(PlayerNumber.Player1);
        GetPlayerInput(PlayerNumber.Player2);
    }

    void GetPlayerInput(PlayerNumber playerNumber)
    {
        if (Input.GetAxis(String.Format("Joy {0} Trigger Left", (int)playerNumber)) == 1.0f && GameManager.JumpEnabled)
        {
            P1.Jump();
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

        P1.Move(axis_X, -axis_Y);
        if (axis_3 != 0.0f && axis_4 != 0.0f)
            P1.Rotate(axis_3, -axis_4);
    }
}

