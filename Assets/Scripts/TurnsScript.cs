using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Turns : MonoBehaviour
{
    //public TMPro.TextMeshProUGUI turnText;
    public TMP_Text turnText ;
    public enum PlayerTurns {PlayerOne, PlayerTwo}
    public PlayerTurns actualTurn;



    void Start()
    {
        actualTurn = PlayerTurns.PlayerOne; //Turno del jugador 1
    }


    public void ChangeTurn()
    {
        if(actualTurn == PlayerTurns.PlayerOne)
        {
            actualTurn =PlayerTurns.PlayerTwo;
        }
        else
        {
            actualTurn = PlayerTurns.PlayerOne;
        }

        turnText.text= " Es el turno del : " + actualTurn;
    }
}
