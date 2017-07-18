using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void InitLevel(int level)
    {
        LoadLevel.instance.SetLevel(level);
     //   Debug.Log(" ++++++++++ ");
        //Application.LoadLevel("level01");
        SceneManager.LoadScene("level01");
     //   Debug.Log(" ------- ");
    }
}
