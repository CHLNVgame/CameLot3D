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

		if (isRun)
		{
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}

		if (target != null && nextActtack <= 0)
		{
			anim.Play (actionAttack);
			nextActtack = attackDelay;
			StartCoroutine(CreateArrow ());
		}

		if (nextActtack > 0)
			nextActtack -= Time.deltaTime;
	}

	// Wait anim a second
	IEnumerator CreateArrow()
	{
		GameObject arrow;
		Arrow src;
	/*	if (isRoBinHodd) {
			yield return new WaitForSeconds (0.15f);
			arrow = (GameObject)Instantiate (arrowFire, posArrow.position + (new Vector3 (0, 0, -0.2f)), transform.rotation);
			src = arrow.GetComponent<Arrow> ();
			if (src != null) {
				src.SeekArrow (damge / 2, target.transform, false);
			}
			yield return new WaitForSeconds (0.6f);
			arrow = (GameObject)Instantiate (arrowFire, posArrow.position + (new Vector3 (0, 0, 0.2f)), transform.rotation);
			src = arrow.GetComponent<Arrow> ();
			if (src != null) {
				src.SeekArrow (damge / 2, target.transform, false);
			}
		} else */
		if (isWizard)
		{
			yield return new WaitForSeconds (0.4f);
			arrow = (GameObject)Instantiate (arrowFire, posArrow.position, transform.rotation);
			src = arrow.GetComponent<Arrow> ();
			if (src != null) {
				src.SeekArrow (damge, target.transform, true);
			}
		}
		else
		{
			yield return new WaitForSeconds (0.55f);
			arrow = (GameObject)Instantiate (arrowFire, posArrow.position, transform.rotation);
			src = arrow.GetComponent<Arrow> ();
			if (src != null) {
				src.SeekArrow (damge, target.transform, false);
			}
		}

		target = null;
	}

}
