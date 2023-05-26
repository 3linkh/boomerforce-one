using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float moveForce = 10f;
    public float projectileDamage = 10f;
    private Transform target;
    private Rigidbody projectileRigidbody;


    private void Awake()
    {
        projectileRigidbody = GetComponent<Rigidbody>();
        GetProjectileTarget();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            MoveToTarget();
        }
    }

    private void GetProjectileTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
    }

    private void MoveToTarget()
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        if(target == null)
        {
            Destroy(this.gameObject);
        }

        else if(target != enemyHealth.isDead)
        {
            Vector3 direction = (target.position - projectileRigidbody.position).normalized;
            projectileRigidbody.AddForce(direction * moveForce, ForceMode.Force);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(projectileDamage);
            Destroy(this.gameObject);
        }
        
    }
}
