using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour {

	public enum choiseName{isStreetFighter, isRobinhood, isRoyalGuard, isRocky, isDefendGuardian, isBoomer, isCentaur, isWizard, isDragon};
	[Header("Settings")]
	public choiseName nameTroop;
	public int level = 0;

	[Header("View")]
	 float hp;
	protected float speed;
	protected float damge;
	protected float damgeSpec;
	protected float range;
	protected float attackDelay;
	protected float foodRequire;
	protected float timeNextTroop;
	protected float ratioSpecSkill;

	public bool isRun;
	public bool isHurt;
	public Animator anim;
	public float speedSlow;
	public float speedNormal;
	public Transform target;
	public const string actionRun ="run";
	public const string actionIdle ="idle";
	public const string actionAttack = "attack";
	public const string actionAttackSpec = "attackspec";
	public const string actionDefend = "defend";
	public const string actionBuff = "buff";
	public const string actionHurt = "hurt";
	public const string actionDie = "die";

	string enemyTag = "Enemy";

	void Start () {
		GetAttribute ();
		anim = GetComponent<Animator> ();
		isRun = false;

		anim.Play (actionIdle);

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}

	void UpdateTarget()
	{
		// Target on Lane
		Vector3 checkTarget = transform.position + Vector3.right + Vector3.up/2;
		Debug.DrawLine (checkTarget, checkTarget + Vector3.up*5, Color.black);
		Debug.DrawLine (checkTarget, checkTarget + Vector3.right*range, Color.red);
		Ray ray = new Ray (checkTarget, Vector3.right);
		RaycastHit[] hits = Physics.RaycastAll(ray, range);

		foreach (RaycastHit hit in hits) 
		{
			if (hit.transform.tag.Equals (enemyTag)) {
				target = hit.transform;
			//	target = hit.transform.GetComponent<EnemyManager> ().posHit;
				Debug.DrawLine (hit.point, hit.point + Vector3.up*4, Color.blue);
			}
		}
	}


	public void TakeDamge(float damge)
	{
		hp -= damge;
		isHurt = true;
		Invoke ("DelayHurt", 0.5f);
		if (hp <= 0) 
		{
			anim.Play (actionDie);
			Destroy (gameObject, 1f);
			return;
		}
		anim.Play (actionHurt);

	}
	public void DelayHurt()
	{
		isHurt = false;
	}

	public void GetAttribute()
	{
		if (nameTroop == choiseName.isStreetFighter) {
			hp = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isRobinhood) {
			hp = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isRoyalGuard) {
			hp = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isRocky) {
			hp = Attributes.TROOP_ROCKY_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_ROCKY_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_ROCKY_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_ROCKY_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_ROCKY_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_ROCKY_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_ROCKY_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_ROCKY_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isDefendGuardian) {
			hp = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isBoomer) {
			hp = Attributes.TROOP_BOOMER_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_BOOMER_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_BOOMER_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_BOOMER_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_BOOMER_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_BOOMER_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_BOOMER_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_BOOMER_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isCentaur) {
			hp = Attributes.TROOP_CENTAUR_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_CENTAUR_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_CENTAUR_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_CENTAUR_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_CENTAUR_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_CENTAUR_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_CENTAUR_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_CENTAUR_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isWizard) {
			hp = Attributes.TROOP_WIZARD_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_WIZARD_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_WIZARD_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_WIZARD_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_WIZARD_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_WIZARD_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_WIZARD_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_WIZARD_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == choiseName.isDragon) {
			hp = Attributes.TROOP_DRAGON_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_DRAGON_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_DRAGON_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_DRAGON_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_DRAGON_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_DRAGON_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			timeNextTroop = Attributes.TROOP_DRAGON_ATT [level, Attributes.TIME_NEXT_TROOP];
			ratioSpecSkill = Attributes.TROOP_DRAGON_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
	}
}