using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDisplay : MonoBehaviour
{
    public Text scoreText; // Referencia al componente Text del objeto de UI
    void Start()
    {
        // Asegúrate de que la referencia al componente Text esté asignada en el Inspector de Unity
        if (scoreText == null)
        {
            Debug.LogError("ScoreText no está asignado en el Inspector.");
        }
    }

    void Update()
    {
        // Actualiza el texto del contador de puntos
        scoreText.text = "Puntos: " + Game.Instance.Totalpoints.ToString();
    }
}
