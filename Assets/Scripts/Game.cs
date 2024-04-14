using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public int Totalpoints = 0;



    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void MorePoints(int points)
    {
        Totalpoints += points;
    }

    public void LessPoints( int points)
    {
        Totalpoints -= points;
    }
}
