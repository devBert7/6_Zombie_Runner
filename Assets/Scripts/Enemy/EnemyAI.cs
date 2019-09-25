using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	[SerializeField] float chaseRange = 15f;
	[SerializeField] float turnSpeed = 5f;

	NavMeshAgent navMeshAgent;
	EnemyHealth enemyHealth;
	float distanceToTarget = Mathf.Infinity;
	bool isProvoked = false;
	Transform target;

	void Start() {
		navMeshAgent = GetComponent<NavMeshAgent>();
		enemyHealth = GetComponent<EnemyHealth>();
		target = FindObjectOfType<PlayerHealth>().transform;
	}

	void Update() {
		if (enemyHealth.IsDead()) {
			enabled = false;
			navMeshAgent.enabled = false;
		}

		distanceToTarget = Vector3.Distance(target.position, transform.position);

		if (isProvoked) {
			EngageTarget(distanceToTarget);
		} else if (distanceToTarget <= chaseRange) {
			isProvoked = true;
		}
	}

	public void OnDamageTaken() {
		isProvoked = true;
	}

	void EngageTarget(float distanceToTarget) {
		if (distanceToTarget >= navMeshAgent.stoppingDistance) {
			ChaseTarget();
		}

		if (distanceToTarget <= navMeshAgent.stoppingDistance) {
			FaceTarget();
			AttackTarget();
		} else {
			GetComponent<Animator>().SetBool("Attack", false);
		}
	}

	void ChaseTarget() {
		GetComponent<Animator>().SetTrigger("Move");
		navMeshAgent.SetDestination(target.position);
	}

	void AttackTarget() {
		GetComponent<Animator>().SetBool("Attack", true);
	}

	void FaceTarget() {
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		// Gizmos.color = new Color(25, 50, 50, .75f);
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}