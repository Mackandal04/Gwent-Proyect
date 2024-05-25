using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTheWeakSimpsom : CardEffect
{
    public GameObject[] Zones;
    private Card card;
    void Start()
    {
        Zones = new GameObject[] { GameObject.Find("BtoB Zone"),
        GameObject.Find("DistanceZone"),
        GameObject.Find("AsedioZone")};
    }

    void Update()
    {
        
    }

    public GameObject FindTheWeakOne()
    {
        GameObject weakSimpsom = null;
        
        int maxPoints = 999999;
        
        foreach( var zone in Zones)
        {
            CardDisplay[] cardsInZone = zone.GetComponentsInChildren<CardDisplay>();

            foreach(var card in cardsInZone)
            {
                if(card.card.points < maxPoints)
                {
                    maxPoints = card.card.points;
                    weakSimpsom = card.gameObject;
                }
            }
        }
        return weakSimpsom;
    }

    public override void ActivateEffect()
    {
        GameObject weakSimpsom = FindTheWeakOne();

        if(weakSimpsom != null)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            weakSimpsom.transform.SetParent(gameManager.Graveyard.transform, false);
        }

    }
}
