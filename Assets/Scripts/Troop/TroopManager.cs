using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour {

	public int damge;
	public void TakeDamge(int value)
	{
		Destroy (gameObject);
	}
}