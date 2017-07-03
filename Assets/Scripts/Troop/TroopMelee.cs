using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopMelee : TroopManager {
	

	private float nextActtack = 0f;
	// Update is called once per frame
	void Update() {

		if (isRun)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null && nextActtack <= 0)
		{
			anim.Play (actionAttack);
			nextActtack = attackDelay;
			StartCoroutine (CreateDamge ());

		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}

	IEnumerator CreateDamge()
	{
		yield return new WaitForSeconds (0.5f);
		EnemyManager enemy = target.GetComponent<EnemyManager>();
		if(enemy != null)
			enemy.TakeDamge(damge);

        target = null;
    }

}
