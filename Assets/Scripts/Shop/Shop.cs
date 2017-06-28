using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Transform troopShop;
    public Transform troopSelect;
    public Transform troopBoard;

    private Transform[] listTroopInGame;
    private Transform[] listTroopSelect;
    private int[] arrayTroopID;
    private int troopCount;
    private int maxTroopInLevel = 9;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

        listTroopInGame = new Transform[troopShop.childCount];
        arrayTroopID = new int[troopShop.childCount];
        for (int i = 0; i < listTroopInGame.Length; i++)
        {
            listTroopInGame[i] = troopShop.GetChild(i);
            arrayTroopID[i] = -1;
        }

       

        listTroopSelect = new Transform[troopSelect.childCount];
        for (int i = 0; i < listTroopSelect.Length; i++)
        {
            listTroopSelect[i] = troopSelect.GetChild(i);
        }

        troopCount = 0;
    }

    public void SelectTroopToShop(string idTroop)
    {
        int id = int.Parse(idTroop);

        if (troopCount < maxTroopInLevel)
        {
            listTroopInGame[troopCount].gameObject.SetActive(true);
            listTroopInGame[troopCount].GetComponent<Image>().sprite = listTroopSelect[id].GetComponent<Image>().sprite;
            listTroopSelect[id].GetComponent<Button>().interactable = false;
            arrayTroopID[troopCount] = id;
            troopCount++;
        }
    }

    public void PurchaseTroop(string indexTroop)
    {
        int index = int.Parse(indexTroop);

        if (buildManager.isPlay)
        {
            buildManager.SetTroopToBuild(arrayTroopID[index]);
        }
        else
        {
            listTroopSelect[arrayTroopID[index]].GetComponent<Button>().interactable = true;
            for (int i = index; i < troopCount; i++)
            {
                if (i + 1 < troopCount)
                {
                    listTroopInGame[i].GetComponent<Image>().sprite = listTroopInGame[i + 1].GetComponent<Image>().sprite;
                    arrayTroopID[i] = arrayTroopID[i + 1];
                }
                else
                {
                    listTroopInGame[i].gameObject.SetActive(false);
                    arrayTroopID[i] = -1;
                }
            }
            troopCount--;
        }
    }

    public void BeginBattle()
    {
        BuildManager.instance.isPlay = true;
        troopBoard.gameObject.SetActive(false);
    }



}
