using System.Collections;
using System.Net.Mime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using System.Numerics;

public class CardDisplay : MonoBehaviour
{
    public static List <GameObject> cardsSelection = new List<GameObject>();
    public Card card ;
    public TMP_Text nameText ;
    public TMP_Text descriptionText ;
    public TMP_Text pointsText ;
  //  public Image artworkImage ;
  //  public Image typeImage ;
    public Image photoImage ;
    public Image cImage;
    public int points;
    public string position ;

    private static GameObject lastCardsSelection = null ;

    public bool clickActive = true ;



    
    public void OnClick ()
    {

      if( clickActive == true)
      {

        if ( gameObject == lastCardsSelection)
        {
          return;
        }

        cardsSelection.Add(gameObject);

        lastCardsSelection = gameObject; 



        if(cardsSelection.Count == 2)
        {
          foreach (var cardDisplay in FindObjectsOfType<CardDisplay>())
          {
            cardDisplay.clickActive = false;
          }

          GameManager.ChangeCard(cardsSelection,gameObject.GetComponent<CardDisplay>().card.wbtc, gameObject);

          cardsSelection.Clear();

        

        }

      }

    }

    public void DragActive()
    {
      CardDisplay[] dragActivate = FindObjectsOfType<CardDisplay>();

      foreach( CardDisplay card in dragActivate)
      {
        Drag dragComponent = card.GetComponent<Drag>();

        if (dragComponent != null)
        {
          dragComponent.enabled = true;
        }
      }
    }

    void Start()
    {
        //location = card.location ;
       // artworkImage.sprite = card.artwork ;
        photoImage.sprite = card.photo ;
       // typeImage.sprite = card.type;
        cImage.sprite = card.foto;
        nameText.text = card.name;
        descriptionText.text  = card.description ;
        pointsText.text = card.points.ToString() ; 
    }
}
