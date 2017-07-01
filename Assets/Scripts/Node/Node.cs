using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {


    public Material nodeEnter;

    private GameObject troop;
    private Renderer rend;
    private Material nodeNormal;

    BuildManager buildManager;
    void Start()
    {
        rend = GetComponent<Renderer>();
        nodeNormal = rend.material;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (!BuildManager.instance.isPlay)
            return;

        if (troop != null)
        {
            Debug.Log(" Can't build there");
        }

        GameObject troopPrefab = buildManager.GetTroopToBuild();
        troop = (GameObject)Instantiate(troopPrefab, transform.position, transform.rotation);

        TroopManager troopSrc = troop.GetComponent<TroopManager>();
        Shop.instance.PurchaseFinished();

        buildManager.FreeCursor(); // Free Cursor when build done
    }

    void OnMouseEnter()
    {
        if(troop == null && buildManager.CheckTroopToBuild())
            rend.material = nodeEnter;
    }
    void OnMouseExit()
    {
        rend.material = nodeNormal;
    }
}
