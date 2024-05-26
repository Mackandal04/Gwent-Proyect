using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanZone : CardEffect
{
    public GameObject[] Zones;
    private Card card;
    void Start()
    {
        Zones = new GameObject[] { GameObject.Find("BtoB Zone"),
        GameObject.Find("BtoB Rival Zone"),GameObject.Find("DistanceZone"), 
        GameObject.Find("Distance Rival Zone "), GameObject.Find("AsedioZone"), 
        GameObject.Find("Asedio Rival Zone") };
    }

    void Update()
    {
        
    }

    public void FindTheBrothers()
    {
        GameObject minChildrenZone = null;
        List<GameObject> childrenList = new List<GameObject>();
        int minChildren = int.MaxValue;
        
        foreach(GameObject zone in Zones)
        {
            if(zone.transform.childCount > 0 && zone.transform.childCount <minChildren )
            {
                minChildren = zone.transform.childCount;
                minChildrenZone = zone;
                childrenList.Clear();
            }

            if(zone.transform.childCount <= minChildren)
            {
                foreach(Transform child in zone.transform)
                    childrenList.Add(child.gameObject);
            }
        }

        if(minChildrenZone != null)
          //  DestroyBrothers(minChildrenZone);
            ProcessChildrenList(childrenList,minChildrenZone);

    }
        void ProcessChildrenList(List<GameObject> childrenList,GameObject minChildrenZone)
        {
            GameObject graveyard = GameObject.Find("Graveyard");
            GameObject graveyardTwo = GameObject.Find("GraveyardTwo");

            foreach(GameObject child in childrenList)
            {
                bool wbtcValue = child.GetComponent<Cards>().wbtc;

               // GameManager gameManager = FindObjectOfType<GameManager>();

                if(wbtcValue == true)
                    child.transform.SetParent(graveyard.transform, false);

                else
                    child.transform.SetParent(graveyardTwo.transform, false);    
            }
        }


    public override void ActivateEffect()
    {
        FindTheBrothers();
    }
}
