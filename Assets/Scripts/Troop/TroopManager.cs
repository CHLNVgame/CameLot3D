﻿using System.Collections;
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

	public bool isRun;
	public Animator anim;
	public float speedSlow;
	public float speedNormal;
	public Transform target;
	public const string actionRun ="run";
	public const string actionIdle ="idle";
	public const string actionAttack = "attack";
	public const string actionAttackSpec = "attackspec";
	public const string actionDefend = "defend";
	public const string actionBuff = "buff";
	public const string actionHurt = "hurt";

	string enemyTag = "Enemy";

	void Start () {
		anim = GetComponent<Animator> ();
		isRun = false;

		anim.Play (actionIdle);

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}

	void UpdateTarget()
	{
		// Target on Lane
		Vector3 checkTarget = transform.position + Vector3.up/2;
		Debug.DrawLine (checkTarget, checkTarget + Vector3.right*range, Color.red);
		Ray ray = new Ray (checkTarget, Vector3.right);
		RaycastHit[] hits = Physics.RaycastAll(ray, range);

		foreach (RaycastHit hit in hits) 
		{
			if (hit.transform.tag.Equals (enemyTag)) {
				target = hit.transform;
			//	target = hit.transform.GetComponent<EnemyManager> ().posHit;
				Debug.DrawLine (hit.point, hit.point + Vector3.up*4, Color.blue);
			}
		}
	}

	public void TakeDamge(int value)
	{
		anim.Play (actionHurt);
		//Destroy (gameObject);
	}
}