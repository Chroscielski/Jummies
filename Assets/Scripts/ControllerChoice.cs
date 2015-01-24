using UnityEngine;
using UnityEngine.UI;

public class ControllerChoice : MonoBehaviour
{
    private int nextPlayer = 0;

    public Text[] playerTexts;
    
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
            GameManager.SetControllerString(nextPlayer, "Joy 1");
            setPlayer(0);

        }
        if (Input.GetButtonDown("Joy 2 Button A"))
        {
            GameManager.SetControllerString(nextPlayer, "Joy 2");
            setPlayer(1);
        }
        if (Input.GetButtonDown("Joy 3 Button A"))
        {
            GameManager.SetControllerString(nextPlayer, "Joy 3"); 
            setPlayer(2);
        }
        if (Input.GetButtonDown("Joy 4 Button A"))
        {
            GameManager.SetControllerString(nextPlayer, "Joy 4");
            setPlayer(3);
        }
    }

    void togglePlayerBox(int playerNumber)
    {
        playerTexts[playerNumber].gameObject.SetActive(true);
    }

    void setPlayer(int playerNumber)
    {
        GameManager.SetPlayerActive(playerNumber);
        togglePlayerBox(playerNumber);
    }
}
