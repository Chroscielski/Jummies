
using UnityEngine;
using UnityEngine.UI;

public class ControllerChoice : MonoBehaviour
{
    private int nextPlayer = 0;

    public Text[] playerTexts;

    public MenuCharacterController[] players;

    public void Start()
    {
    }

    void Update()
    {
        getInput();
    }

    void getInput()
    {
        if (Input.GetButtonDown("Joy 1 Button A"))
        {
            GameManager.SetControllerString(0, "Joy 1 ");
            setPlayer(0);
        }
        if (Input.GetButtonDown("Joy 2 Button A"))
        {
            GameManager.SetControllerString(1, "Joy 2 ");
            setPlayer(1);
        }
        if (Input.GetButtonDown("Joy 3 Button A"))
        {
            GameManager.SetControllerString(2, "Joy 3 ");
            setPlayer(2);
        }
        if (Input.GetButtonDown("Joy 4 Button A"))
        {
            GameManager.SetControllerString(3, "Joy 4 ");
            setPlayer(3);
        }

        for (int i = 0; i < 4; i++)
            if (Input.GetButtonDown("Joy " + (i + 1).ToString() + " Button Start") && nextPlayer > 1)
                GameManager.StartRound();
        if (Input.GetKeyDown(KeyCode.Return) && nextPlayer > 1)
        {
            GameManager.StartRound();      
        }
    }

    void setPlayer(int playerNumber)
    {
        GameManager.SetPlayerActive(playerNumber);
        playerTexts[playerNumber].gameObject.SetActive(false);
        players[playerNumber].playChosenOneAnim();
        nextPlayer++;
    }
}
