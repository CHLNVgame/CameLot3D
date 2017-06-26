using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public GameObject effectHit;
	private float Speed = 6;
	private float Damge;
	private Transform target;
	private bool slowDamge;
	private bool targetTroop;
	EnemyManager enemyScr;
	TroopManager troopScr;
	// Use this for initialization
	public void SeekArrow (float damge, Transform tar, bool slow, bool troop) {
		Damge = damge;
		target = tar;
		slowDamge = slow;
		targetTroop = troop;
	}

	void Start()
	{
		if(targetTroop)
			troopScr = target.GetComponent<TroopManager> ();
		else
			enemyScr = target.GetComponent<EnemyManager> ();
		Destroy (gameObject, 1.5f);

	}

	// Update is called once per frame
	void Update () {
		Vector3 dir;
		if (targetTroop) {
			dir = troopScr.posHit.position - transform.position;
		} else {
			dir = enemyScr.posHit.position - transform.position;
		}
				
		float distanceThisFrame = Speed * Time.deltaTime;

		Debug.Log (" distanceThisFrame: "+distanceThisFrame + " +++ magnitude: " +dir.magnitude);
		if (dir.magnitude <= distanceThisFrame) 
		{
			Debug.Log (" Hittttttttttttttt ");
			GameObject effect = (GameObject)Instantiate (effectHit, transform.position, Quaternion.identity);
			Destroy (effect, 1f);
			Destroy (gameObject);

			if (targetTroop) {
				troopScr.TakeDamge (Damge);
				if (slowDamge) {
					troopScr.TakeSlow ();
				}
			} else {
				enemyScr.TakeDamge (Damge);
				if (slowDamge) {
					enemyScr.TakeSlow ();
				}
			}
			return;
		}
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt (enemyScr.posHit);
	}

}
