using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public GameObject effectHit;
	private int Speed = 5;
	private int Damge;
	private Transform target;
	private bool slowDamge;
	EnemyManager enemyScr;
	// Use this for initialization
	public void SeekArrow (int damge, Transform tar, bool slow) {
		Damge = damge;
		target = tar;
		slowDamge = slow;
	}

	void Start()
	{
		enemyScr = target.GetComponent<EnemyManager> ();
		Destroy (gameObject, 1f);

	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = enemyScr.posHit.position - transform.position;
		float distanceThisFrame = Speed * Time.deltaTime;

		Debug.Log (" distanceThisFrame: "+distanceThisFrame + " +++ magnitude: " +dir.magnitude);
		if (dir.magnitude <= distanceThisFrame) 
		{
			Debug.Log (" Hittttttttttttttt ");
			GameObject effect = (GameObject)Instantiate (effectHit, transform.position, Quaternion.identity);
			Destroy (effect, 1f);
			Destroy (gameObject);
			enemyScr.TakeDamge (Damge);
			if (slowDamge) {
				enemyScr.TakeSlow ();
			}
			return;
		}
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt (enemyScr.posHit);
	}

}
