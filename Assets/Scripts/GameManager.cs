using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Star;
    public GameObject board;
    private static bool IsYourTurn = true;
    private static bool PlayerOneEndTurn ;
    private static bool PlayerTwoEndTurn ;
    public int PlayerOneTotalPoints ;
    public int PlayerTwoTotalPoints ;
    public static int Rounds = 3 ;
    public static int PlayerOneRoundsVictories;
    public static int PlayerTwoRoundsVictories;
    public GameObject readyPlayerOne;
    public GameObject readyPlayerTwo;
    public GameObject BtoBZone ;
    public GameObject DistanceZone;
    public GameObject AsedioZone;
    public GameObject BtoBRivalZone;
    public GameObject DistanceRivalZone;
    public GameObject AsedioRivalZone;
    public GameObject Graveyard;
    public GameObject GraveyardTwo;
    private List <GameObject>PlayerOneRows = new List<GameObject>(3);
    private List <GameObject>PlayerTwoRows= new List<GameObject>(3);
    public GameObject PlayerOneYouWin ;
    public GameObject PlayerTwoYouWin ;
    public GameObject Replay ;

    void Start()
        {
            PlayerOneRows.Add(BtoBZone);
            PlayerOneRows.Add(DistanceZone);
            PlayerOneRows.Add(AsedioZone);
            PlayerTwoRows.Add(BtoBRivalZone);
            PlayerTwoRows.Add(DistanceRivalZone);
            PlayerTwoRows.Add(AsedioRivalZone);
        }

    public static void ChangeRound()
    {
        Debug.Log("Entro a change");
        Players players = GameObject.FindObjectOfType<Players>();

        List<GameObject> PlayerOneCard = players.PlayerOne.Cards;

        List<GameObject> PlayerTwoCard = players.PlayerTwo.Cards;
        if(IsYourTurn == true)
        {
            PlayerOneEndTurn = true;
        
            foreach(GameObject card in PlayerOneCard)
            {
                card.SetActive(false);
            }
                if(PlayerTwoEndTurn == false)
                    {
                        GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                        gameManager.readyPlayerTwo.SetActive(true);
                    }
                    IsYourTurn = false;
        }
        else if(IsYourTurn == false)
            {
                Debug.Log("Turnodel1");
                PlayerTwoEndTurn = true;
//                Debug.Log(PlayerTwoEndTurn);
                foreach(GameObject card in PlayerTwoCard)
                    {
//                        Debug.Log(PlayerTwoCard.Count);
                        card.SetActive(false);
                    }
            if(PlayerOneEndTurn == false)
                {
                    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                    gameManager.readyPlayerOne.SetActive(true);
                }
                IsYourTurn = true;
            }

        if(PlayerOneEndTurn == true && PlayerTwoEndTurn == true)
            {
                GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                gameManager.LookingforWinner();
                if(Rounds == 0)
                {
                    Debug.Log("Llevan tres rondas ");
                    gameManager.EndGame();
                }

                else
                {
                    
                // gameManager.Replay.SetActive(true);
                    Draw draw = GameObject.Find("GameManager").GetComponent<Draw>();
                    draw.TakeTwoCards();
                    DrawDeckTwo drawTwo = GameObject.Find("GameManager").GetComponent<DrawDeckTwo>();
                    drawTwo.TakeTwoCards();
                    GameObject temporalCard = PlayerOneCard[1] ;
                    CardDisplay temporalCardDsiplay = temporalCard.GetComponent<CardDisplay>();
                    temporalCardDsiplay.DragActive();
                    PlayerOneEndTurn = false;
                    PlayerTwoEndTurn = false;
                        foreach(GameObject card in PlayerOneCard )
                            {
                                card.SetActive(false);
                            }
                        foreach(GameObject card in PlayerTwoCard )
                            {
                                card.SetActive(false);
                            }

                }

            
                }
    }


    public static void FieldCleaner()
    {
        for(int i = 0; i <3; i++)
            {
                GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                foreach(GameObject row in gameManager.PlayerOneRows)
                {
                    foreach(Transform card in row.transform)
                    {
                        CardDisplay currentCard = card.GetComponent<CardDisplay>();

                        if(currentCard != null)
                        {
                            card.SetParent(gameManager.Graveyard.transform, true);
                        }
                    }
                }

                foreach(GameObject row in gameManager.PlayerTwoRows)
                {
                    foreach(Transform card in row.transform)
                    {
                        CardDisplay currentCard = card.GetComponent<CardDisplay>();

                        if(currentCard != null)
                        {
                            card.SetParent(gameManager.GraveyardTwo.transform, true);
                        }
                    }
                }
            }
    }
    public  void LookingforWinner()
        {
            
            if(PlayerOneTotalPoints<=PlayerTwoTotalPoints)
                {
                    Rounds -- ;
                    PlayerOneRoundsVictories++;
                    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                    gameManager.readyPlayerOne.SetActive(true);
                    gameManager.readyPlayerTwo.SetActive(false);
                    GameManager.FieldCleaner();
                    if(IsYourTurn == false)
                        {
                            IsYourTurn = true;
                        }
                        GameObject StarPhoto = Instantiate (gameManager.Star, gameManager.board.transform,false); 
                        StarPhoto.transform.localPosition = new Vector3(-336, 349,0);
                }
            else 
            {
                Rounds -- ;
                PlayerTwoRoundsVictories++;
                GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                    gameManager.readyPlayerOne.SetActive(false);
                    gameManager.readyPlayerTwo.SetActive(true);
                    GameManager.FieldCleaner();
                    if(IsYourTurn == true)
                        {
                            IsYourTurn = false;
                        }
                    GameObject StarPhoto = Instantiate (gameManager.Star, gameManager.board.transform,false); 
                        StarPhoto.transform.localPosition = new Vector3(-336, -306,0);
            }
        }

        public void EndGame()
        {
            Debug.Log("Se llamo al EndGAme");
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            if( PlayerOneRoundsVictories > PlayerTwoRoundsVictories)
            {
               // GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                gameManager.PlayerOneYouWin.SetActive(true);

            }

            else
            {
              //  GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                gameManager.PlayerTwoYouWin.SetActive(true);
            } 

            ResetGame();

        }

            public static void ResetGame()
                {
                    GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                    gameManager.Replay.SetActive(true); 
                    
                    //ResetVariables();
                    SceneManager.LoadScene("Menu");

                    ResetVariables();
                }
                public static void ResetVariables()
                {
                   // GameManager gameManagerInstance = this;

                    IsYourTurn = true;
                    PlayerOneEndTurn = false;
                    PlayerTwoEndTurn = false;
                    GameManager gameManagerInstance = FindObjectOfType<GameManager>();

                    if(gameManagerInstance != null)
                    {
                        gameManagerInstance.PlayerOneTotalPoints = 0;
                        gameManagerInstance.PlayerTwoTotalPoints = 0;
                    }
                    
                    Rounds = 3;
                    PlayerOneRoundsVictories = 0;
                    PlayerTwoRoundsVictories = 0;

                    // Restablecer objetos visuales
                    //readyPlayerOne.SetActive(false);
                    //readyPlayerTwo.SetActive(false);
                    // Asumiendo que quieres restablecer todas las zonas a su estado inicial
                    // BtoBZone.SetActive(false);
                    // DistanceZone.SetActive(false);
                    // AsedioZone.SetActive(false);
                    // BtoBRivalZone.SetActive(false);
                    // DistanceRivalZone.SetActive(false);
                    // AsedioRivalZone.SetActive(false);
                    // Graveyard.SetActive(false);
                    // GraveyardTwo.SetActive(false);

                }
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
                if(PlayerOneCard.Count == 0)
                    {
                        ChangeRound();
                        return;
                    }
                if(PlayerTwoEndTurn == true)
                {
                    return;
                }
                foreach(GameObject card in PlayerOneCard)
                    {
                        card.SetActive(false);
                    }

                GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                gameManager.readyPlayerTwo.SetActive(true);

                IsYourTurn = false ;
            }

        else
            {
                PlayerTwoCard.Remove(actualCard);
                if(PlayerTwoCard.Count == 0)
                    {
                        ChangeRound();
                        return;
                    }
                if(PlayerOneEndTurn == true)
                {
                    return;
                }
                foreach(GameObject card in PlayerTwoCard)
                    {
//                        Debug.Log(PlayerTwoCard.Count);
                        card.SetActive(false);
                    }

                GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
                gameManager.readyPlayerOne.SetActive(true); 

                IsYourTurn = true;
            }
    }
}
