using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTheWeakAdventure : CardEffect
{
    public GameObject[] Zones;
    private Card card;
    void Start()
    {
        Zones = new GameObject[] { GameObject.Find("BtoB Rival Zone"),
        GameObject.Find("Distance Rival Zone "),
        GameObject.Find("Asedio Rival Zone") };

    }

    void Update()
    {
        
    }

    public GameObject FindTheWeakOne()
    {
        GameObject weakAdventure = null;
        
        int maxPoints = 999999;
        
        foreach( var zone in Zones)
        {
            CardDisplay[] cardsInZone = zone.GetComponentsInChildren<CardDisplay>();

            foreach(var card in cardsInZone)
            {
                if(card.card.points < maxPoints)
                {
                    maxPoints = card.card.points;
                    weakAdventure = card.gameObject;
                }
            }
        }
        return weakAdventure;
    }

    public override void ActivateEffect()
    {
        GameObject weakAdventure = FindTheWeakOne();

        if(weakAdventure != null)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            weakAdventure.transform.SetParent(gameManager.GraveyardTwo.transform, false);
        }

    }
}
