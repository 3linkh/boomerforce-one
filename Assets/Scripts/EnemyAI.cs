using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    
    [SerializeField] float turnSpeed = 5f;
    AudioSource provokedAudioSource;
    NavMeshAgent navMeshAgent;
    CapsuleCollider capsuleCollider;

    float distanceToTarget = Mathf.Infinity;

    bool isProvoked = false;

    EnemyHealth health;
    Transform target;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;
        provokedAudioSource = GetComponent<AudioSource>();
        provokedAudioSource.Stop();
    }

    void Update()
    {
        
        if (health.IsDead())
        {
            enabled = false;
            navMeshAgent.enabled = false;
            capsuleCollider.enabled = false;

        }
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {   
            isProvoked = true;
            ProvokedSound();
        }
        
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        
    }
    void ChaseTarget()
    {   
        GetComponent<Animator>().SetBool("isAttacking", false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
        
    }

    private void FaceTarget()
    {   
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void ProvokedSound()
    {
        {
            provokedAudioSource.Play();
        }
    }
}