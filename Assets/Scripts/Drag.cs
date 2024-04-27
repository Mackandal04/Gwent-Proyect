using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject Canvas ;
    private bool isDragging = false ;
    private bool isOverDropZone = false ;
    private GameObject dropZone ;
    private GameObject startParent;
    private Vector2 starPosition ;

    public bool dick ;

    private void Awake ()
    {
        Canvas = GameObject.Find("Main Canvas");
    }
    void Update()
    {
        if(!dick)
        {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x,Input.mousePosition.y) ;
            transform.SetParent( Canvas.transform , true);
        }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true ;
        dropZone = collision.gameObject ;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false ;
        dropZone = null ;
    }

    public void StartDrag()
    {
        startParent = transform.parent.gameObject ;
        starPosition = transform.position ;

        isDragging = true ;

        //Cuando llamemos a este metodo queremos que este nuevo V2 sea = transform.position
        // y queremos cambiar isDragging to true 
    }

    public void EndDrag() 
    {

        isDragging = false ;
        if( isOverDropZone && CanPlay() &&  dick == false )
        {
            dick = true ;
            transform.position = dropZone.transform.position + new Vector3(0, 0, 0); 
        transform.SetParent(dropZone.transform, false);
            transform.SetParent(dropZone.transform, false) ;

            GameManager.Turns(gameObject,gameObject.GetComponent<CardDisplay>().card.wbtc);
        }
        else
        {
            transform.position = starPosition ;
            transform.SetParent(startParent.transform,false) ;
        }
    }
    public bool CanPlay ()
    {
        ZoneName conditional = dropZone.GetComponent<ZoneName>() ;
        string first = conditional.zoneName;
        string second = gameObject.GetComponent<CardDisplay>().position;
        if(first == second)
        {
            return true ;
        }
        else
        {
            return false ;
        }
    } 
}
