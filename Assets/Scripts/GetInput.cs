using System;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    public int numberOfPlayers = 2;

    public HeroController[] heroes;

    /* 
     * Z nieznanych mi przyczyn Windows wykrywa kontroler 1 jako 2 a kontroler 2 jako 1
     * W Inpucie jest dlatego ustawione odwrotnie
     * Jeśli są jakieś problemy z numerem kontrolera szukać rozwiązania tam.
     */

    public void SetActivePlayer(int id, HeroController hero)
    {
        heroes[id] = hero;
    }

    void Awake()
    {
        heroes = new HeroController[4];
    }

    private void Start()
    {
        //GameManager.ToggleJump();

        if (GameManager.IsActivePlayer(0))
            heroes[0] = GameObject.Find("P1").GetComponent<HeroController>();
        if (GameManager.IsActivePlayer(1)) 
            heroes[1] = GameObject.Find("P2").GetComponent<HeroController>();
        if (GameManager.IsActivePlayer(2)) 
            heroes[2] = GameObject.Find("P3").GetComponent<HeroController>();
        if (GameManager.IsActivePlayer(3))
            heroes[3] = GameObject.Find("P4").GetComponent<HeroController>();
    }


    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (GameManager.IsActivePlayer(i))
            {
                GetPlayerInput(i);
            }
        }
    }

    void GetPlayerInput(int playerNumber)
    {
        var controllerString = GameManager.GetControllerString(playerNumber);

        Debug.Log(Input.GetAxis(controllerString + "Trigger Left"));

        if (Input.GetAxis(controllerString + "Trigger Left") == 1.0f && GameManager.JumpEnabled)
        {
            heroes[playerNumber].Jump();
            Debug.Log(String.Format("{0} Skacze", playerNumber));
        }
        if (Input.GetAxis("Joy 1 Trigger Right") == 1.0f)
        {
            //Attack
            Debug.Log(String.Format("{0} Atakuje", playerNumber));
        }

        float axis_X = Input.GetAxis(controllerString + "Axis X");
        float axis_Y = Input.GetAxis(controllerString + "Axis Y");
        float axis_3 = Input.GetAxis(controllerString + "Axis 3");
        float axis_4 = Input.GetAxis(controllerString + "Axis 4");

        heroes[playerNumber].Move(axis_X, -axis_Y);
        if (axis_3 != 0.0f || axis_4 != 0.0f)
            heroes[playerNumber].Rotate(axis_3, -axis_4);
    }
}

