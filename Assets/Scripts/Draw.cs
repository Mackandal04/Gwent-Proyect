using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    public GameObject Card1 ;
    public GameObject Card2 ;
    public GameObject Card3 ;
    /*   public GameObject Card3 ;
    public GameObject Card4 ;
    public GameObject Card5 ;
    public GameObject Card6 ;
    public GameObject Card7 ;
    public GameObject Card8 ;
    public GameObject Card9 ;
    public GameObject Card10 ;
    public GameObject Card11 ;  */
    public GameObject PlayerArea ;

    List<GameObject> cards = new List<GameObject>() ;
    void Start()
    {
        cards.Add(Card1) ;
        cards.Add(Card2) ;
        cards.Add(Card3) ;
        /* cards.Add(Card3) ;
        cards.Add(Card4) ;
        cards.Add(Card5) ;
        cards.Add(Card6) ;
        cards.Add(Card7) ;
        cards.Add(Card8) ;
        cards.Add(Card9) ;
        cards.Add(Card10) ;
        cards.Add(Card11) ;  */

    }

    public void OnClick()
    {
        for( var i = 0 ; i < 10; i++)
        {
        GameObject playerCard = Instantiate(cards[Random.Range(0,cards.Count)],new Vector3(0,0,0),Quaternion.identity);

        playerCard.transform.SetParent(PlayerArea.transform, false);

        }
    }
    

}
