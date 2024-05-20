using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PowersUp : MonoBehaviour
{
    public string rowZone;
    public int pointsUp = 2;
    void Start()
    {
        PowerUp();
    }

    public void PowerUp()
    {
        GameObject[] cardsInRow = GameObject.FindGameObjectsWithTag(rowZone);

        foreach (GameObject card in cardsInRow)
        {
            TMP_Text pointsText = card.GetComponentInChildren<TMP_Text>();
            Card cardData =card.GetComponent<Card>();

            if(pointsText != null && cardData != null)
            {
                int currentPoints = cardData.points;
                cardData.points += pointsUp; // Aumenta los puntos de la carta
                pointsText.text = cardData.points.ToString(); // Actualiza el texto de los puntos en la UI
            }
        }
    }
}
