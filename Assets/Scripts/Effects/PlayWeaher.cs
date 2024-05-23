using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayWeaher : MonoBehaviour
{
    public GameObject Weather;
    public GameObject Zone1;
    public GameObject Zone2;

    public PowerUP powerUP1 ;
    public PowerUP powerUP2 ;
    List<Transform> cardsWithweather = new List<Transform>();
    bool emptyList = false ;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Weather.transform.childCount > 0)
            CheckAndApplyWeather();

        else
            Debug.Log("No tienes climas");
    }

    void CheckAndApplyWeather()
    {
        foreach(Transform child in Zone1.transform)
        {
            CardDisplay cardComponent = child.GetComponent<CardDisplay>();

            if(cardComponent != null && !cardsWithweather.Contains(child))
            {
                cardComponent.card.points = 1;
                Debug.Log("Points == 1");
                cardsWithweather.Add(child);
            }

            else
            Debug.Log("No se aumento");
        }

        foreach(Transform kid in Zone2.transform)
        {
            CardDisplay cardComponent = kid.GetComponent<CardDisplay>();

            if(cardComponent != null && !cardsWithweather.Contains(kid))
            {
                cardComponent.card.points = 1;
                Debug.Log("Points == 1");
                cardsWithweather.Add(kid);
            }

            else
            Debug.Log("No se aumento");
        }

    if(emptyList == false)
    {
        powerUP1.ClearList();
        Debug.Log("se vacio 1");
        powerUP2.ClearList();
        Debug.Log("se vacio 2");
    }
    emptyList = true ;
    }
}
