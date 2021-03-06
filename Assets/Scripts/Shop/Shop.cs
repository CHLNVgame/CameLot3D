﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public static Shop instance;

    public Transform troopShop;
    public Transform troopSelect;
    public Transform troopBoard;
    public Transform foodShow;
	
	public int food;
	public int maxFood;
	public int foodRegend;
	public float timeRegendFood;

    private Transform[] listTroopInGame;
    private Transform[] listFillTroopInGame;
    private Transform[] listTroopSelect;
    private Transform[] listTroopCost;

    private int[] arrayTroopID;
    private float[] arrayCountDown;
    private float[] arrayTimeNextTroop;
    private int[] arrayCostTroop;
    private int troopCount;
    private int idItemShop;
    private int maxTroopInLevel = 9;
    private int totalTroop;
    private float timeRegen = 7;

    BuildManager buildManager;

    static int[] foodStart = new int[10] {150, 50, 50, 50, 50, 60, 70, 80, 90, 100 };
    static int[] unlockTroop = new int[10] { 1, 2, 2, 3, 0, 0, 0, 0, 0, 0 };

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;
    }

    private void Start()
    {
		buildManager = BuildManager.instance;
        
		food = foodStart[LoadLevel.instance.level - 1];
        maxFood = 1000;
		foodRegend = 25;
		timeRegendFood = timeRegen; // remember modify in function Update() value default
        totalTroop = troopShop.childCount;
        listTroopInGame = new Transform[totalTroop];
        listFillTroopInGame = new Transform[totalTroop];
        listTroopCost = new Transform[totalTroop];
        arrayTroopID = new int[totalTroop];
        arrayCountDown = new float[totalTroop];
        arrayTimeNextTroop = new float[totalTroop];
        arrayCostTroop = new int[totalTroop];

        for (int i = 0; i < listTroopInGame.Length; i++)
        {
            listTroopInGame[i] = troopShop.GetChild(i);
            listFillTroopInGame[i] = listTroopInGame[i].GetChild(0);
            listTroopCost[i] = listTroopInGame[i].GetChild(1);

            arrayTroopID[i] = -1;
            arrayCountDown[i] = 0;
            arrayTimeNextTroop[i] = 1;
            arrayCostTroop[i] = 0;
        }

       

        listTroopSelect = new Transform[troopSelect.childCount];
        for (int i = 0; i < listTroopSelect.Length; i++)
        {
            listTroopSelect[i] = troopSelect.GetChild(i);
            if (i >= unlockTroop[LoadLevel.instance.level -1])
                listTroopSelect[i].gameObject.SetActive(false);
        }

        troopCount = 0;
        ShowFood();


    }
	
	void Update()
    {
        if (buildManager.isPlay)
        {
            timeRegendFood -= Time.deltaTime;
            if (timeRegendFood <= 0)
            {
                timeRegendFood = timeRegen; // remember modify in function Start() value default
                RegendFood(foodRegend);
            }
        }
        ShowFood();
        CountDownNextTroop();
    }
	
	public void RegendFood(int foodValue)
	{
		food += foodValue;
	    if(food > maxFood)
			food = maxFood;	
	}
	
	void CountDownNextTroop()
	{
		// Count down to build next troop with same id
        for (int i = 0; i < totalTroop; i++)
        {
            if (arrayCountDown[i] > 0)
            {
                
                arrayCountDown[i] -= Time.deltaTime;
                if (arrayCountDown[i] < 0)
                    arrayCountDown[i] = 0;
                listFillTroopInGame[i].GetComponent<Image>().fillAmount = arrayCountDown[i] / arrayTimeNextTroop[i];
            }
            else
            {
                listFillTroopInGame[i].gameObject.SetActive(false);
            }
        }
	}

    public void SelectTroopToShop(string id)
    {
        int idTroop = int.Parse(id);

        if (troopCount < maxTroopInLevel)
        {
            listTroopInGame[troopCount].gameObject.SetActive(true);
            listTroopInGame[troopCount].GetComponent<Image>().sprite = listTroopSelect[idTroop].GetComponent<Image>().sprite;
            listTroopSelect[idTroop].GetComponent<Button>().interactable = false;
            arrayTroopID[troopCount] = idTroop;
            arrayTimeNextTroop[troopCount] = Attributes.TIME_NEXT_TROOP[idTroop];
            arrayCostTroop[troopCount] = (int)Attributes.FOOD_REQUIRE_TROOP[idTroop];
            listTroopCost[troopCount].GetComponent<Text>().text = arrayCostTroop[troopCount].ToString();


            troopCount++;
        }
    }

    public void PurchaseTroop(string indexTroop)
    {
        idItemShop = int.Parse(indexTroop);

        if (buildManager.isPlay)
        {
            if (food >= arrayCostTroop[idItemShop] && arrayCountDown[idItemShop] <= 0)
                buildManager.SetTroopToBuild(arrayTroopID[idItemShop]);
            else
            {
                Debug.Log(" Food is not enough: " + food);
            }
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
	
	public void PurchaseFinished()
    {
		food -= arrayCostTroop[idItemShop];
        arrayCountDown[idItemShop] = arrayTimeNextTroop[idItemShop];
        listFillTroopInGame[idItemShop].gameObject.SetActive(true);
    }

    public void ShowFood()
    {
        foodShow.GetComponent<Text>().text = "Food: " + food;
    }

    public void ExitGame()
    {
        //  Application.Quit();
        SceneManager.LoadScene("MainMenu");

    }

}
