using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceControl : MonoBehaviour
{
    private bool played = false ;

    public void IsPlayed()
    {
        if(!played)
        {
            played = true;
        }
    }

    public void StayDown()
    {
        if (!played)
        {
            
        }
    }
}
