using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyManager {
	
	public GameObject arrowFire;
	public Transform posArrow;

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
        CreateArrow();
    }

    void CreateArrow()
	{
		GameObject arrow;
		Arrow src;
		arrow = (GameObject)Instantiate (arrowFire, posArrow.position, transform.rotation);
		src = arrow.GetComponent<Arrow> ();
		if (src != null) {
			src.SeekArrow (damge, target.transform, false, true);
		}
		target = null;
	}
}
