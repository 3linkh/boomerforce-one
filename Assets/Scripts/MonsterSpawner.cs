using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] float monsterStartSpawnTime = 3f;
    [SerializeField] float monsterCurrentSpawnTime;
    public GameObject monsterPrefab;
    public Transform[] spawnPoints; // Array to store spawn points

    private void Start()
    {
          monsterCurrentSpawnTime = monsterStartSpawnTime;
    }
    private void Update() 
    {
        //if(Input.GetKeyDown("k"))
        {
            SpawnTimer();
        }
    }

    private void SpawnTimer()
    {
        monsterCurrentSpawnTime -= Time.deltaTime;
        if (monsterCurrentSpawnTime <= 0)
        {
            SpawnMonster();
            monsterCurrentSpawnTime = monsterStartSpawnTime;
                    
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Draw a sphere Gizmo at each spawn point position
        foreach (Transform spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint.position, 0.5f);
        }
    }

    private void SpawnMonster()
    {
        // Generate a random index within the spawnPoints array length
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate a monster prefab at the randomly selected spawn point
        Instantiate(monsterPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}