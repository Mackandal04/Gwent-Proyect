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
        zoomCard = Instantiate(gameObject, new Vector3(110, 470),Quaternion.identity);
        zoomCard.transform.SetParent(Canvas.transform, false);
        zoomCard.layer = LayerMask.NameToLayer("Zoom");
        RectTransform rect = zoomCard.GetComponent<RectTransform>();
        rect.localScale =zoomScale;
        foreach (Transform child in zoomCard.transform)
        {
            RectTransform childRect = child.GetComponent<RectTransform>();
            if( childRect != null)
            {
                rect.sizeDelta = new Vector2(zoomScale.x ,zoomScale.y) ;
            
            }
        }

        rect.sizeDelta = new Vector2(zoomScale.x ,zoomScale.y) ;

        
    }

    public void OnHoverExit()
    {
    Destroy(zoomCard) ;
    }
}
