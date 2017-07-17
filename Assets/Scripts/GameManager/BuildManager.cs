using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
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
        FreeCursor();
    }
    private GameObject troopToBuild;

    public void SetTroopToBuild(int index)
    {
        troopToBuild = LoadPrefab.instance.troopPrefab[index];
    }

    public GameObject GetTroopToBuild()
    {
        return troopToBuild;
    }

    public void FreeCursor()
    {
        troopToBuild = null;
    }

    public bool CheckTroopToBuild()
    {
        return troopToBuild != null ? true : false;
    }
}
