using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
	[SerializeField] Transform target;
	[SerializeField] float chaseRange = 15f;

	NavMeshAgent navMeshAgent;
	float distanceToTarget = Mathf.Infinity;

	void Start() {
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Update() {
		distanceToTarget = Vector3.Distance(target.position, transform.position);
		if (distanceToTarget <= chaseRange) {
			navMeshAgent.SetDestination(target.position);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		// Gizmos.color = new Color(25, 50, 50, .75f);
		Gizmos.DrawWireSphere(transform.position, chaseRange);
	}
}