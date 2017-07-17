using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {


    public Material nodeEnter;

    private GameObject troop;
    private Renderer rend;
    private Material nodeNormal;

    BuildManager buildManager;
    TroopManager troopSrc;
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

        if (troop != null && !troopSrc.isDie)
        {
            Debug.Log(" Can't build there");
            return;
        }

        GameObject troopPrefab = buildManager.GetTroopToBuild();
        if (troopPrefab != null)
        {
            troop = (GameObject)Instantiate(troopPrefab, transform.position, transform.rotation);

            troopSrc = troop.GetComponent<TroopManager>();
            Shop.instance.PurchaseFinished();

            buildManager.FreeCursor(); // Free Cursor when build done
        }
    }

    void OnMouseEnter()
    {
        if ((troop == null && buildManager.CheckTroopToBuild()) || (troopSrc != null && troopSrc.isDie))
            rend.material = nodeEnter;
    }
    void OnMouseExit()
    {
        rend.material = nodeNormal;
    }
}
