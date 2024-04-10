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
        public string position ;
        public string description ;
        public string effect ;
        public int points ;
        public Sprite artwork ;
        public Sprite type ;
        public Sprite photo ;
        public string location ;


        public Card ( string name,int id, string position, string description, string effect, int points, Sprite artwork,Sprite type,Sprite photo)
        {
            this.name = name;
            this.id = id ;
            this.position = position ;
            this.description = description;
            this.effect = effect;
            this.points = points;
            this.artwork = artwork;
            this.type = type;
            this. photo= photo ;

        }
    }