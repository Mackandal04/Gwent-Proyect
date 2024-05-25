using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cards : MonoBehaviour
{
    public string zone;
    public Card SOinfo;
    public int points ;
    public int basePoints ;
    public bool wbtc;
    public TMP_Text pointsText;
    void Start()
    {
        SetupCard();
    }
    public void SetupCard()
    {
        points = SOinfo.points;
        basePoints = points;
        wbtc = SOinfo.wbtc;
        
        pointsText.text = points.ToString();

       // Game.Instance.MorePoints(points);
    }
    void Update()
    {
        
    }



    public void RemoveCard()
    {
//        Game.Instance.LessPoints(points);
    }
}
