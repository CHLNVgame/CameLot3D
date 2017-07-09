using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopMelee : TroopManager {
	

	private float nextActtack = 0f;
	// Update is called once per frame
	void Update() {
        if (isDie)
            return;

        if (isRun)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null && nextActtack <= 0)
		{
			anim.Play (actionAttack);
			nextActtack = attackDelay;
		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}

    public void AnimEventAttack()
    {
        CreateDamge();
    }

    public void AnimEventAttackSpec()
    {

    }

    void CreateDamge()
	{
		EnemyManager enemy = target.GetComponent<EnemyManager>();
		if(enemy != null)
			enemy.TakeDamge(damge);

        target = null;
    }

}
