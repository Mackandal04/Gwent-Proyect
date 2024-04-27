using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Count : MonoBehaviour
{
    public GameObject[] cardRows; // Las tres filas del juego
    public TMP_Text totalPointsText;
    private int totalPoints = 0;

    void Start()
    {
        CalculateTotalPoints();
        UpdateTotalPointsText();
    }

    void CalculateTotalPoints()
    {
        totalPoints = 0;
        foreach (GameObject row in cardRows)
        {
            // Suponiendo que cada GameObject en la fila tiene un componente CardDisplay
            CardDisplay[] cards = row.GetComponentsInChildren<CardDisplay>();
            foreach (CardDisplay card in cards)
            {
                totalPoints += card.card.points; // Asumiendo que 'points' es una propiedad pública en CardDisplay
                Debug.Log(totalPoints);
            }
            UpdateTotalPointsText();
        }
    }
    void UpdateTotalPointsText()
    {
        totalPointsText.text = totalPoints.ToString();
    }

    void Update()
    {
        CalculateTotalPoints();
    }
}
