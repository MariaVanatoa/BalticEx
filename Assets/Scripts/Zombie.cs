using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

	//public Transform[] patrolPoints;

	//Transform currentPatrolPoint;
	//int currentPatrollIndex;

	public Transform target;
	public float chaseRange;
	public float speed;
	public float attackRange;
	public int damage;
	private float lastAttackTime;
	public float attackDelay;

	// Use this for initialization
	void Start () {

		//currentPatrollIndex = 0;
		//currentPatrolPoint = patrolPoints [currentPatrollIndex];
	}
	
	// Update is called once per frame
	void Update () {

		//get distance to the target and check to see if it is close enough to chace
		float distanceToTarget = Vector3.Distance (transform.position, target.position);
		//if in chase range
		if (distanceToTarget < chaseRange) {
			//start chasing the target - turn and move towards the target
			//figure out where the target is
			Vector3 targetDir = target.position - transform.position;
			////what is the angel
			//float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
			////qonvert to quad
			//Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			////rotate torward
			//transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);
			////move to the dir we faceing
			//transform.Translate (Vector3.up * Time.deltaTime * speed);

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);

		}

		//attacking.. check the distance between the zombie and the player to see if close enought to attack
		float distanceToPlayer = Vector3.Distance (transform.position, target.position);
		//are we close enough
		if (distanceToPlayer < attackRange) {
			//check to see if enough time has passed since last attack
			if (Time.time > lastAttackTime * attackDelay) {
				target.SendMessage ("TakeDamage", damage);
				//record the time attacked
				lastAttackTime = Time.time;
			}
		}
	}
}

