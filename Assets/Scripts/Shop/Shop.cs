using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {
    public static Shop instance;

    public Transform troopShop;
    public Transform troopSelect;
    public Transform troopBoard;
	
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
    private float[] arrayCostTroop;
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
		
		food = 5;
		maxFood = 1000;
		foodRegend = 15;
		timeRegendFood = 10; // remember modify in function Update() value default
		
        listTroopInGame = new Transform[maxTroopInLevel];
        listFillTroopInGame = new Transform[maxTroopInLevel];
        listTroopCost = new Transform[maxTroopInLevel];
        arrayTroopID = new int[maxTroopInLevel];
        arrayCountDown = new float[maxTroopInLevel];
        arrayTimeNextTroop = new float[maxTroopInLevel];
        arrayCostTroop = new float[maxTroopInLevel];

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
        }

        troopCount = 0;
		
    }
	
	void Update()
    {
		
		RegendFood();
        CountDownNextTroop();
    }
	
	void RegendFood()
	{
		if (buildManager.isPlay)
		{
			timeRegendFood -= Time.deltaTime;
			if(timeRegendFood <= 0)
			{
				timeRegendFood = 10; // remember modify in function Start() value default
				food += foodRegend;
				if(food > maxFood)
					food = maxFood;
				
				Debug.Log(" Food: "+food);
			}
		}
	}
	
	void CountDownNextTroop()
	{
		// Count down to build next troop with same id
        for (int i = 0; i < maxTroopInLevel; i++)
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
            arrayCostTroop[troopCount] = Attributes.FOOD_REQUIRE_TROOP[idTroop];
            listTroopCost[troopCount].GetComponent<Text>().text = arrayCostTroop[troopCount].ToString();


            troopCount++;
        }
    }

    public void PurchaseTroop(string indexTroop)
    {
        idItemShop = int.Parse(indexTroop);

        if (buildManager.isPlay)
        {
			if(buildManager.food >= arrayCostTroop[idItemShop])
				buildManager.SetTroopToBuild(arrayTroopID[idItemShop]);
			else
				Debug.Log(" Food is not enough: "+food);
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

    public void ExitGame()
    {
        Application.Quit();
    }

}
