using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Average : CardEffect
{
    public GameObject[] Zones;
    private List<int> powers = new List<int>();

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

    public void SearchingPower()
    {
        foreach(GameObject zone in Zones)
        {
            foreach(Transform child in zone.transform)
            {
                CardDisplay cardDisplay = child.GetComponent<CardDisplay>();
                powers.Add(cardDisplay.points);
            }
        }
    }

    public void CalculateAverage()
    {
        if(powers.Count > 0)
        {
            float average = 0f;
            foreach(int value in powers)
                average += value;

            average /= powers.Count;

            foreach(CardDisplay cardDisplay in FindObjectsOfType<CardDisplay>())
                cardDisplay.points = Mathf.RoundToInt(average); //Asigna el valor redondeado de average a points de CardDsiplay
        }

        else
            Debug.Log("No hay points");
    }

    public override void ActivateEffect()
    {
        SearchingPower();
        CalculateAverage();
    }
}
