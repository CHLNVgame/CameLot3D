using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {


    public Material nodeEnter;

    private GameObject troop;
    private Renderer rend;
    private Material nodeNormal;


    void Start()
    {
        rend = GetComponent<Renderer>();
        nodeNormal = rend.material;
    }

    void OnMouseDown()
    {
        if (troop != null)
        {
            Debug.Log(" Can't build there");
        }

        GameObject streetFighter = BuildManager.instance.GetStreetFighterToBuild();
        troop = (GameObject)Instantiate(streetFighter, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        if(troop == null)
            rend.material = nodeEnter;
    }
    void OnMouseExit()
    {
        rend.material = nodeNormal;
    }
}
