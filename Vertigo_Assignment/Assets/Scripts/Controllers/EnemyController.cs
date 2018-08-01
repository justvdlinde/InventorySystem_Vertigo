using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10;
    public float attackRadius = 2;

    private Transform target;
    private NavMeshAgent agent;
    private CharacterCombat combat;


    private void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
	}

    private void Update () {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius) {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (targetStats != null && distance <= attackRadius) {
                combat.Attack(targetStats);
            }
            agent.SetDestination(target.position);
        }
	}

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
