using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public GameObject effectHit;
	private int Speed = 5;
	private int Damge;
	private Transform target;
	EnemyManager enemyScr;
	// Use this for initialization
	public void SeekArrow (int damge, Transform tar) {
		Damge = damge;
		target = tar;
	}

	void Start()
	{
		enemyScr = target.GetComponent<EnemyManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = enemyScr.posHit.position - transform.position;
		float distanceThisFrame = Speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame) 
		{
			GameObject effect = (GameObject)Instantiate (effectHit, transform.position, Quaternion.identity);
			Destroy (effect, 1f);
			Destroy (gameObject);
			enemyScr.TakeDamge (Damge);
			return;
		}
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt (enemyScr.posHit);
	}

}
