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

    public GameObject standardStreetFighterPrefab;

    private void Start()
    {
        isPlay = false;
        streetFighterToBuild = standardStreetFighterPrefab;
    }
    private GameObject streetFighterToBuild;

    public GameObject GetStreetFighterToBuild()
    {
        return streetFighterToBuild;
    }
}
