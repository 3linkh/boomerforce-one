using UnityEngine;

public class DroneBehaviour : MonoBehaviour
{
    public GameObject player;  // Reference to the player game object
    public GameObject projectilePrefab;  // Prefab of the projectile to be fired
    public float circleRadius = 5f;  // Radius of the circular path
    public float rotationSpeed = 2f;  // Speed of rotation around the player
    public float fireRate = 1f;  // Rate of fire in seconds
    public float detectionRange = 10f;  // Maximum range to detect target objects
    public float height = 5f;

    private float nextFireTime;  // Time for next projectile fire

    private void Update()
    {
        // Calculate the target position on the circular path
        Vector3 targetPosition = player.transform.position + Quaternion.Euler(0f, Time.time * rotationSpeed, 0f) * new Vector3(circleRadius, height, 0f);

        // Move the game object towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);

        // Check if it's time to fire a projectile
        if (Time.time >= nextFireTime)
        { 
            FireProjectile();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
      
    private void FireProjectile()
    {
        if (CheckIfEnemyInRange())
        {
            // Enemy is within range, do something
            Debug.Log("Enemy detected within range, fire projectile");
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            // No enemy within range
            Debug.Log("No enemy within range");
        }
        
        // Instantiate a projectile at the current position
        
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    private bool CheckIfEnemyInRange()
    {
       
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // An enemy is within range
                return true;
            }
        }

        // No enemy is within range
        return false;
    }


}
