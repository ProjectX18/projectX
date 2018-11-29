using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float chaseRadius;
    [SerializeField] float stunTime;
	[SerializeField] Saw saw;
	private NavMeshAgent navAgent;

	private Vector3 target;
	// Use this for initialization
	void Start (){
		target = transform.position;
		saw.tag = tag;
		navAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		GameObject enemy = Global.nearestEnemyInSight(gameObject, chaseRadius);
		if (enemy != null) target = enemy.transform.position;
		if (Time.timeSinceLevelLoad > stunTime + saw.lastDamageTime){
//			navAgent.SetDestination(target); //currently does not work
			Chase();
		}
	}
	
	void Chase() {
		float diffx = target.x - transform.position.x;
		float diffz = target.z - transform.position.z;
		transform.Translate(new Vector3(diffx, 0, diffz).normalized * speed * Time.fixedDeltaTime, Space.World);
	}

    private void OnDrawGizmosSelected () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
	    Gizmos.DrawWireSphere(transform.position, speed);
    }
}
