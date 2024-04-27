using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
[System.Serializable]


[CreateAssetMenu(fileName = "New Card" , menuName = "Card")] 
    
    public class Card : ScriptableObject
    {
        public new string name ;
        public int id ;
        public string position , description , effect ;
        public int points ;
        public string zone;
       // public Sprite artwork ;
       // public Sprite type ;
        public Sprite photo ;
        public Sprite foto ;
        //public string location ;

        public bool wbtc; //Who belong this card

    }