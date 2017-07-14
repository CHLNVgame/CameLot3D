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
    float firstDistance;
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
        firstDistance = 0;


    }

	// Update is called once per frame
	void Update () {
		Vector3 dir;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }


        if (targetTroop) {
			dir = troopScr.posHit.position - transform.position;
		} else {
			dir = enemyScr.posHit.position - transform.position;
		}
				
		float distanceThisFrame = Speed * Time.deltaTime;

        if (firstDistance == 0)
            firstDistance = dir.magnitude / 2;
    //	Debug.Log (" distanceThisFrame: "+distanceThisFrame + " +++ magnitude: " +dir.magnitude);
        if (dir.magnitude <= distanceThisFrame) 
		{
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

            target = null;
			return;
		}
   /*     //	transform.Translate (dir.normalized * distanceThisFrame, Space.World);
        transform.Translate(Vector3.forward * Time.deltaTime * 5, Space.World);
        if (targetTroop)
        {
          //  transform.LookAt(troopScr.posHit);
            transform.rotation = Quaternion.Lerp(transform.rotation, troopScr.posHit.rotation, Time.deltaTime * 5);
        }
        else
        {
          //  transform.LookAt(enemyScr.posHit);
            transform.rotation = Quaternion.Lerp(transform.rotation, enemyScr.posHit.rotation, Time.deltaTime * 5);
        }
        */
        transform.LookAt(enemyScr.posHit);

        //clamp the angle magnitude to be less than 45 or less the dist ratio will be off
        float tempRotate = (dir.magnitude - firstDistance)/ firstDistance;
        if(tempRotate > 0)
            transform.rotation = transform.rotation * Quaternion.Euler(-45* tempRotate, 0, 0);
        float curDist = Vector3.Distance(transform.position, enemyScr.posHit.position);
      //  transform.Translate(Vector3.forward * Mathf.Min(10 * Time.deltaTime, curDist));
        transform.Translate(Vector3.forward* distanceThisFrame);
    }

}
