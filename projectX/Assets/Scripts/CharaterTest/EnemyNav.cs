using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour {

    public float agroRange;
    public float attackDistance;
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent navAgent;

    public Transform aim;
    public Weapon weapon;

    private bool attacking = false;

    void Update()
    {
        CheckPlayer();
    }

    void CheckPlayer(){
        if (Vector3.Distance(transform.position, player.transform.position) < agroRange)
        {
            navAgent.SetDestination(player.transform.position);

        }

    }
}
