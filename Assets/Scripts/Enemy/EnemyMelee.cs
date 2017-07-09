using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyManager {


	private float nextActtack = 0f;
	// Update is called once per frame
	void Update () {
        if (isDie)
            return;

		if (isRun && !isHurt)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null && nextActtack <= 0)
		{
			isAttack = true;
			isRun = false;
			anim.SetBool ("isRun", isRun);
			anim.Play (actionAttack);
			nextActtack = attackDelay;
		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}

    public void AnimEventAttack() // Call from anim attack
    {
        CreateDamge();
    }

    void CreateDamge()
	{
        if (target != null)
        {
            TroopManager troop = target.GetComponent<TroopManager>();
            if (troop != null)
                troop.TakeDamge(damge);
            target = null;
        }
	}
}
