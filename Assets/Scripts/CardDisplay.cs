using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card ;
    public TMP_Text nameText ;
    public TMP_Text descriptionText ;
    public TMP_Text pointsText ;
  //  public Image artworkImage ;
  //  public Image typeImage ;
    public Image photoImage ;
    public Image cImage;
    public string position ;


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
