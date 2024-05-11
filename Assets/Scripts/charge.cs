using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charge : MonoBehaviour
{
    public void OnClick()
    {
        ChargeScene();
    }
    void ChargeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

