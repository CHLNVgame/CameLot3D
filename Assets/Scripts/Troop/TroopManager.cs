using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour {

	public enum ChoiseName { isStreetFighter, isRobinhood, isRoyalGuard, isRocky, isDefendGuardian, isBoomer, isCentaur, isWizard, isDragon, isFarmer};
	[Header("Settings")]
	public ChoiseName nameTroop;
	public Transform posHit;
	public int level = 0;

	[Header("View")]
	protected float hp;
    protected float speed;
    protected float damge;
    protected float damgeSpec;
    protected float range;
    protected float attackDelay;
    protected float ratioSpecSkill;

    // ATT only for Farmer. speed as time to appear food, damge ass food to appear
    protected float timeProductFood;
    protected float foodProduct;

	public bool isRun;
	public bool isHurt;
    public bool isDie;
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
    public const string actionWork = "work";


	string enemyTag = "Enemy";


    void Start () {
        GetAttribute();
        anim = GetComponent<Animator> ();
		isRun = false;
        if (nameTroop == ChoiseName.isDefendGuardian)
            anim.Play(actionDefend);
        else if (nameTroop == ChoiseName.isFarmer)
            anim.Play(actionWork);
        else
            anim.Play(actionIdle);

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}

	public void TakeSlow(){
	//	skinMesh.material = slowMesh; 
	//	speed = speedSlow;
		//CancelInvoke();
		Invoke("CancelSlow",2f);

	}

	void CancelSlow(){
		//speed = speedNormal;
		//skinMesh.material = normalMesh; 
	}

	void UpdateTarget()
	{
        if (isDie)
            return;
		// Target on Lane
		Vector3 checkTarget = transform.position + Vector3.right + Vector3.up/2;
		//Debug.DrawLine (checkTarget, checkTarget + Vector3.up*5, Color.black);
		//Debug.DrawLine (checkTarget, checkTarget + Vector3.right*range, Color.red);
		Ray ray = new Ray (checkTarget, Vector3.right);
		RaycastHit[] hits = Physics.RaycastAll(ray, range);

        target = null;
        float shortestDistance = range;
		foreach (RaycastHit hit in hits) 
		{
            Transform tempTarget = hit.transform;
            float tempDistance = Vector3.Distance(checkTarget, tempTarget.position);

            if (tempTarget.tag.Equals(enemyTag) && !tempTarget.GetComponent<EnemyManager>().isDie)
            {
                if (tempDistance < shortestDistance)
                {
                    target = tempTarget;
                    shortestDistance = tempDistance;                    
                }
 			//	target = hit.transform.GetComponent<EnemyManager> ().posHit;
			//	Debug.DrawLine (hit.point, hit.point + Vector3.up*4, Color.blue);
			}
		}
	}


	public void TakeDamge(float damge)
	{
		hp -= damge;

		if (hp <= 0) 
		{
            isDie = true;
        //    Debug.Log(" anim: "+anim);
			anim.Play (actionDie);
            Destroy(gameObject, 8f);
            InvokeRepeating("DestroyObject", 4f, 0.05f);
            return;
		}

        isHurt = true;
        anim.Play (actionHurt);
        Invoke ("DelayHurt", 0.5f);

    }
    void DestroyObject()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }

    public void DelayHurt()
	{
		isHurt = false;
	}

	public void GetAttribute()
	{
		if (nameTroop == ChoiseName.isStreetFighter)
        {
			hp = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_STREET_FIGHTER_ATT [level, Attributes.RATIO_SPEC_TROOP];
          
		}
		if (nameTroop == ChoiseName.isRobinhood)
        {
			hp = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_ROBINHOOD_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == ChoiseName.isRoyalGuard)
        {
			hp = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_ROYAL_GUARD_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == ChoiseName.isRocky)
        {
			hp = Attributes.TROOP_ROCKY_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_ROCKY_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_ROCKY_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_ROCKY_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_ROCKY_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_ROCKY_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_ROCKY_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == ChoiseName.isDefendGuardian)
        {
			hp = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_DEFEND_GUARDIAN_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == ChoiseName.isBoomer)
        {
			hp = Attributes.TROOP_BOOMER_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_BOOMER_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_BOOMER_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_BOOMER_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_BOOMER_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_BOOMER_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_BOOMER_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == ChoiseName.isCentaur)
        {
			hp = Attributes.TROOP_CENTAUR_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_CENTAUR_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_CENTAUR_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_CENTAUR_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_CENTAUR_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_CENTAUR_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_CENTAUR_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
		if (nameTroop == ChoiseName.isWizard)
        {
			hp = Attributes.TROOP_WIZARD_ATT [level, Attributes.HP_TROOP];
			speed = Attributes.TROOP_WIZARD_ATT [level, Attributes.SPEED_TROOP];
			damge = Attributes.TROOP_WIZARD_ATT [level, Attributes.DAMGE_TROOP];
			range = Attributes.TROOP_WIZARD_ATT [level, Attributes.RANGE_TROOP];
			attackDelay = Attributes.TROOP_WIZARD_ATT [level, Attributes.ATTACK_DELAY_TROOP];
			damgeSpec = Attributes.TROOP_WIZARD_ATT [level, Attributes.DAMGE_SPEC_TROOP];
			ratioSpecSkill = Attributes.TROOP_WIZARD_ATT [level, Attributes.RATIO_SPEC_TROOP];
		}
        if (nameTroop == ChoiseName.isDragon)
        {
            hp = Attributes.TROOP_DRAGON_ATT[level, Attributes.HP_TROOP];
            speed = Attributes.TROOP_DRAGON_ATT[level, Attributes.SPEED_TROOP];
            damge = Attributes.TROOP_DRAGON_ATT[level, Attributes.DAMGE_TROOP];
            range = Attributes.TROOP_DRAGON_ATT[level, Attributes.RANGE_TROOP];
            attackDelay = Attributes.TROOP_DRAGON_ATT[level, Attributes.ATTACK_DELAY_TROOP];
            damgeSpec = Attributes.TROOP_DRAGON_ATT[level, Attributes.DAMGE_SPEC_TROOP];
            ratioSpecSkill = Attributes.TROOP_DRAGON_ATT[level, Attributes.RATIO_SPEC_TROOP];
        }
        if (nameTroop == ChoiseName.isFarmer)
        {
            hp = Attributes.TROOP_FARMER_ATT[level, Attributes.HP_TROOP];
            speed = Attributes.TROOP_FARMER_ATT[level, Attributes.SPEED_TROOP];
            damge = Attributes.TROOP_FARMER_ATT[level, Attributes.DAMGE_TROOP];
            range = Attributes.TROOP_FARMER_ATT[level, Attributes.RANGE_TROOP];
            attackDelay = Attributes.TROOP_FARMER_ATT[level, Attributes.ATTACK_DELAY_TROOP];
            damgeSpec = Attributes.TROOP_FARMER_ATT[level, Attributes.DAMGE_SPEC_TROOP];
            ratioSpecSkill = Attributes.TROOP_FARMER_ATT[level, Attributes.RATIO_SPEC_TROOP];

            timeProductFood = speed;
            foodProduct = damge;
        }
	}
}