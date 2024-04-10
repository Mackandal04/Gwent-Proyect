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
        zoomCard = Instantiate(gameObject, new Vector3(Input.mousePosition.x, Input.mousePosition.y + 270),Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.transform.localScale = zoomScale;
        //zoomCard.layer = LayerMask.NameToLayer("Zoom") ;

        //RectTransform rect = zoomCard.GetComponent<RectTransform>() ;
        //rect.sizeDelta = new Vector2(220,320) ;

        //RectTransform zoomRect = ZoomImage.GetComponent<RectTransform>();
        //zoomRect.sizeDelta = new Vector2(220,320); 

        
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard) ;
    }
}
