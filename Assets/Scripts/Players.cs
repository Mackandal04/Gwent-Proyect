using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Players : MonoBehaviour
{
    public class Player
    {
        public List <GameObject> Cards = new List<GameObject>();

        public void AddCard(GameObject card)
        {
            Cards.Add(card);
        }
    }

    public Player PlayerOne = new Player();

    public Player PlayerTwo = new Player();
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
