using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject readyPlayerOne;
    public GameObject readyPlayerTwo;
    public static void ChangeCard( List<GameObject> cardsSelection, bool wbtc , GameObject lastCard)
    {
        Players players = GameObject.FindObjectOfType<Players>();

        List<GameObject> PlayerOneCards = players.PlayerOne.Cards;

        List<GameObject> PlayerTwoCards = players.PlayerTwo.Cards;


        if( wbtc == true)
        {
            foreach(GameObject card in cardsSelection )
            {
                PlayerOneCards.Remove(card);

                Destroy(card);
            }

            Draw draw = GameObject.Find("GameManager").GetComponent<Draw>();

            draw.TakeTwoCards();

            CardDisplay cardDisplay = lastCard.GetComponent<CardDisplay>();

            cardDisplay.DragActive();
            
            foreach(GameObject card in PlayerOneCards)
            {
                card.GetComponent<CardDisplay>().clickActive = false ;

                card.SetActive(false);
            }

            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

            gameManager.readyPlayerTwo.SetActive(true);
        }

        else 
        {
            foreach(GameObject card in cardsSelection )
            {
                PlayerTwoCards.Remove(card);

                Destroy(card);
            }

            DrawDeckTwo draw = GameObject.Find("GameManager").GetComponent<DrawDeckTwo>();

            draw.TakeTwoCards();

            CardDisplay cardDisplay = lastCard.GetComponent<CardDisplay>();

            cardDisplay.DragActive();
            
            foreach(GameObject card in PlayerTwoCards)
            {
                card.GetComponent<CardDisplay>().clickActive = false ;

                card.SetActive(false);
            }

            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

            gameManager.readyPlayerOne.SetActive(true);
            
        }
    }


    public static void Turns(GameObject actualCard, bool wbtc)
    {
        Players players = GameObject.FindObjectOfType<Players>();

        List<GameObject> PlayerOneCard = players.PlayerOne.Cards;

        List<GameObject> PlayerTwoCard = players.PlayerTwo.Cards;

        if(wbtc == true)
        {
            PlayerOneCard.Remove(actualCard);
        
        foreach(GameObject card in PlayerOneCard)
        {
            card.SetActive(false);
        }

        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.readyPlayerTwo.SetActive(true);
        }

        else
        {
            PlayerTwoCard.Remove(actualCard);
        
        foreach(GameObject card in PlayerTwoCard)
        {
            Debug.Log(PlayerTwoCard.Count);
            card.SetActive(false);
        }

        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
        gameManager.readyPlayerOne.SetActive(true); 
        }
    }
}
