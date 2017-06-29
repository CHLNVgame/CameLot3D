using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public static Shop instance;

    public Transform troopShop;
    public Transform troopSelect;
    public Transform troopBoard;

    private Transform[] listTroopInGame;
    private Transform[] listFillTroopInGame;
    private Transform[] listTroopSelect;
    private int[] arrayTroopID;
    private float[] arrayCountDown;
    private float[] arrayTimeCountDown;
    private int troopCount;
    private int idItemShop;
    private int maxTroopInLevel = 9;

    BuildManager buildManager;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start()
    {

        buildManager = BuildManager.instance;
        listTroopInGame = new Transform[maxTroopInLevel];
        listFillTroopInGame = new Transform[maxTroopInLevel];
        arrayTroopID = new int[maxTroopInLevel];
        arrayCountDown = new float[maxTroopInLevel];
        arrayTimeCountDown = new float[maxTroopInLevel];

        for (int i = 0; i < listTroopInGame.Length; i++)
        {
            listTroopInGame[i] = troopShop.GetChild(i);
            listFillTroopInGame[i] = listTroopInGame[i].GetChild(0);

            arrayTroopID[i] = -1;
            arrayCountDown[i] = 0;
            arrayTimeCountDown[i] = 1;
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
        idItemShop = int.Parse(indexTroop);

        if (buildManager.isPlay)
        {
            buildManager.SetTroopToBuild(arrayTroopID[idItemShop]);
        }
        else
        {
            listTroopSelect[arrayTroopID[idItemShop]].GetComponent<Button>().interactable = true;
            for (int i = idItemShop; i < troopCount; i++)
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

    void Update()
    {
        // Count down to build next troop with same id
        for (int i = 0; i < maxTroopInLevel; i++)
        {
            if (arrayCountDown[i] > 0)
            {
                
                arrayCountDown[i] -= Time.deltaTime;
                if (arrayCountDown[i] < 0)
                    arrayCountDown[i] = 0;
                Debug.Log(" arrayCountDown[i]: " + arrayCountDown[i]);
                listFillTroopInGame[i].GetComponent<Image>().fillAmount = arrayCountDown[i] / arrayTimeCountDown[i];
            }
            else
            {
            //    Debug.Log(" arrayCountDown[i]: " + arrayCountDown[i]);
                listFillTroopInGame[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetTimeCountDown(float time)
    {
        Debug.Log(" +++++++++++++++++++++ time: " + time);
        arrayTimeCountDown[idItemShop] = time;
        arrayCountDown[idItemShop] = time;
        listFillTroopInGame[idItemShop].gameObject.SetActive(true);
    }



}
