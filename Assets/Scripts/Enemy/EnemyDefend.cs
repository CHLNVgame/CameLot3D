using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefend : EnemyManager {

	private float nextActtack = 0f;
	// Update is called once per frame
	void Update () {

		if (isRun && !isHurt)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null && nextActtack <= 0)
		{
			isAttack = true;
			isRun = false;
			anim.SetBool ("isRun", isRun);
			anim.Play (actionDefend);
			nextActtack = attackDelay;
	//		StartCoroutine (CreateDamge ());
		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}

	IEnumerator CreateDamge()
	{
		yield return new WaitForSeconds (0.5f);
		TroopManager troop = target.GetComponent<TroopManager>();
		if(troop != null)
			troop.TakeDamge(damge);
		target = null;
	}
}
