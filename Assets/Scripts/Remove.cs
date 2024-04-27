using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remove : MonoBehaviour
{

    public GameObject playerVerification ;

    public Button readyButton;
    void Start()
    {
        readyButton.onClick.AddListener(RemoveImage);
    }



    void RemoveImage ()
    {
        playerVerification.SetActive(false);
    }



    void Update()
    {
        
    }
}
