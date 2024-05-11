using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Draw : MonoBehaviour
{

    private bool takeIt = true ;
    public Players players;
    public GameObject Card1 ;
    public GameObject Card2 ;
    public GameObject Card3 ;
    public GameObject Card4 ;
    public GameObject Card5 ;
    public GameObject Card6 ;
    public GameObject Card7 ;
    public GameObject Card8 ;
    public GameObject Card9 ;
    public GameObject Card10 ;
    public GameObject Card11 ; 
    public GameObject Card12 ;
    public GameObject Card13 ;
    public GameObject Card14 ;
    public GameObject Card15 ;
    public GameObject Card16 ;
    public GameObject Card17 ;
    public GameObject Card18 ;
    public GameObject Card19 ;
    public GameObject Card20 ;
    public GameObject Card21 ;
    public GameObject Card22 ;
    public GameObject Card23 ;
    public GameObject Card24 ;
    public GameObject PlayerArea ;

    List<GameObject> cards = new List<GameObject>() ;
    void Start()
    {
        cards.Add(Card1) ;
        cards.Add(Card2) ;
        cards.Add(Card3) ;
        cards.Add(Card4) ;
        cards.Add(Card5) ;
        cards.Add(Card6) ;
        cards.Add(Card7) ;
        cards.Add(Card8) ;
        cards.Add(Card9) ;
        cards.Add(Card10) ;
        cards.Add(Card11) ; 
        cards.Add(Card3);
        cards.Add(Card12) ; 
        cards.Add(Card13) ; 
        cards.Add(Card14) ; 
        cards.Add(Card15) ; 
        cards.Add(Card16) ; 
        cards.Add(Card17) ; 
        cards.Add(Card18) ; 
        cards.Add(Card19) ; 
        cards.Add(Card20) ;
        cards.Add(Card21) ; 
        cards.Add(Card22) ; 
        cards.Add(Card23) ; 
        cards.Add(Card24) ; 



    }

    public void OnClick()
    {
        List<GameObject> playerONeCard = players.PlayerOne.Cards;
        if (takeIt == true)
        {
            //Debug.Log(cards.Count);
        for( var i = 0 ; i < 10; i++)
        {
        int dontRepeat = Random.Range(0,cards.Count);

        GameObject playerCard = Instantiate(cards[dontRepeat],new Vector3(0,0,0),Quaternion.identity);

        playerCard.transform.SetParent(PlayerArea.transform, false);

        players.PlayerOne.AddCard(playerCard);

        cards.RemoveAt(dontRepeat);

        }
    
        takeIt = false;
        }

        else
        {
            foreach(GameObject card in playerONeCard)
            {
                card.SetActive(true);
            }
        }

    }

    public void TakeTwoCards()
    {
        int takingCards;

        if(players.PlayerOne.Cards.Count ==10)
        {
            takingCards = 0 ;
        }
        else if(players.PlayerOne.Cards.Count == 9)
        {
            takingCards = 1 ;
        }
        else
        {
            takingCards = 2 ;
        }

        for( var i = 0; i < takingCards; i++)
        {
            int dontRepeat = Random.Range(0,cards.Count);

            GameObject playerCard = Instantiate(cards[dontRepeat], new Vector3(0,0,0),Quaternion.identity);

            playerCard.transform.SetParent(PlayerArea.transform,false);

            playerCard.GetComponent<CardDisplay>().clickActive = false;

            players.PlayerOne.AddCard(playerCard);

            cards.RemoveAt(dontRepeat);
        }
    }
    

}
