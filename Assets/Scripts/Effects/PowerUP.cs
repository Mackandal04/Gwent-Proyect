using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{ 
    public GameObject Weather ;
    public GameObject Zone;
    
    List<Transform> cardsWithEffectApplyList = new List<Transform>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Weather.transform.childCount > 0)
            CheckAndApplyInZone();

        else
            Debug.Log("No tiene hijos");
    }

    private void CheckAndApplyInZone()
    {
        foreach(Transform child in Zone.transform)
        {
            CardDisplay cardComponent = child.GetComponent<CardDisplay>();

            if(cardComponent != null && !cardsWithEffectApplyList.Contains(child))
            {
                cardComponent.card.points += 3;
                Debug.Log("Se aumento en 3 en la AsedioZone");
                cardsWithEffectApplyList.Add(child);
            }

            else
            Debug.Log("No se aumento");
        }
    }

    public void ClearList()
    {
        cardsWithEffectApplyList.Clear();
    }

}
