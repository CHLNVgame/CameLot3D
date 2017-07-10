using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefab : MonoBehaviour {

    public static LoadPrefab instance;

    public GameObject[] listEnemyPrefab;
    public GameObject[] troopPrefab;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
