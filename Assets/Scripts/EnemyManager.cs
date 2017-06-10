using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public float angle;
	public float speed;
	public int hp;
	public int damge;
	public float range;

	public bool isWalk;
	public bool isAttack;
	public Animator anim;

	float speedSlow;
	float speedNormal;

	private Transform target;
	string stroopTag = "Troop";

	// Use this for initialization
	void Start () {
		isWalk = true;
		speedSlow = speed/2;
		speedNormal = speed;
		anim = GetComponent<Animator> ();
		anim.Play ("walk");

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}

	void UpdateTarget()
	{
		GameObject[] troops = GameObject.FindGameObjectsWithTag (stroopTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestTroop = null;


/*
 		// Target on Radius
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
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, range ))
		{
		//	Debug.DrawLine (hit.point, hit.point + Vector3.up*4, Color.blue);
			target = hit.transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if (isWalk)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null)
		{
			isAttack = true;
			isWalk = false;

			anim.Play ("attack");
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

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
}
