using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour {

	public int hp;
	public int speed;
	public int damge;
	public int damgeSpec;
	public float range;
	public float attackDelay;

	public int foodRequire;
	public float timeNextTroop;
	public float ratioSpecSkill;

	public void TakeDamge(int value)
	{
		Destroy (gameObject);
	}
}