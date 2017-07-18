using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

	public enum ChoiseName{isGrunt, isArcher, isWarrior, isFlute, isSiege};
	[Header("Option Setting")]
	public ChoiseName nameEnemy;
	public Transform posHit;
    public bool isEnemyDefend;
    public Material slowMesh;
    public Material normalMesh;
    public SkinnedMeshRenderer skinMesh;

    [Header("Option View")]
	
	public bool isRun;
	public bool isAttack;
	public bool isHurt;
    public bool isDie;
    public int goldRatio;
	public int goldNumber;
	public Animator anim;
	public float speedSlow;
	public float speedNormal;
	public Transform target;
	public const string actionRun ="walk";
	public const string actionAttack = "attack";
	public const string actionDefend = "defend";
	public const string actionBuff = "buff";
	public const string actionHurt = "hurt";
	public const string actionDie = "die";

    protected int level = 0;
    protected float hp;
    protected float speed;
    protected float damge;
    protected float range;
    protected float attackDelay;

    string troopTag = "Troop";



	public void TakeSlow(){
		skinMesh.material = slowMesh; 
		speed = speedSlow;
		//CancelInvoke();
		Invoke("CancelSlow",2f);

	}

	void CancelSlow(){
		speed = speedNormal;
		skinMesh.material = normalMesh; 
	}


	// Use this for initialization
	void Start () {
		GetAttributes ();
		anim = GetComponent<Animator> ();
		isRun = true;
		anim.SetBool ("isRun", isRun);
		speedSlow = speed/2;
		speedNormal = speed;
		anim.Play (actionRun);

		InvokeRepeating ("UpdateTarget", 0f, 0.5f);

	}
		

	void UpdateTarget()
	{
        /*
                // Target on Radius
                GameObject[] troops = GameObject.FindGameObjectsWithTag (stroopTag);
                float shortestDistance = Mathf.Infinity;
                GameObject nearestTroop = null;

                foreach(GameObject troop in troops)
                {
                    float distanceToTroop = Vector3.Distance (transform.position, troop.transform.position);
                    if (distanceToTroop < shortestDistance) 
                    {

                        shortestDistance = distanceToTroop;
                        nearestTroop = troop;
                    }
                }

                if (nearestTroop != null && shortestDistance <= range)
                {
                    target = nearestTroop.transform;
                    angle = Vector3.Angle (transform.position, target.up);
                }
        */
        if (isDie)
            return;
		// Target on Lane
		Vector3 checkTarget = transform.position + Vector3.up/2;
		Debug.DrawLine (checkTarget, checkTarget + Vector3.left*5, Color.red);
		Ray ray = new Ray (checkTarget, Vector3.left);
		RaycastHit[] hits = Physics.RaycastAll(ray, range);

        target = null;
        float shortestDistance = range;
        foreach (RaycastHit hit in hits)
        {
            Transform tempTarget = hit.transform;
            float tempDistance = Vector3.Distance(checkTarget, tempTarget.position);

            if (tempTarget.tag.Equals(troopTag) && !tempTarget.GetComponent<TroopManager>().isDie)
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

        if (target == null) {
			isRun = true;
			isAttack = false;
			anim.SetBool ("isRun", isRun);
			anim.Play (actionRun);
		}
	}	

	public void TakeDamge(float damge)
	{
		hp -= damge;

        if (hp <= 0) 
		{
            isDie = true;
			anim.Play (actionDie);
            Destroy(gameObject, 8f);
            InvokeRepeating("DestroyObject", 4f, 0.05f);
            
			return;
		}

        isHurt = true;
        anim.Play (actionHurt);
        Invoke("DelayHurt", 0.5f);

    }

    void DestroyObject()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }

	public void DelayHurt()
	{
		isHurt = false;
	}
/*
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}
*/
	void GetAttributes()
	{
		if (nameEnemy == ChoiseName.isGrunt) {
			hp = Attributes.SKELETON_GRUNT_ATT [level, Attributes.HP_ENEMY];
			speed = Attributes.SKELETON_GRUNT_ATT [level, Attributes.SPEED_ENEMY];
			damge = Attributes.SKELETON_GRUNT_ATT [level, Attributes.DAMGE_ENEMY];
			range = Attributes.SKELETON_GRUNT_ATT [level, Attributes.RANGE_ENEMY];
			attackDelay = Attributes.SKELETON_GRUNT_ATT [level, Attributes.ATTACK_DELAY_ENEMY];
		}
		if (nameEnemy == ChoiseName.isArcher) {
			hp = Attributes.SKELETON_ARCHER_ATT [level, Attributes.HP_ENEMY];
			speed = Attributes.SKELETON_ARCHER_ATT [level, Attributes.SPEED_ENEMY];
			damge = Attributes.SKELETON_ARCHER_ATT [level, Attributes.DAMGE_ENEMY];
			range = Attributes.SKELETON_ARCHER_ATT [level, Attributes.RANGE_ENEMY];
			attackDelay = Attributes.SKELETON_ARCHER_ATT [level, Attributes.ATTACK_DELAY_ENEMY];
		}
		if (nameEnemy == ChoiseName.isWarrior) {
			hp = Attributes.SKELETON_WARRIOR_ATT [level, Attributes.HP_ENEMY];
			speed = Attributes.SKELETON_WARRIOR_ATT [level, Attributes.SPEED_ENEMY];
			damge = Attributes.SKELETON_WARRIOR_ATT [level, Attributes.DAMGE_ENEMY];
			range = Attributes.SKELETON_WARRIOR_ATT [level, Attributes.RANGE_ENEMY];
			attackDelay = Attributes.SKELETON_WARRIOR_ATT [level, Attributes.ATTACK_DELAY_ENEMY];
		}
		if (nameEnemy == ChoiseName.isFlute) {
			hp = Attributes.SKELETON_FLUTE_ATT [level, Attributes.HP_ENEMY];
			speed = Attributes.SKELETON_FLUTE_ATT [level, Attributes.SPEED_ENEMY];
			damge = Attributes.SKELETON_FLUTE_ATT [level, Attributes.DAMGE_ENEMY];
			range = Attributes.SKELETON_FLUTE_ATT [level, Attributes.RANGE_ENEMY];
			attackDelay = Attributes.SKELETON_FLUTE_ATT [level, Attributes.ATTACK_DELAY_ENEMY];
		}
		if (nameEnemy == ChoiseName.isSiege) {
			hp = Attributes.SKELETON_SIEGE_ATT [level, Attributes.HP_ENEMY];
			speed = Attributes.SKELETON_SIEGE_ATT [level, Attributes.SPEED_ENEMY];
			damge = Attributes.SKELETON_SIEGE_ATT [level, Attributes.DAMGE_ENEMY];
			range = Attributes.SKELETON_SIEGE_ATT [level, Attributes.RANGE_ENEMY];
			attackDelay = Attributes.SKELETON_SIEGE_ATT [level, Attributes.ATTACK_DELAY_ENEMY];
		}
	}
}
