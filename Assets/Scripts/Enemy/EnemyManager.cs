﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	[Header("Settings")]
	public int hp;
	public float speed;
	public int damge;
	public float range;
	public float attackDelay = 10.0f;

	[Header("View")]
	public bool isRun;
	public bool isAttack;
	public Animator anim;
	public float speedSlow;
	public float speedNormal;
	public Transform target;
	public const string actionRun ="run";
	public const string actionAttack = "attack";
	public const string actionDefend = "defend";
	public const string actionBuff = "buff";

	string stroopTag = "Troop";

	// Use this for initialization
	void Start () {
		isRun = true;
		speedSlow = speed/2;
		speedNormal = speed;
		anim = GetComponent<Animator> ();
		anim.Play (actionRun);

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}

	void UpdateTarget()
	{
/*
		// Target on Radius
		GameObject[] troops = GameObject.FindGameObjectsWithTag (stroopTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestTroop = null;

		foreach(GameObject troop in troops)
		{
			float distanceToTroop = Vector3.Distance (transform.position, troop.transform.position);
			if (distanceToTroop < shortestDistance) 
			{
				
				shortestDistance = distanceToTroop;
				nearestTroop = troop;
			}
		}

		if (nearestTroop != null && shortestDistance <= range)
		{
			target = nearestTroop.transform;
			angle = Vector3.Angle (transform.position, target.up);
		}
*/
		// Target on Lane
		Vector3 checkTarget = transform.position + Vector3.up/2;
	//	Debug.DrawLine (checkTarget, checkTarget + Vector3.left*5, Color.red);
		Ray ray = new Ray (checkTarget, Vector3.left);
		RaycastHit[] hits = Physics.RaycastAll(ray, range);

		foreach (RaycastHit hit in hits) 
		{
			if (hit.transform.tag.Equals (stroopTag)) {
				target = hit.transform;
			//	Debug.DrawLine (hit.point, hit.point + Vector3.up*4, Color.blue);
			}
		}
	}	

	// Call from Animation
	public void HitPlayer(){
		
	//	if(CurrentAttackPlayer){
	////		CurrentAttackPlayer.GetComponent<CharController>().Hit(Damage);
	//	}else{
	//		anim.Play("walk");
	//		isWalk =true;
	//	}
	}

	void TakeDamge(int damge)
	{
		
	}
/*
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
*/
}
