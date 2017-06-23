using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopRange : TroopManager {

	public GameObject arrowFire;
	public Transform posArrow;

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
		yield return new WaitForSeconds (0.5f);
		GameObject arrow = (GameObject)Instantiate (arrowFire, posArrow.position, transform.rotation);
		Arrow src = arrow.GetComponent<Arrow> ();
		if (src != null) 
		{
			src.SeekArrow (damge, target.transform);
		}
	}

}
