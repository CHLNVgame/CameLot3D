using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    public GameObject[] troopPrefab;
    public bool isPlay;



    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }

    private void Start()
    {
        isPlay = false;
    }
    private GameObject troopToBuild;

    public void SetTroopToBuild(int index)
    {
        troopToBuild = troopPrefab[index];
    }

    public GameObject GetTroopToBuild()
    {
        return troopToBuild;
    }
}
