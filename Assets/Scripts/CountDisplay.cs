using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDisplay : MonoBehaviour
{
    public Text countText; 
    void Start()
    {
        if (countText == null)
        {
            Debug.LogError(" CountText no asignada");
        }
    }

    void Update()
    {
    //    countText.text = "Puntos: " + Game.Instance.Totalpoints.ToString();
    }
}
