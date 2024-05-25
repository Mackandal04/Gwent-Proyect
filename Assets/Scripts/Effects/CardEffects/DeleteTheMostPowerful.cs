using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.IK;

public class DeleteTheMostPowerful : CardEffect
{ 
    public GameObject[] Zones;
    private Card card;

    void Start()
    {
    Zones = new GameObject[] { GameObject.Find("BtoB Zone"),
    GameObject.Find("BtoB Rival Zone"),GameObject.Find("DistanceZone"), 
    GameObject.Find("Distance Rival Zone "), GameObject.Find("AsedioZone"), 
    GameObject.Find("Asedio Rival Zone") };

    }

    void Update()
    {
    
    }

    public GameObject FindThePowerful()
    {
        GameObject powerfulCard = null;
        
        int maxPoints = 0;
        
        foreach( var zone in Zones)
        {
            CardDisplay[] cardsInZone = zone.GetComponentsInChildren<CardDisplay>();

            foreach(var card in cardsInZone)
            {
                if(card.card.points >maxPoints)
                {
                    maxPoints = card.card.points;
                    powerfulCard = card.gameObject;
                }
            }
        }
        return powerfulCard;
    }

    public override void ActivateEffect()
    {
        GameObject powerfulCard = FindThePowerful();

        if(powerfulCard != null)
        {
            bool wbtcValue = powerfulCard.GetComponent<Cards>().wbtc;

            if(wbtcValue == true)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                
                powerfulCard.transform.SetParent(gameManager.Graveyard.transform, false);
            }
            else
            {
                GameManager gameManager = FindObjectOfType<GameManager>();

                powerfulCard.transform.SetParent(gameManager.GraveyardTwo.transform, false);
            }

        }
    }
    
}
