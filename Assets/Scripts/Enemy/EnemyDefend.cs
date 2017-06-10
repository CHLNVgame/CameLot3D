using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefend : EnemyManager {

	// Update is called once per frame
	void Update () {

		if (isRun)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null)
		{
			isAttack = true;
			isRun = false;

			anim.Play (actionDefend);
		}
	}
}
