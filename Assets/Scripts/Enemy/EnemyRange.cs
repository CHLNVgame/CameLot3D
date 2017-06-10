using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyManager {

	private float nextActtack = 0f;
	// Update is called once per frame
	void Update () {

		if (isRun)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		Debug.Log (" xxxxxxxxx nextActtack: "+nextActtack);
		if (target != null && nextActtack <= 0)
		{
			Debug.Log (" +++++++++++ ");
			isAttack = true;
			isRun = false;

			anim.Play (actionAttack);
			nextActtack = attackDelay;

		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}
}
