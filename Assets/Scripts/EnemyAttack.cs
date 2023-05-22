using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float attackRange = 3;
    PlayerHealth target;
    [SerializeField] float damage = 40f;
    EnemyAI enemyAI;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        enemyAI = GetComponent<EnemyAI>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        if (enemyAI.distanceToTarget < attackRange)
        {
            target.TakeDamage(damage);
        //target.GetComponent<DisplayDamage>().ShowDamageImpact();    
        }
           
        
    }

}