using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomCards : MonoBehaviour
{
    public GameObject Canvas ;
    private GameObject zoomCard ;

    public GameObject ZoomImage ;
    private Vector2 zoomScale = new Vector2(3,3);

    public void Awake ()
    {
        Canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter()
    {
        zoomCard = Instantiate(gameObject, new Vector3(125, 470),Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.localScale =zoomScale;
        //Image[] images = zoomCard.GetComponentsInChildren<Image>();
        foreach (Transform child in zoomCard.transform)
        {
            RectTransform childRect = child.GetComponent<RectTransform>();
            if( childRect != null)
            {
                rect.sizeDelta = new Vector2(zoomScale.x ,zoomScale.y) ;
                //childRect.localScale = new Vector2(zoomScale.x ,zoomScale.y) ;
            }
            //Vector2 newSize = new Vector2(rect.rect.width * zoomScale.x, rect.rect.height * zoomScale.y);
            //image.rectTransform.localScale = zoomScale;
        }

        //zoomCard.transform.localScale = zoomScale;
        //zoomCard.layer = LayerMask.NameToLayer("Zoom") ;

        //RectTransform rect = zoomCard.GetComponent<RectTransform>() ;
        rect.sizeDelta = new Vector2(zoomScale.x ,zoomScale.y) ;

       // RectTransform rect = ZoomImage.GetComponent<RectTransform>();
        //rect.sizeDelta = new Vector2(220,320); 

        
    }

    public void OnHoverExit()
    {
    Destroy(zoomCard) ;
    }
}
