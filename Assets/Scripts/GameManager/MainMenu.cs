using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {


	public void InitLevel(int level)
    {
        LoadLevel.instance.SetLevel(level);
        Debug.Log(" ++++++++++ ");
        Application.LoadLevel("level01");
        Debug.Log(" ------- ");
    }
}
