using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 3.0f;
    public float timeUntilObstacleSpawn;
    public float obstacleSpeed = 7.25f;

    private void Update()
    {
        SpawnLoop();
        if (obstacleSpawnTime >= 0.75)
        {
            obstacleSpawnTime -= 0.05f * Time.deltaTime;
            obstacleSpeed += 0.175f * Time.deltaTime;
        }
        
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0;
        }
    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
