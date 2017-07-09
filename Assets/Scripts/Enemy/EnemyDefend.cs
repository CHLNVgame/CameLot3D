using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefend : EnemyManager {

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
			anim.Play (actionDefend);
			nextActtack = attackDelay;
	//		StartCoroutine (CreateDamge ());
		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}

    public void AnimEventAttack() // Call from anim attack
    {
        DeffendActive();
    }

    void DeffendActive()
    {

    }


}
