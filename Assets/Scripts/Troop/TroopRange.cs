using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopRange : TroopManager {

	public GameObject arrowFire;
	public Transform posArrow;
	public bool isRoBinHodd;
	public bool isWizard;

	private float nextActtack = 0f;
	// Update is called once per frame
	public void Update () {

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
        CreateArrow();
    }

    public void AnimEventAttackSpec()
    {

    }

    // Wait anim a second
    void CreateArrow()
	{
		GameObject arrow;
		Arrow src;
		if (isWizard)
		{
			arrow = (GameObject)Instantiate (arrowFire, posArrow.position, transform.rotation);
			src = arrow.GetComponent<Arrow> ();
			if (src != null) {
				src.SeekArrow (damge, target.transform, true, false);
			}
		}
		else
		{
			arrow = (GameObject)Instantiate (arrowFire, posArrow.position, transform.rotation);
			src = arrow.GetComponent<Arrow> ();
			if (src != null) {
				src.SeekArrow (damge, target.transform, false, false);
			}
		}
	}

}
