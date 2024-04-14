using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cards : MonoBehaviour
{
    public string zone;
    //public CardType cardType;
    public Card SOinfo;
    public int points ;
    //public string zone ;
    public TMP_Text pointsText;
    void Start()
    {
        SetupCard();
    }
    public void SetupCard()
    {
        points = SOinfo.points;
       // zone = SOinfo.zone;


        pointsText.text = points.ToString();
    }
    void Update()
    {
        
    }
}
