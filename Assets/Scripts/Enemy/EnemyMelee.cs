using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyManager {


	// Update is called once per frame
	private float nextActtack = 0f;
	void Update () {

		if (isRun)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null && nextActtack <= 0)
		{
			isAttack = true;
			isRun = false;

			anim.Play (actionAttack);
			nextActtack = attackDelay;

		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}
}
