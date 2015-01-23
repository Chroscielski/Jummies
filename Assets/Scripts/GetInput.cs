using System;
using UnityEngine;
using System.Collections.Generic;
using System.Reflection.Emit;

public class GetInput : MonoBehaviour
{
    public int numberOfPlayers = 2;

    public HeroController P1;
    public HeroController P2;

    /* 
     * Z nieznanych mi przyczyn Windows wykrywa kontroler 1 jako 2 a kontroler 2 jako 1
     * W Inpucie jest dlatego ustawione odwrotnie
     * Jeśli są jakieś problemy z numerem kontrolera szukać rozwiązania tam.
     */

    private enum PlayerNumber
    {
        Player1,
        Player2,
        //Player3,
        //Player4
    }

    private void Start()
    {
        GameManager.ToggleJump();
    }


    private void Update()
    {
        GetPlayer1Input();
        GetPlayer2Input();
    }

    void GetPlayer1Input()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && GameManager.JumpEnabled)
        {
            P1.Jump();
            Debug.Log("P1 Skacze");
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            //Attack
            Debug.Log("P1 Atakuje");
        }
        float axis_X = Input.GetAxis("Joy 1 Axis X");
        float axis_Y = Input.GetAxis("Joy 1 Axis Y");
        float axis_3 = Input.GetAxis("Joy 1 Axis 3");
        float axis_4 = Input.GetAxis("Joy 1 Axis 4");
        
        P1.Move(axis_X, axis_Y);

    }

    private void GetPlayer2Input()
    {
        if (Input.GetKeyDown(KeyCode.Joystick2Button0) && GameManager.JumpEnabled)
        {
            P2.Jump();
            Debug.Log("P2 Skacze");
        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            /*Player1.Attack()*/
            Debug.Log("P2 Atakuje");
        }
        float axis_X = Input.GetAxis("Joy 2 Axis X");
        float axis_Y = Input.GetAxis("Joy 2 Axis Y");
        float axis_3 = Input.GetAxis("Joy 2 Axis 3");
        float axis_4 = Input.GetAxis("Joy 2 Axis 4");
        
        P2.Move(axis_X, axis_Y);

    }
}

