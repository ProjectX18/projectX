using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float radius = 20f;
    [SerializeField] float stopDistance = 5f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Friendly").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (InRange() && !TooClose())
            Chase();
	}

    void Chase()
    {
        float diffx = player.position.x - transform.position.x;
        float diffz = player.position.z - transform.position.z;
        transform.Translate(new Vector3(diffx, 0, diffz).normalized * speed * Time.fixedDeltaTime, Space.World);
    }

    bool TooClose()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer < stopDistance;
    }

    bool InRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        return distanceToPlayer < radius;
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}
